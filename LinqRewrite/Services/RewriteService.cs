// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.Services
{
    public class RewriteService
    {
        private static RewriteService _instance;
        public static RewriteService Instance => _instance ??= new RewriteService();
        public Func<ExpressionSyntax, ExpressionSyntax> Visit { get; set; }

        private readonly CodeCreationService _code;

        public RewriteService()
        {
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

        internal ExpressionSyntax GetMethodInvocationExpression(RewriteDesign design, IEnumerable<StatementSyntax> body)
        {
            return null;
            //string functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            //var parameters = design.Data.CurrentMethodParams
            //    .Where(parameter => design.HasResultMethod || !parameter.Modifiers.Any()).ToArray();
            //var coreFunction = GetCoreMethod(design.ReturnType, functionName, parameters, body);

            //_data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));

            //var args = _data.CurrentMethodArguments.Where(argument => design.HasResultMethod || argument.RefKindKeyword.Text != "ref")
            //    .Select(argument => (ArgumentBridge)argument).ToArray();
            //var invvocation = _code.CreateMethod(functionName).Invoke(args);

            //return invvocation;
        }

        private static StatementSyntax GetBody(RewriteDesign design, List<IStatementSyntax> body) 
            => AggregateStatementSyntax(body.SelectMany(x => x.GetStatementSyntax(design)).Where(x => x != null).ToArray());
        public static ForStatementSyntax GetForStatement(RewriteDesign design, LocalVariable indexerVariable, ValueBridge max, ValueBridge increment, List<IStatementSyntax> loopContent)
            => ForStatement(
                null,
                default,
                indexerVariable.LThan(max),
                CreateSeparatedExpressionList(indexerVariable.AddAssign(increment)), 
                GetBody(design, loopContent));

        public static ForStatementSyntax GetReverseForStatement(RewriteDesign design, LocalVariable indexerVariable, ValueBridge min, ValueBridge increment, List<IStatementSyntax> loopContent)
            => ForStatement(
                null,
                default,
                indexerVariable.GeThan(min),
                CreateSeparatedExpressionList(indexerVariable.AddAssign(increment)), 
                GetBody(design, loopContent));

        public static StatementSyntax[] GetForEachStatement(RewriteDesign design, LocalVariable enumeratorVariable, List<IStatementSyntax> loopContent)
        {
            if (design.Unchecked)
                return new StatementSyntax[]
                {
                    While(enumeratorVariable.Access("MoveNext").Invoke(),
                        GetBody(design, loopContent)
                    ),
                    (StatementBridge) enumeratorVariable.Access("Dispose").Invoke()
                };
            return new StatementSyntax[]{
                TryF(Block(
                    (StatementBridge) While(enumeratorVariable.Access("MoveNext").Invoke(),
                        GetBody(design, loopContent)
                    )
                ),
                Block(
                    (StatementBridge) enumeratorVariable.Access("Dispose").Invoke()
                ))};
        }

        public MethodDeclarationSyntax GetCoreMethod(TypeSyntax returnType, 
            string functionName, 
            IEnumerable<ParameterSyntax> parameters,
            IEnumerable<StatementSyntax> body)
        {
            return null;
            //return MethodDeclaration(returnType, functionName)
            //    .WithParameterList(CreateParameters(parameters))
            //    .WithBody(Block(body))
            //    .WithStatic(_data.CurrentMethodIsStatic)
            //    .WithTypeParameterList(_data.CurrentMethodTypeParameters)
            //    .WithConstraintClauses(_data.CurrentMethodConstraintClauses);
        }
    }
}