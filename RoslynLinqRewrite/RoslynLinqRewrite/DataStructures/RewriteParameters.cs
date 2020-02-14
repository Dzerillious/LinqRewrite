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
        public SemanticModel Semantic => Data.Semantic;
        
        public ExpressionSyntax Collection;
        public List<LinqStep> Chain;
        public InvocationExpressionSyntax Node;
        
        public bool IsReversed;
        public TypeSyntax ReturnType;
        public ExpressionSyntax ResultSize;
        
        public ExpressionSyntax LastItem;
        
        private List<StatementSyntax> _preForBody = new List<StatementSyntax>();
        private List<StatementSyntax> _forBody = new List<StatementSyntax>();
        private List<StatementSyntax> _postForBody = new List<StatementSyntax>();
        
        public Func<List<StatementSyntax>, StatementSyntax> GetFor;
        public Func<List<StatementSyntax>, StatementSyntax> GetReverseFor;
        
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
            if (GetFor != null)
            {
                if (IsReversed) _preForBody.Add(GetReverseFor(_forBody));
                else _preForBody.Add(GetFor(_forBody));
            }
            _preForBody.AddRange(_postForBody);
            return _preForBody;
        }

        public void Dispose() => RewriteParametersHolder.ReturnParameters(this);
    }
}