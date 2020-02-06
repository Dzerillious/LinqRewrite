using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shaman.Roslyn.LinqRewrite
{
    public partial class LinqRewriter : CSharpSyntaxRewriter
    {
        private readonly SemanticModel _semantic;

        public LinqRewriter(SemanticModel semantic)
        {
            _semantic = semantic;
        }

        public int RewrittenMethods { get; private set; }
        public int RewrittenLinqQueries { get; private set; }

        static LinqRewriter()
        {
            KnownMethods = typeof(LinqRewriter).GetTypeInfo().DeclaredFields
                .Where(x => x.Name.EndsWith("Method") && x.FieldType == typeof(string))
                .Select(x => (string) x.GetValue(null))
                .ToList();
        }

        private static readonly List<string> KnownMethods;

        public override SyntaxNode VisitInvocationExpression(InvocationExpressionSyntax node)
            => TryCatchVisitInvocationExpression(node, null) ?? base.VisitInvocationExpression(node);

        private bool insideConditionalExpression;

        public override SyntaxNode VisitConditionalAccessExpression(ConditionalAccessExpressionSyntax node)
        {
            var old = insideConditionalExpression;
            insideConditionalExpression = true;
            try
            {
                return base.VisitConditionalAccessExpression(node);
            }
            finally
            {
                insideConditionalExpression = old;
            }
        }

        private ExpressionSyntax TryCatchVisitInvocationExpression(InvocationExpressionSyntax node,
            ForEachStatementSyntax containingForEach)
        {
            if (insideConditionalExpression) return null;
            var methodIdx = methodsToAddToCurrentType.Count;
            try
            {
                var expressionSyntax = TryVisitInvocationExpression(node, containingForEach);
                if (expressionSyntax != null)
                {
                    RewrittenLinqQueries++;
                    return expressionSyntax;
                }
            }
            catch (Exception ex) when (ex is InvalidCastException || ex is NotSupportedException)
            {
                methodsToAddToCurrentType.RemoveRange(methodIdx, methodsToAddToCurrentType.Count - methodIdx);
            }
            return null;
        }

        private ExpressionSyntax TryVisitInvocationExpression(InvocationExpressionSyntax node,
            ForEachStatementSyntax containingForEach)
        {
            if (!(node.Expression is MemberAccessExpressionSyntax memberAccess)) return null;

            var symbol = _semantic.GetSymbolInfo(memberAccess).Symbol as IMethodSymbol;
            var owner = node.AncestorsAndSelf().FirstOrDefault(x => x is MethodDeclarationSyntax);
            if (owner == null) return null;
            currentMethodIsStatic = _semantic.GetDeclaredSymbol((MethodDeclarationSyntax) owner).IsStatic;
            currentMethodName = ((MethodDeclarationSyntax) owner).Identifier.ValueText;
            currentMethodTypeParameters = ((MethodDeclarationSyntax) owner).TypeParameterList;
            currentMethodConstraintClauses = ((MethodDeclarationSyntax) owner).ConstraintClauses;

            if (IsSupportedMethod(node))
            {
                var chain = new List<LinqStep>
                {
                    new LinqStep(GetMethodFullName(node),
                        node.ArgumentList.Arguments.Select(x => x.Expression).ToList(), node)
                };

                var c = node;
                var lastNode = node;
                while (c.Expression is MemberAccessExpressionSyntax syntax)
                {
                    c = syntax.Expression as InvocationExpressionSyntax;
                    if (c != null && IsSupportedMethod(c))
                    {
                        chain.Add(new LinqStep(GetMethodFullName(c),
                            c.ArgumentList.Arguments.Select(x => x.Expression).ToList(), c));
                        lastNode = c;
                    }
                    else break;
                }

                if (containingForEach != null)
                {
                    chain.Insert(0,
                        new LinqStep(MethodNames.IEnumerableForEachMethod,
                            new[]
                            {
                                SyntaxFactory.SimpleLambdaExpression(
                                    SyntaxFactory.Parameter(containingForEach.Identifier), containingForEach.Statement)
                            })
                        {
                            Lambda = new Lambda(containingForEach.Statement,
                                new[]
                                {
                                    CreateParameter(containingForEach.Identifier,
                                        _semantic.GetTypeInfo(containingForEach.Type).ConvertedType)
                                })
                        });
                }

                if (!chain.Any(x => x.Arguments.Any(y => y is AnonymousFunctionExpressionSyntax))) return null;
                if (chain.Count == 1 && MethodNames.RootMethodsThatRequireYieldReturn.Contains(chain[0].MethodName)) return null;


                var flowsIn = new List<ISymbol>();
                var flowsOut = new List<ISymbol>();
                foreach (var item in chain)
                {
                    foreach (var arg in item.Arguments)
                    {
                        if (item.Lambda != null)
                        {
                            var dataFlow = _semantic.AnalyzeDataFlow(item.Lambda.Body);
                            var pName = item.Lambda.Parameters.Single().Identifier.ValueText;
                            foreach (var k in dataFlow.DataFlowsIn)
                            {
                                if (k.Name == pName) continue;
                                if (!flowsIn.Contains(k)) flowsIn.Add(k);
                            }

                            foreach (var k in dataFlow.DataFlowsOut)
                            {
                                if (k.Name == pName) continue;
                                if (!flowsOut.Contains(k)) flowsOut.Add(k);
                            }
                        }
                        else
                        {
                            var dataFlow = _semantic.AnalyzeDataFlow(arg);
                            foreach (var k in dataFlow.DataFlowsIn)
                                if (!flowsIn.Contains(k))
                                    flowsIn.Add(k);

                            foreach (var k in dataFlow.DataFlowsOut)
                                if (!flowsOut.Contains(k))
                                    flowsOut.Add(k);
                        }
                    }
                }

                currentFlow = flowsIn
                                  .Union(flowsOut)
                                  .Where(x => (x as IParameterSymbol)?.IsThis != true)
                                  .Select(x => CreateVariableCapture(x, flowsOut)) ??
                              Enumerable.Empty<VariableCapture>();

                var collection = ((MemberAccessExpressionSyntax) lastNode.Expression).Expression;

                if (IsAnonymousType(_semantic.GetTypeInfo(collection).Type)) return null;


                var semanticReturnType = _semantic.GetTypeInfo(node).Type;
                if (IsAnonymousType(semanticReturnType) ||
                    currentFlow.Any(x => IsAnonymousType(GetSymbolType(x.Symbol)))) return null;

                return TryRewrite(chain.First().MethodName, collection, semanticReturnType, chain, node)
                    .WithLeadingTrivia(((CSharpSyntaxNode) containingForEach ?? node).GetLeadingTrivia())
                    .WithTrailingTrivia(((CSharpSyntaxNode) containingForEach ?? node).GetTrailingTrivia());
            }

            return null;
        }

        private VariableCapture CreateVariableCapture(ISymbol symbol, IReadOnlyList<ISymbol> flowsOut)
        {
            var changes = flowsOut.Contains(symbol);
            if (changes) return new VariableCapture(symbol, changes);

            if (!(symbol is ILocalSymbol local)) return new VariableCapture(symbol, changes);
            var type = local.Type;

            if (!type.IsValueType) return new VariableCapture(symbol, changes);

            // Pass big structs by ref for performance.
            var size = GetStructSize(type);
            if (size > MaximumSizeForByValStruct)
                changes = true;
            return new VariableCapture(symbol, changes);
        }

        private const int MaximumSizeForByValStruct = 128 / 8; // eg. two longs, or two references

        private readonly Dictionary<ITypeSymbol, int> structSizeCache = new Dictionary<ITypeSymbol, int>();

        private int GetStructSize(ITypeSymbol type)
        {
            switch (type.SpecialType)
            {
                case SpecialType.System_Boolean: return 4;
                case SpecialType.System_Char: return 2;
                case SpecialType.System_SByte: return 1;
                case SpecialType.System_Byte: return 1;
                case SpecialType.System_Int16: return 2;
                case SpecialType.System_UInt16: return 2;
                case SpecialType.System_Int32: return 4;
                case SpecialType.System_UInt32: return 4;
                case SpecialType.System_Int64: return 8;
                case SpecialType.System_UInt64: return 8;
                case SpecialType.System_Single: return 4;
                case SpecialType.System_Double: return 8;
                case SpecialType.System_IntPtr: return 8;
                case SpecialType.System_UIntPtr: return 8;
                default: break;
            }

            if (structSizeCache.TryGetValue(type, out var size)) return size;


            size = 0;
            foreach (var item in type.GetMembers())
            {
                if (item.Kind != SymbolKind.Field || item.IsStatic) continue;

                var field = (IFieldSymbol) item;
                if (field.Type.IsValueType)
                {
                    if (field.Type.Equals(type))
                    {
                        // This is a primitive-like type, it "contains" itself.
                        // An unknown one, since we already ruled out some well know ones above.
                        size = 8;
                        break;
                    }

                    size += GetStructSize(field.Type);
                }
                else size += 64 / 8;
            }

            structSizeCache[type] = size;
            return size;
        }

        private bool IsSupportedMethod(InvocationExpressionSyntax invocation)
        {
            var name = GetMethodFullName(invocation);
            if (!IsSupportedMethod(name)) return false;
            if (invocation.ArgumentList.Arguments.Count == 0) return true;
            if (name == MethodNames.ElementAtMethod || name == MethodNames.ElementAtOrDefaultMethod || name == MethodNames.ContainsMethod) return true;

            // Passing things like .Select(Method) is not supported.
            return invocation.ArgumentList.Arguments.All(x => x.Expression is AnonymousFunctionExpressionSyntax);
        }

        private static bool IsSupportedMethod(string v)
        {
            if (v == null) return false;
            if (KnownMethods.Contains(v)) return true;
            if (!v.StartsWith("System.Collections.Generic.IEnumerable<")) return false;
            var k = v.Replace("<", "(");
            if (!k.Contains(">.Sum(") && !k.Contains(">.Average(") && !k.Contains(">.Min(") &&
                !k.Contains(">.Max(")) return false;
            if (k.Contains("TResult")) return false;
            if (v == "System.Collections.Generic.IEnumerable<TSource>.Min()") return false;
            if (v == "System.Collections.Generic.IEnumerable<TSource>.Max()") return false;
            return true;
        }

        private static StatementSyntax CreateStatement(ExpressionSyntax expression)
            => SyntaxFactory.ExpressionStatement(expression);

        public override SyntaxNode VisitMethodDeclaration(MethodDeclarationSyntax node)
        {
            if (HasNoRewriteAttribute(node.AttributeLists)) return node;
            var old = RewrittenLinqQueries;
            var k = base.VisitMethodDeclaration(node);
            if (RewrittenLinqQueries != old) RewrittenMethods++;
            return k;
        }

        private bool HasNoRewriteAttribute(SyntaxList<AttributeListSyntax> attributeLists)
        {
            return attributeLists.Any(x => x.Attributes.Any(y =>
            {
                var symbol = ((IMethodSymbol) _semantic.GetSymbolInfo(y).Symbol).ContainingType;
                return symbol.ToDisplayString() == "Shaman.Runtime.NoLinqRewriteAttribute";
            }));
        }

        private static bool IsAnonymousType(ITypeSymbol t) => t.ToDisplayString().Contains("anonymous type:");

        private static ThrowStatementSyntax CreateThrowException(string type, string message = null)
            => SyntaxFactory.ThrowStatement(SyntaxFactory.ObjectCreationExpression(SyntaxFactory.ParseTypeName(type),
                CreateArguments(message != null
                    ? new ExpressionSyntax[]
                    {
                        SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression,
                            SyntaxFactory.Literal(message))
                    }
                    : new ExpressionSyntax[] { }), null));

        private static ParameterSyntax GetLambdaParameter(Lambda lambda, int index)
            => lambda.Parameters[index];

        private ITypeSymbol GetLambdaReturnType(AnonymousFunctionExpressionSyntax lambda)
        {
            var symbol = ((INamedTypeSymbol) _semantic.GetTypeInfo(lambda).ConvertedType).TypeArguments.Last();
            return symbol;
        }

        private Lambda RenameSymbol(Lambda container, int argIndex, string newname)
        {
            var oldParameter = GetLambdaParameter(container, argIndex).Identifier.ValueText;
            //var oldsymbol = semantic.GetDeclaredSymbol(oldparameter);
            var tokensToRename = container.Body.DescendantNodesAndSelf().Where(x =>
            {
                var sem = _semantic.GetSymbolInfo(x).Symbol;
                return sem != null && (sem is ILocalSymbol || sem is IParameterSymbol) && sem.Name == oldParameter;
                //  if (sem.Symbol == oldsymbol) return true;
            });
            var syntax = SyntaxFactory.ParenthesizedLambdaExpression(
                CreateParameters(container.Parameters.Select((x, i) =>
                    i == argIndex ? SyntaxFactory.Parameter(SyntaxFactory.Identifier(newname)).WithType(x.Type) : x)),
                container.Body.ReplaceNodes(tokensToRename, (a, b) =>
                {
                    if (b is IdentifierNameSyntax ide) return ide.WithIdentifier(SyntaxFactory.Identifier(newname));
                    throw new NotImplementedException();
                }));
            return new Lambda(syntax);
            //var doc = project.GetDocument(docid);

            //var annot = new SyntaxAnnotation("RenamedLambda");
            //var annotated = container.WithAdditionalAnnotations(annot);
            //var root = project.GetDocument(docid).GetSyntaxRootAsync().Result.ReplaceNode(container, annotated).SyntaxTree;
            //var proj = project.GetDocument(docid).WithSyntaxRoot(root.GetRoot()).Project;
            //doc = proj.GetDocument(docid);
            //var syntaxTree = doc.GetSyntaxTreeAsync().Result;
            //var modifiedSemantic = proj.GetCompilationAsync().Result.GetSemanticModel(syntaxTree);
            //annotated = (AnonymousFunctionExpressionSyntax)doc.GetSyntaxRootAsync().Result.GetAnnotatedNodes(annot).First();
            //var parameter = GetLambdaParameter(annotated, 0);
            //var renamed = Renamer.RenameSymbolAsync(proj.Solution, modifiedSemantic.GetDeclaredSymbol(parameter), newname, null).Result;
            //annotated = (AnonymousFunctionExpressionSyntax)renamed.GetDocument(doc.Id).GetSyntaxRootAsync().Result.GetAnnotatedNodes(annot).First();
            //return annotated.WithoutAnnotations();
        }


        static ITypeSymbol GetSymbolType(VariableCapture x) => GetSymbolType(x.Symbol);

        private string GetMethodFullName(InvocationExpressionSyntax invocation)
        {
            var n = (_semantic.GetSymbolInfo(invocation.Expression).Symbol as IMethodSymbol)?.OriginalDefinition
                .ToDisplayString();
            const string iEnumerableOfTSource = "System.Collections.Generic.IEnumerable<TSource>";

            return n?.Replace("System.Collections.Generic.List<TSource>", iEnumerableOfTSource)
                .Replace("TSource[]", iEnumerableOfTSource);
        }

        const string ItemsName = "_linqitems";
        const string ItemName = "_linqitem";

        private class VariableCapture

        {
            public VariableCapture(ISymbol symbol, bool changes)
            {
                Symbol = symbol;
                Changes = changes;
            }

            public ISymbol Symbol { get; }
            public bool Changes { get; }
            public string Name => Symbol.Name;
        }

        delegate StatementSyntax AggregationDelegate(LinqStep invocation, ArgumentListSyntax arguments,
            ParameterSyntax param);

        private AggregationDelegate currentAggregation;

        private ExpressionSyntax RewriteAsLoop(TypeSyntax returnType, IEnumerable<StatementSyntax> prologue,
            IEnumerable<StatementSyntax> epilogue, ExpressionSyntax collection, List<LinqStep> chain,
            AggregationDelegate k, bool noAggregation = false,
            IEnumerable<Tuple<ParameterSyntax, ExpressionSyntax>> additionalParameters = null)
        {
            var old = currentAggregation;
            currentAggregation = k;

            var collectionType = _semantic.GetTypeInfo(collection).Type;
            var collectionItemType = GetItemType(collectionType);
            if (collectionItemType == null) throw new NotSupportedException();
            var collectionSemanticType = _semantic.GetTypeInfo(collection).Type;

            var parameters = new[] {CreateParameter(ItemsName, collectionSemanticType)}.Concat(
                currentFlow.Select(x => CreateParameter(x.Name, GetSymbolType(x.Symbol)).WithRef(x.Changes)));
            if (additionalParameters != null) parameters = parameters.Concat(additionalParameters.Select(x => x.Item1));

            var functionName = GetUniqueName(currentMethodName + "_ProceduralLinq");
            var arguments =
                CreateArguments(new[] {SyntaxFactory.Argument(SyntaxFactory.IdentifierName(ItemName))}.Concat(
                    currentFlow.Select(x =>
                        SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes))));

            var loopContent = CreateProcessingStep(chain, chain.Count - 1,
                SyntaxFactory.ParseTypeName(collectionItemType.ToDisplayString()), ItemName, arguments, noAggregation);

            StatementSyntax foreachStatement;
            if (collectionType.ToDisplayString().StartsWith("System.Collections.Generic.List<") ||
                collectionType is IArrayTypeSymbol)
            {
                foreachStatement = SyntaxFactory.ForStatement(
                    SyntaxFactory.VariableDeclaration(CreatePrimitiveType(SyntaxKind.IntKeyword),
                        CreateSeparatedList(SyntaxFactory.VariableDeclarator("_index")
                            .WithInitializer(SyntaxFactory.EqualsValueClause(
                                SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression,
                                    SyntaxFactory.Literal(0)))))), default,
                    SyntaxFactory.BinaryExpression(SyntaxKind.LessThanExpression,
                        SyntaxFactory.IdentifierName("_index"), GetCollectionCount(collection, false)),
                    CreateSeparatedList<ExpressionSyntax>(
                        SyntaxFactory.PostfixUnaryExpression(SyntaxKind.PostIncrementExpression,
                            SyntaxFactory.IdentifierName("_index"))),
                    SyntaxFactory.Block(new StatementSyntax[]
                    {
                        CreateLocalVariableDeclaration(ItemName,
                            SyntaxFactory.ElementAccessExpression(SyntaxFactory.IdentifierName(ItemsName),
                                SyntaxFactory.BracketedArgumentList(
                                    CreateSeparatedList(
                                        SyntaxFactory.Argument(SyntaxFactory.IdentifierName("_index"))))))
                    }.Union((loopContent as BlockSyntax)?.Statements ??
                            (IEnumerable<StatementSyntax>) new[] {loopContent})));
            }
            else
            {
                foreachStatement = SyntaxFactory.ForEachStatement(
                    SyntaxFactory.IdentifierName("var"),
                    ItemName,
                    SyntaxFactory.IdentifierName(ItemsName),
                    loopContent is BlockSyntax ? loopContent : SyntaxFactory.Block(loopContent));
            }


            var coreFunction = SyntaxFactory.MethodDeclaration(returnType, functionName)
                .WithParameterList(CreateParameters(parameters))
                .WithBody(SyntaxFactory.Block((collectionSemanticType.IsValueType
                    ? Enumerable.Empty<StatementSyntax>()
                    : new[]
                    {
                        SyntaxFactory.IfStatement(
                            SyntaxFactory.BinaryExpression(SyntaxKind.EqualsExpression,
                                SyntaxFactory.IdentifierName(ItemsName),
                                SyntaxFactory.LiteralExpression(SyntaxKind.NullLiteralExpression)),
                            CreateThrowException("System.ArgumentNullException"))
                    }).Concat(prologue).Concat(new[]
                {
                    foreachStatement
                }).Concat(epilogue)))
                .WithStatic(currentMethodIsStatic)
                .WithTypeParameterList(currentMethodTypeParameters)
                .WithConstraintClauses(currentMethodConstraintClauses)
                .NormalizeWhitespace();

            methodsToAddToCurrentType.Add(Tuple.Create(currentType, coreFunction));

            var args =
                new[] {SyntaxFactory.Argument((ExpressionSyntax) Visit(collection))}
                    .Concat(arguments.Arguments.Skip(1));
            if (additionalParameters != null)
                args = args.Concat(additionalParameters.Select(x => SyntaxFactory.Argument(x.Item2)));
            var inv = SyntaxFactory.InvocationExpression(GetMethodNameSyntaxWithCurrentTypeParameters(functionName),
                CreateArguments(args));

            currentAggregation = old;
            return inv;
        }

        private string GetUniqueName(string v)
        {
            for (var i = 1;; i++)
            {
                var name = v + i;
                if (methodsToAddToCurrentType.Any(x => x.Item2.Identifier.ValueText == name)) continue;
                return name;
            }
        }

        private static ITypeSymbol GetItemType(ITypeSymbol collectionType)
            => collectionType is IArrayTypeSymbol symbol
                ? symbol.ElementType
                : collectionType.AllInterfaces
                    .Concat(new[] {collectionType})
                    .OfType<INamedTypeSymbol>()
                    .FirstOrDefault(x => x.IsGenericType && x.ConstructUnboundGenericType().ToString() ==
                                         "System.Collections.Generic.IEnumerable<>")?
                    .TypeArguments.First();

        private static PredefinedTypeSyntax CreatePrimitiveType(SyntaxKind keyword) =>
            SyntaxFactory.PredefinedType(SyntaxFactory.Token(keyword));

        private readonly List<Tuple<TypeDeclarationSyntax, MethodDeclarationSyntax>> methodsToAddToCurrentType =
            new List<Tuple<TypeDeclarationSyntax, MethodDeclarationSyntax>>();

        private int lastId;
        private bool currentMethodIsStatic;
        private string currentMethodName;
        private IEnumerable<VariableCapture> currentFlow;

        public override SyntaxNode VisitStructDeclaration(StructDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        private SyntaxNode VisitTypeDeclaration(TypeDeclarationSyntax node)
        {
            if (HasNoRewriteAttribute(node.AttributeLists)) return node;

            var old = currentType;
            currentType = node;
            var changed = (TypeDeclarationSyntax) (node is ClassDeclarationSyntax
                ? base.VisitClassDeclaration((ClassDeclarationSyntax) node)
                : base.VisitStructDeclaration((StructDeclarationSyntax) node));
            if (methodsToAddToCurrentType.Count != 0)
            {
                var newMembers = methodsToAddToCurrentType.Where(x => x.Item1 == currentType).Select(x => x.Item2)
                    .ToArray();
                var withMethods = changed is ClassDeclarationSyntax syntax
                    ? (TypeDeclarationSyntax) syntax.AddMembers(newMembers)
                    : ((StructDeclarationSyntax) changed).AddMembers(newMembers);
                methodsToAddToCurrentType.RemoveAll(x => x.Item1 == currentType);
                currentType = old;
                return withMethods.NormalizeWhitespace();
            }

            currentType = old;
            return changed;
        }

        public override SyntaxNode VisitForEachStatement(ForEachStatementSyntax node)
            => TryVisitForEachStatement(node) ?? base.VisitForEachStatement(node);

        private SyntaxNode TryVisitForEachStatement(ForEachStatementSyntax node)
        {
            if (!(node.Expression is InvocationExpressionSyntax collection) || !IsSupportedMethod(collection))
                return base.VisitForEachStatement(node);

            var visitor = new CanRewrapForeachVisitor();
            visitor.Visit(node.Statement);
            if (visitor.Fail) return base.VisitForEachStatement(node);

            var k = TryCatchVisitInvocationExpression(collection, node);
            return k != null
                ? SyntaxFactory.ExpressionStatement(k)
                : base.VisitForEachStatement(node);
        }

        private ExpressionSyntax InlineOrCreateMethod(Lambda lambda, TypeSyntax returnType,
            ArgumentListSyntax arguments, ParameterSyntax param)
        {
            var p = GetLambdaParameter(lambda, 0).Identifier.ValueText;
            //var lambdaParameter = semantic.GetDeclaredSymbol(p);
            var currentFlow = _semantic.AnalyzeDataFlow(lambda.Body);
            var currentCaptures = currentFlow
                .DataFlowsOut
                .Union(currentFlow.DataFlowsIn)
                .Where(x => x.Name != p && (x as IParameterSymbol)?.IsThis != true)
                .Select(x => CreateVariableCapture(x, currentFlow.DataFlowsOut))
                .ToList();

            lambda = RenameSymbol(lambda, 0, param.Identifier.ValueText);
            return InlineOrCreateMethod(lambda.Body, returnType, param, currentCaptures);
        }

        private ExpressionSyntax InlineOrCreateMethod(CSharpSyntaxNode body, TypeSyntax returnType,
            ParameterSyntax param, IEnumerable<VariableCapture> captures)
        {
            var fn = GetUniqueName(currentMethodName + "_ProceduralLinqHelper");

            if (body is ExpressionSyntax syntax) return syntax;

            if (captures.Any(x => IsAnonymousType(GetSymbolType(x.Symbol)))) throw new NotSupportedException();
            if (returnType == null) throw new NotSupportedException(); // Anonymous type
            var method = SyntaxFactory.MethodDeclaration(returnType, fn)
                .WithParameterList(SyntaxFactory.ParameterList(SyntaxFactory.SeparatedList(
                    new[]
                    {
                        param
                    }.Union(captures.Select(x => CreateParameter(x.Name, GetSymbolType(x)).WithRef(x.Changes)))
                )))
                .WithBody(body as BlockSyntax ?? (body is StatementSyntax statementSyntax
                              ? SyntaxFactory.Block(statementSyntax)
                              : SyntaxFactory.Block(SyntaxFactory.ReturnStatement((ExpressionSyntax) body))))
                .WithStatic(currentMethodIsStatic)
                .WithTypeParameterList(currentMethodTypeParameters)
                .WithConstraintClauses(currentMethodConstraintClauses)
                .NormalizeWhitespace();

            methodsToAddToCurrentType.Add(Tuple.Create(currentType, method));
            return SyntaxFactory.InvocationExpression(GetMethodNameSyntaxWithCurrentTypeParameters(fn),
                CreateArguments(
                    new[] {SyntaxFactory.Argument(SyntaxFactory.IdentifierName(param.Identifier.ValueText))}.Union(
                        captures.Select(x =>
                            SyntaxFactory.Argument(SyntaxFactory.IdentifierName(x.Name)).WithRef(x.Changes)))));
        }

        private ExpressionSyntax GetMethodNameSyntaxWithCurrentTypeParameters(string fn)
            => (currentMethodTypeParameters?.Parameters.Count).GetValueOrDefault() != 0
                ? SyntaxFactory.GenericName(SyntaxFactory.Identifier(fn),
                    SyntaxFactory.TypeArgumentList(CreateSeparatedList(
                        currentMethodTypeParameters.Parameters.Select(x =>
                            SyntaxFactory.ParseTypeName(x.Identifier.ValueText)))))
                : (NameSyntax) SyntaxFactory.IdentifierName(fn);

        private TypeDeclarationSyntax currentType;
        private TypeParameterListSyntax currentMethodTypeParameters;
        private SyntaxList<TypeParameterConstraintClauseSyntax> currentMethodConstraintClauses;

        public override SyntaxNode VisitClassDeclaration(ClassDeclarationSyntax node)
            => VisitTypeDeclaration(node);

        private LocalDeclarationStatementSyntax CreateLocalVariableDeclaration(string name, ExpressionSyntax value)
            => SyntaxFactory.LocalDeclarationStatement(SyntaxFactory.VariableDeclaration(
                SyntaxFactory.IdentifierName("var"),
                CreateSeparatedList(SyntaxFactory.VariableDeclarator(name).WithInitializer(SyntaxFactory.EqualsValueClause(value)))));

        private static ITypeSymbol GetSymbolType(ISymbol x)
        {
            switch (x)
            {
                case ILocalSymbol local: return local.Type;
                case IParameterSymbol param: return param.Type;
                default: throw new NotImplementedException();
            }
        }

        private static SeparatedSyntaxList<T> CreateSeparatedList<T>(IEnumerable<T> items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items);

        private static SeparatedSyntaxList<T> CreateSeparatedList<T>(params T[] items) where T : SyntaxNode
            => SyntaxFactory.SeparatedList(items);

        private static ArgumentListSyntax CreateArguments(IEnumerable<ExpressionSyntax> items)
            => CreateArguments(items.Select(x => SyntaxFactory.Argument(x)));

        private static ArgumentListSyntax CreateArguments(params ExpressionSyntax[] items)
            => CreateArguments((IEnumerable<ExpressionSyntax>) items);

        private static ArgumentListSyntax CreateArguments(IEnumerable<ArgumentSyntax> items)
            => SyntaxFactory.ArgumentList(CreateSeparatedList(items));

        private static ParameterListSyntax CreateParameters(IEnumerable<ParameterSyntax> items)
            => SyntaxFactory.ParameterList(CreateSeparatedList(items));

        private static ParameterSyntax CreateParameter(SyntaxToken name, ITypeSymbol type)
            => SyntaxFactory.Parameter(name).WithType(SyntaxFactory.ParseTypeName(type.ToDisplayString()));

        private static ParameterSyntax CreateParameter(SyntaxToken name, TypeSyntax type)
            => SyntaxFactory.Parameter(name).WithType(type);

        private static ParameterSyntax CreateParameter(string name, ITypeSymbol type)
            => CreateParameter(SyntaxFactory.Identifier(name), type);

        private static ParameterSyntax CreateParameter(string name, TypeSyntax type)
            => CreateParameter(SyntaxFactory.Identifier(name), type);

        public Diagnostic CreateDiagnosticForException(Exception ex, string path)
        {
            while (ex.InnerException != null)
                ex = ex.InnerException;

            var message = "roslyn-linq-rewrite exception while processing '" + path + "', method " + currentMethodName +
                          ": " + ex.Message + " -- " + ex.StackTrace?.Replace("\n", "");
            return Diagnostic.Create("LQRW1001", "Compiler", new LiteralString(message), DiagnosticSeverity.Error,
                DiagnosticSeverity.Error, true, 0);
        }
    }
}