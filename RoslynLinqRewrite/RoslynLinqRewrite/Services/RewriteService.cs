using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SymbolExtensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.Services
{
    public class RewriteService
    {
        private static RewriteService _instance;
        public static RewriteService Instance => _instance ??= new RewriteService();
        public Func<ExpressionSyntax, ExpressionSyntax> Visit { get; set; }

        private readonly RewriteDataService _data;
        private readonly CodeCreationService _code;

        public RewriteService()
        {
            _data = RewriteDataService.Instance;
            _code = CodeCreationService.Instance;
        }

        public class ParameterComparer : IEqualityComparer<ParameterSyntax>
        {
            public bool Equals(ParameterSyntax x, ParameterSyntax y)
            {
                if (x is null || y is null) return false;
                return x.Identifier.Value.Equals(y.Identifier.Value);
            }

            public int GetHashCode(ParameterSyntax param)
            {
                return param.Identifier.Value.GetHashCode();
            }
        }

        internal ExpressionSyntax GetCollectionInvocationExpression(RewriteParameters p, IEnumerable<StatementSyntax> body)
        {
            var parameters = _data.CurrentFlow
                .Select(x => CreateParameter(x.Name, GetSymbolType(x.Symbol)).WithRef(x.Changes))
                .Distinct(new ParameterComparer());
           
            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = CreateArguments( _data.CurrentFlow
                .GroupBy(x => x.Symbol, (x, y) => new VariableCapture(x, y.Any(z => z.Changes)))
                .Select(x => Argument(x.Name).WithRef(x.Changes)));

            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = new[] {Argument(p.FirstCollection)}.Concat(arguments.Arguments.Skip(1));
            
            var inv = InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), CreateArguments(args));

            return inv;
        }
        
        internal ExpressionSyntax GetInvocationExpression(RewriteParameters p, IEnumerable<StatementSyntax> body)
        {
            var parameters = _data.CurrentFlow.Select(x => CreateParameter(x.Name, GetSymbolType(x.Symbol)).WithRef(x.Changes))
                .Distinct(new ParameterComparer());
           
            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var arguments = CreateArguments(
                _data.CurrentFlow.Select(x => Argument(x.Name).WithRef(x.Changes)));

            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));
            var args = arguments.Arguments;
            
            var inv = InvocationExpression(
                _code.CreateMethodNameSyntaxWithCurrentTypeParameters(functionName), CreateArguments(args));

            return inv;
        }


        private StatementSyntax GetBody(RewriteParameters p, List<IStatementSyntax> body) => AggregateStatementSyntax(body.Select(x => x.GetStatementSyntax(p)).ToArray());
        public ForStatementSyntax GetForStatement(RewriteParameters p, LocalVariable indexerVariable, ValueBridge max, List<IStatementSyntax> loopContent)
            => ForStatement(
                null,
                default,
                IdentifierName(indexerVariable).LThan(max),
                indexerVariable.SeparatedPostIncrement(),
                GetBody(p, loopContent));

        public ForStatementSyntax GetReverseForStatement(RewriteParameters p, LocalVariable indexerVariable, ValueBridge min, List<IStatementSyntax> loopContent)
            => ForStatement(
                null,
                default,
                indexerVariable.GeThan(min),
                indexerVariable.SeparatedPostDecrement(),
                GetBody(p, loopContent));

        public StatementSyntax GetForEachStatement(RewriteParameters p, LocalVariable enumeratorVariable, ExpressionSyntax collection, List<IStatementSyntax> loopContent) 
            => TryF(Block(
                    (StatementBridge)enumeratorVariable.Assign(collection.Access("GetEnumerator").Invoke()),
                    While(enumeratorVariable.Access("MoveNext").Invoke(),
                        GetBody(p, loopContent)
                    )
                ),
                Block(
                    (StatementBridge)enumeratorVariable.Access("Dispose").Invoke()
                ));

        public MethodDeclarationSyntax GetCoreMethod(TypeSyntax returnType, 
            string functionName, 
            IEnumerable<ParameterSyntax> parameters,
            IEnumerable<StatementSyntax> body)
            => MethodDeclaration(returnType, functionName)
                .WithParameterList(CreateParameters(parameters))
                .WithBody(Block(body))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();
    }
}