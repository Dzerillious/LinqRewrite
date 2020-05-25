using System.Collections.Generic;
using LinqRewrite.DataStructures;

namespace LinqRewrite
{
    public static class RewriteParametersFactory
    {
        private static readonly object Lock = new object();
        private static readonly List<RewriteDesign> Capital = new List<RewriteDesign>();

        public static RewriteDesign BorrowParameters()
        {
            lock (Lock)
            {
                if (Capital.Count == 0) return new RewriteDesign();

                var count = Capital.Count;
                var last = Capital[count - 1];
                Capital.RemoveAt(count - 1);
                return last;
            }
        }

        public static void ReturnParameters(RewriteDesign design)
        {
            lock (Lock) Capital.Add(design);
        }
    }
}