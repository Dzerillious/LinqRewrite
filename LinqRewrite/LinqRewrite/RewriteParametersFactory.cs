﻿using System.Collections.Generic;
using LinqRewrite.DataStructures;

namespace LinqRewrite
{
    public static class RewriteParametersFactory
    {
        private static readonly object Lock = new object();
        private static readonly List<RewriteParameters> Capital = new List<RewriteParameters>();

        public static RewriteParameters BorrowParameters()
        {
            lock (Lock)
            {
                if (Capital.Count == 0) return new RewriteParameters();

                var count = Capital.Count;
                var last = Capital[count - 1];
                Capital.RemoveAt(count - 1);
                return last;
            }
        }

        public static void ReturnParameters(RewriteParameters parameters)
        {
            lock (Lock) Capital.Add(parameters);
        }
    }
}