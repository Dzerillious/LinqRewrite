using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.Services;

namespace Shaman.Roslyn.LinqRewrite.DataStructures
{
    public class RewriteParameters : IDisposable
    {
        public readonly RewriteService Rewrite;
        public readonly CodeCreationService Code;
        public readonly RewriteDataService Data;
        public readonly SyntaxInformationService Info;
        
        public ExpressionSyntax Collection;
        public List<LinqStep> Chain;
        public InvocationExpressionSyntax Node;
        public ITypeSymbol SemanticReturnType;
        
        public TypeSyntax ReturnType;
        public IdentifierNameSyntax LastIdentifier { get; set; }
        
        public RewriteParameters()
        {
            Rewrite = RewriteService.Instance;
            Code = CodeCreationService.Instance;
            Data = RewriteDataService.Instance;
            Info = SyntaxInformationService.Instance;
        }

        public void SetData(ExpressionSyntax collection, TypeSyntax returnType, ITypeSymbol semanticReturnType, List<LinqStep> chain, InvocationExpressionSyntax node)
        {
            Collection = collection;
            ReturnType = returnType;
            Chain = chain;
            Node = node;
            SemanticReturnType = semanticReturnType;
        }

        public void Dispose() => RewriteParametersHolder.ReturnParameters(this);
    }
}