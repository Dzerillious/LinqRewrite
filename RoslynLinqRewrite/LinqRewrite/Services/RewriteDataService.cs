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
        public List<ParameterSyntax> CurrentMethodParams { get; set; }
        public List<ArgumentSyntax> CurrentMethodArguments { get; set; }

        public SemanticModel Semantic { get; set; }
        public TypeDeclarationSyntax CurrentType { get; set; }
        public string CurrentMethodName { get; set; }
        public bool CurrentMethodIsStatic { get; set; }
        public bool CurrentMethodIsConditional { get; set; }
        public TypeParameterListSyntax CurrentMethodTypeParameters { get; set; }
        public SyntaxList<TypeParameterConstraintClauseSyntax> CurrentMethodConstraintClauses { get; set; }

        public readonly List<Tuple<TypeDeclarationSyntax, MethodDeclarationSyntax>> MethodsToAddToCurrentType =
            new List<Tuple<TypeDeclarationSyntax, MethodDeclarationSyntax>>();
    }
}