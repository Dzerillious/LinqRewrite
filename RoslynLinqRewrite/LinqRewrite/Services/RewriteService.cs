using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using Microsoft.CodeAnalysis;
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

        internal ExpressionSyntax GetMethodInvocationExpression(RewriteParameters p, IEnumerable<StatementSyntax> body)
        {
            var functionName = _code.GetUniqueName($"{_data.CurrentMethodName}_ProceduralLinq");
            var parameters = p.Data.CurrentMethodParams
                .Where(x => p.HasResultMethod || !x.Modifiers.Any()).ToArray();
            var coreFunction = GetCoreMethod(p.ReturnType, functionName, parameters, body);

            _data.MethodsToAddToCurrentType.Add(Tuple.Create(_data.CurrentType, coreFunction));

            var args = _data.CurrentMethodArguments.Where(x => p.HasResultMethod || x.RefKindKeyword.Text != "ref")
                .Select(x => (ArgumentBridge)x).ToArray();
            var inv = _code.CreateMethod(functionName).Invoke(args);

            return inv;
        }

        private static StatementSyntax GetBody(RewriteParameters p, List<IStatementSyntax> body) 
            => AggregateStatementSyntax(body.SelectMany(x => x.GetStatementSyntax(p)).Where(x => x != null).ToArray());
        public static ForStatementSyntax GetForStatement(RewriteParameters p, LocalVariable indexerVariable, ValueBridge max, ValueBridge increment, List<IStatementSyntax> loopContent)
            => ForStatement(
                null,
                default,
                indexerVariable.LThan(max),
                CreateSeparatedExpressionList(indexerVariable.AddAssign(increment)), 
                GetBody(p, loopContent));

        public static ForStatementSyntax GetReverseForStatement(RewriteParameters p, LocalVariable indexerVariable, ValueBridge min, ValueBridge increment, List<IStatementSyntax> loopContent)
            => ForStatement(
                null,
                default,
                indexerVariable.GeThan(min),
                CreateSeparatedExpressionList(indexerVariable.AddAssign(increment)), 
                GetBody(p, loopContent));

        public static StatementSyntax[] GetForEachStatement(RewriteParameters p, LocalVariable enumeratorVariable, List<IStatementSyntax> loopContent)
        {
            if (p.Unchecked)
                return new StatementSyntax[]
                {
                    While(enumeratorVariable.Access("MoveNext").Invoke(),
                        GetBody(p, loopContent)
                    ),
                    (StatementBridge) enumeratorVariable.Access("Dispose").Invoke()
                };
            return new StatementSyntax[]{
                TryF(Block(
                    (StatementBridge) While(enumeratorVariable.Access("MoveNext").Invoke(),
                        GetBody(p, loopContent)
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
            => MethodDeclaration(returnType, functionName)
                .WithParameterList(CreateParameters(parameters))
                .WithBody(Block(body))
                .WithStatic(_data.CurrentMethodIsStatic)
                .WithTypeParameterList(_data.CurrentMethodTypeParameters)
                .WithConstraintClauses(_data.CurrentMethodConstraintClauses)
                .NormalizeWhitespace();
    }
}