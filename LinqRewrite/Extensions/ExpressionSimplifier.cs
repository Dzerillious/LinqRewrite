using LinqRewrite.DataStructures;
using Microsoft.CodeAnalysis.CSharp;

namespace LinqRewrite.Extensions
{
    public static class ExpressionSimplifier
    {
        public static bool TryGetInt(ValueBridge expression, out int result)
        {
            if (expression == null)
            {
                result = 0;
                return false;
            }
            var str = expression.ToString();
            bool success = int.TryParse(str, out result);
            return success;
        }

        public static bool TryGetDouble(ValueBridge expression, out double result)
        {
            if (expression == null)
            {
                result = 0;
                return false;
            }
            var str = expression.ToString();
            bool success = double.TryParse(str, out result);
            return success;
        }

        public static ValueBridge Substitute(ValueBridge value, VariableBridge substituted, ValueBridge changedFor)
        {
            var str = value.ToString();
            str = str.Replace(substituted.Name, changedFor.ToString());
            return SyntaxFactory.ParseExpression(str);
        }
    }
}