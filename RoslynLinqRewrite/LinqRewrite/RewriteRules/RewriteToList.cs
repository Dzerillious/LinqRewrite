﻿using System;
using LinqRewrite.DataStructures;
using LinqRewrite.Extensions;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.RewriteRules
{
    public static class RewriteToList
    {
        public static void Rewrite(RewriteParameters p, RewrittenValueBridge[] args)
        {
            if (p.CurrentIterator == null) RewriteCollectionEnumeration.Rewrite(p, Array.Empty<RewrittenValueBridge>());

            var listVariable = p.GlobalVariable(p.ReturnType, New(p.ReturnType));
            p.ForAdd(listVariable.Access("Add").Invoke(p.LastValue));
            
            p.ResultAdd(Return(listVariable));
        }
    }
}