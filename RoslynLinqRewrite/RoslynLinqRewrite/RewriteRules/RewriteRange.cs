using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Shaman.Roslyn.LinqRewrite.DataStructures;
using Shaman.Roslyn.LinqRewrite.Extensions;

namespace Shaman.Roslyn.LinqRewrite.RewriteRules
{
    public static class RewriteRange
    {
        public static void Rewrite(RewriteParameters p, List<StatementSyntax> statements)
        {
            var last = p.Chain.Last();
            if (last.MethodName != Constants.RangeMethod) throw new InvalidOperationException("Enumerable.Range should be first expression.");
            
            statements.Add(SyntaxFactoryHelper.LocalVariableCreation(
                SyntaxKind.IntKeyword, "_sum", 
                    SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression,
                        p.Chain[1].Arguments[0], p.Chain[1].Arguments[1])
                ));
            statements.Add(p.Rewrite.GetForStatement(p.Chain[1].Arguments[0], SyntaxFactory.IdentifierName("_sum"), SyntaxFactory.Block()));
            p.LastIdentifier = SyntaxFactory.IdentifierName("_index");

            // SyntaxFactory.Block(new StatementSyntax[]
            // {
            //     _code.CreateLocalVariableDeclaration(Constants.ItemName,
            //         SyntaxFactory.ElementAccessExpression(
            //             SyntaxFactory.IdentifierName(Constants.ItemsName),
            //             SyntaxFactory.BracketedArgumentList(_code.CreateSeparatedList(SyntaxFactory.Argument(SyntaxFactory.IdentifierName("_index"))))))
            // }
        }
    }
}