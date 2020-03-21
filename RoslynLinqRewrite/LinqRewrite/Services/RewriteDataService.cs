using System;
using System.Collections.Generic;
using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.Services
{
    public class RewriteDataService
    {
        private static RewriteDataService _instance;
        public static RewriteDataService Instance => _instance ??= new RewriteDataService();
        
        public SemanticModel Semantic;
        
        public IEnumerable<VariableCapture> CurrentFlow;
        public TypeDeclarationSyntax CurrentType;
        public string CurrentMethodName;
        public bool CurrentMethodIsStatic;
        public TypeParameterListSyntax CurrentMethodTypeParameters;
        public SyntaxList<TypeParameterConstraintClauseSyntax> CurrentMethodConstraintClauses;
        
        public readonly List<Tuple<TypeDeclarationSyntax, MethodDeclarationSyntax>> MethodsToAddToCurrentType =
            new List<Tuple<TypeDeclarationSyntax, MethodDeclarationSyntax>>();
    }
}