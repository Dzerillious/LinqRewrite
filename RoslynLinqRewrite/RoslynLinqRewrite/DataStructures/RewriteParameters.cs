using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.Extensions;
using Shaman.Roslyn.LinqRewrite.Services;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class RewriteParameters : IDisposable
    {
        public readonly RewriteService Rewrite;
        public readonly CodeCreationService Code;
        public readonly RewriteDataService Data;
        
        public ExpressionSyntax Collection;
        public List<LinqStep> Chain;
        public InvocationExpressionSyntax Node;
        
        public TypeSyntax ReturnType;
        public ExpressionSyntax ArraySize;
        
        public TypeSyntax LastIdentifierType;
        public IdentifierNameSyntax LastIdentifier;
        public (ExpressionSyntax min, ExpressionSyntax max)? ForBounds;
        
        private List<StatementSyntax> _preForBody = new List<StatementSyntax>();
        private List<StatementSyntax> _forBody = new List<StatementSyntax>();
        private List<StatementSyntax> _postForBody = new List<StatementSyntax>();
        
        public RewriteParameters()
        {
            Rewrite = RewriteService.Instance;
            Code = CodeCreationService.Instance;
            Data = RewriteDataService.Instance;
        }
        public void SetData(ExpressionSyntax collection, TypeSyntax returnType, ITypeSymbol semanticReturnType, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            _preForBody = new List<StatementSyntax>();
            _forBody = new List<StatementSyntax>();
            _postForBody = new List<StatementSyntax>();
            
            Collection = collection;
            ReturnType = returnType;
            Chain = chain;
            Node = node;
        }

        public void AddToPrefix(StatementSyntax syntax) => _preForBody.Add(syntax);
        public void AddToBody(StatementSyntax syntax) => _forBody.Add(syntax);
        public void AddToPostfix(StatementSyntax syntax) => _postForBody.Add(syntax);

        public IEnumerable<StatementSyntax> GetMethodBody()
        {
            if (ForBounds == null)
                return _preForBody.Concat(_postForBody);

            return _preForBody.Concat(new StatementSyntax[]
                {
                    Rewrite.GetForStatement("__i", ForBounds.Value.min, ForBounds.Value.max, SyntaxFactoryHelper.AggregateStatementSyntax(_forBody))
                })
                .Concat(_postForBody);
        }

        public void Dispose() => RewriteParametersHolder.ReturnParameters(this);
    }
}