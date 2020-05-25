using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.Extensions
{
    public static class AssertionExtension
    {
        public static void InitialError(RewriteParameters p, string type, string message)
        {
            if (p.Error) return;
            p.InitialStatements.Clear();
            p.InitialStatements.Add(Throw(type, message));
            p.FinalStatements.Clear();
            p.ResultStatements.Clear();
            p.ResultIterators.Clear();
            p.Error = true;
        }

        public static void InitialErrorAdd(RewriteParameters p, StatementSyntax statement)
        {
            if (p.Error) return;
            p.InitialStatements.Clear();
            p.InitialStatements.Add(statement);
            p.FinalStatements.Clear();
            p.ResultStatements.Clear();
            p.ResultIterators.Clear();
            p.Error = true;
        }
        
        public static bool AssertResultSizeGreaterEqual(RewriteParameters p, ValueBridge smaller, bool preCheck = false)
            => AssertLesserEqual(p, smaller, p.GetResultSize(), p.ResultSize != null, preCheck);
        
        public static bool AssertResultSizeGreater(RewriteParameters p, ValueBridge smaller, bool preCheck = false)
            => AssertLesser(p, smaller, p.GetResultSize(), p.ResultSize != null, preCheck);
        
        public static bool AssertResultSizeLesserEqual(RewriteParameters p, ValueBridge bigger, bool preCheck = false)
            => AssertLesserEqual(p, p.GetResultSize(), bigger, p.ResultSize != null, preCheck);
        
        public static bool AssertResultSizeLesser(RewriteParameters p, ValueBridge bigger, bool preCheck = false)
            => AssertLesser(p, p.GetResultSize(), bigger, p.ResultSize != null, preCheck);

        public static bool AssertGreaterEqual(RewriteParameters p, ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesserEqual(p, smaller, bigger, initialCheck, preCheck);

        public static bool AssertGreater(RewriteParameters p, ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesser(p, smaller, bigger, initialCheck, preCheck);

        public static bool AssertLesserEqual(RewriteParameters p, ValueBridge smaller, ValueBridge bigger, bool initialCheck = true, bool preCheck = false)
        {
            if (p.Unchecked) return true;
            var biggerPass = ExpressionSimplifier.TryGetDouble(bigger, out var biggerD);
            var smallerPass = ExpressionSimplifier.TryGetDouble(smaller, out var smallerD);
            
            if (biggerPass && smallerPass)
            {
                if (smallerD <= biggerD) return true;
                InitialError(p, "System.InvalidOperationException", "Index out of range");
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) p.PreUseAdd(If(smaller > bigger, Throw("System.InvalidOperationException", "Index out of range")));
            else p.FinalAdd(If(smaller > bigger, Throw("System.InvalidOperationException", "Index out of range")));
            return true;
        }

        public static bool AssertLesser(RewriteParameters p, ValueBridge smaller, ValueBridge bigger, bool initialCheck = true, bool preCheck = false)
        {
            if (p.Unchecked) return true;
            var biggerPass = ExpressionSimplifier.TryGetDouble(bigger, out var biggerD);
            var smallerPass = ExpressionSimplifier.TryGetDouble(smaller, out var smallerD);
            
            if (biggerPass && smallerPass)
            {
                if (smallerD < biggerD) return true;
                InitialError(p, "System.InvalidOperationException", "Index out of range");
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) p.PreUseAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            else p.FinalAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            return true;
        }

        public static bool AssertNotNull(RewriteParameters p, ValueBridge notNull, bool preCheck = false)
        {
            if (p.Unchecked) return true;
            if (notNull.ToString() == "null")
            {
                InitialError(p, "System.InvalidOperationException", "Invalid null object");
                return false;
            }
            if (preCheck) return true;
            p.PreUseAdd(If(notNull.IsEqual(null), Throw("System.InvalidOperationException", "Invalid null object")));
            return true;
        }
    }
}