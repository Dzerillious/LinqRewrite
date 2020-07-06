using System;

namespace LinqRewrite.Core
{
    [Flags]
    public enum RewriteOptions
    {
        None = 0,
        Unchecked = 1
    }
    
    public class LinqRewriteAttribute : Attribute
    {
        public LinqRewriteAttribute(RewriteOptions options = RewriteOptions.None)
        {
        }
    }
    
    public class NoLinqRewriteAttribute : Attribute
    {
        public NoLinqRewriteAttribute()
        {
        }
    }
}