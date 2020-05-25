using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static LinqRewrite.Extensions.SyntaxFactoryHelper;

namespace LinqRewrite.Extensions
{
    public static class AssertionExtension
    {
        public static void InitialError(RewriteDesign design, string type, string message)
        {
            if (design.Error) return;
            design.InitialStatements.Clear();
            design.InitialStatements.Add(Throw(type, message));
            design.FinalStatements.Clear();
            design.ResultStatements.Clear();
            design.ResultIterators.Clear();
            design.Error = true;
        }

        public static void InitialErrorAdd(RewriteDesign design, StatementSyntax statement)
        {
            if (design.Error) return;
            design.InitialStatements.Clear();
            design.InitialStatements.Add(statement);
            design.FinalStatements.Clear();
            design.ResultStatements.Clear();
            design.ResultIterators.Clear();
            design.Error = true;
        }
        
        public static bool AssertResultSizeGreaterEqual(RewriteDesign design, ValueBridge smaller, bool preCheck = false)
            => AssertLesserEqual(design, smaller, design.GetResultSize(), design.ResultSize != null, preCheck);
        
        public static bool AssertResultSizeGreater(RewriteDesign design, ValueBridge smaller, bool preCheck = false)
            => AssertLesser(design, smaller, design.GetResultSize(), design.ResultSize != null, preCheck);
        
        public static bool AssertResultSizeLesserEqual(RewriteDesign design, ValueBridge bigger, bool preCheck = false)
            => AssertLesserEqual(design, design.GetResultSize(), bigger, design.ResultSize != null, preCheck);
        
        public static bool AssertResultSizeLesser(RewriteDesign design, ValueBridge bigger, bool preCheck = false)
            => AssertLesser(design, design.GetResultSize(), bigger, design.ResultSize != null, preCheck);

        public static bool AssertGreaterEqual(RewriteDesign design, ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesserEqual(design, smaller, bigger, initialCheck, preCheck);

        public static bool AssertGreater(RewriteDesign design, ValueBridge bigger, ValueBridge smaller, bool initialCheck = true, bool preCheck = false)
            => AssertLesser(design, smaller, bigger, initialCheck, preCheck);

        public static bool AssertLesserEqual(RewriteDesign design, ValueBridge smaller, ValueBridge bigger, bool initialCheck = true, bool preCheck = false)
        {
            if (design.Unchecked) return true;
            var biggerPass = ExpressionSimplifier.TryGetDouble(bigger, out var biggerD);
            var smallerPass = ExpressionSimplifier.TryGetDouble(smaller, out var smallerD);
            
            if (biggerPass && smallerPass)
            {
                if (smallerD <= biggerD) return true;
                InitialError(design, "System.InvalidOperationException", "Index out of range");
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) design.PreUseAdd(If(smaller > bigger, Throw("System.InvalidOperationException", "Index out of range")));
            else design.FinalAdd(If(smaller > bigger, Throw("System.InvalidOperationException", "Index out of range")));
            return true;
        }

        public static bool AssertLesser(RewriteDesign design, ValueBridge smaller, ValueBridge bigger, bool initialCheck = true, bool preCheck = false)
        {
            if (design.Unchecked) return true;
            var biggerPass = ExpressionSimplifier.TryGetDouble(bigger, out var biggerD);
            var smallerPass = ExpressionSimplifier.TryGetDouble(smaller, out var smallerD);
            
            if (biggerPass && smallerPass)
            {
                if (smallerD < biggerD) return true;
                InitialError(design, "System.InvalidOperationException", "Index out of range");
                return false;
            }
            if (preCheck) return true;
            if (initialCheck) design.PreUseAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            else design.FinalAdd(If(smaller >= bigger, Throw("System.InvalidOperationException", "Index out of range")));
            return true;
        }

        public static bool AssertNotNull(RewriteDesign design, ValueBridge notNull, bool preCheck = false)
        {
            if (design.Unchecked) return true;
            if (notNull.ToString() == "null")
            {
                InitialError(design, "System.InvalidOperationException", "Invalid null object");
                return false;
            }
            if (preCheck) return true;
            design.PreUseAdd(If(notNull.IsEqual(null), Throw("System.InvalidOperationException", "Invalid null object")));
            return true;
        }
    }
}