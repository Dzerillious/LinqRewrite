using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using LinqRewrite.DataStructures;
using MathNet.Symbolics;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace LinqRewrite.Extensions
{
    public static class ExpressionSimplifier
    {
        public static string StringSimplify(string expression)
        {
            var substitutions = new Dictionary<string, string>();
            var reverseSubstitutions = new Dictionary<string, string>();

            var source = expression;
            var indexer = 0;

            for (var i = 0; i < source.Length; i++)
                if (source[i] == '/') return source;
            
            source = SubstituteCallsAsVariables(substitutions, reverseSubstitutions, source, ref indexer, out var substitutedCount);
            source = SubstituteMathCalls(substitutions, reverseSubstitutions, source, out var substitutedMath);
            source = SubstituteAsVariables(substitutions, reverseSubstitutions, source, ref indexer, ref substitutedCount);
            
            var parsed = Infix.TryParse(source);
            if (parsed != null) source = Infix.Format(Algebraic.Expand(parsed.Value));

            for (var i = 0; i < substitutedCount; i++)
                source = RevertSubstitutions(reverseSubstitutions, source);
            if (substitutedMath) source = RevertMathSubstitutions(reverseSubstitutions, source);
            return source;
        }

        public static string SimplifyString(ExpressionSyntax expression)
            => StringSimplify(expression.ToString());

        public static bool TryGetInt(ValueBridge expression, out int result)
        {
            if (expression == null)
            {
                result = 0;
                return false;
            }
            var str = StringSimplify(expression.ToString());
            var success = int.TryParse(str, out result);
            return success;
        }

        public static bool TryGetDouble(ValueBridge expression, out double result)
        {
            if (expression == null)
            {
                result = 0;
                return false;
            }
            var str = StringSimplify(expression.ToString());
            var success = double.TryParse(str, out result);
            return success;
        }

        public static ValueBridge SimplifySubstitute(ValueBridge value, VariableBridge substituted, ValueBridge substitute)
        {
            var str = value.ToString();
            str = StringSimplify(str.Replace(substituted.Name, SimplifyString(substitute)));
            return SyntaxFactory.ParseExpression(str);
        }

        public static ValueBridge Substitute(ValueBridge value, VariableBridge substituted, ValueBridge changedFor)
        {
            var str = value.ToString();
            str = str.Replace(substituted.Name, changedFor.ToString());
            return SyntaxFactory.ParseExpression(str);
        }

        public static ValueBridge Simplify(this TypedValueBridge expression)
        {
            if (expression == null) return null;
            return SyntaxFactory.ParenthesizedExpression(SyntaxFactory.ParseExpression(SimplifyString(expression)));
        }

        public static ValueBridge Simplify(this ValueBridge expression)
        {
            if (expression == null) return null;
            return SyntaxFactory.ParenthesizedExpression(SyntaxFactory.ParseExpression(SimplifyString(expression)));
        }

        private static string SubstituteMathCalls(Dictionary<string, string> substitutions, Dictionary<string, string> reverseSubstitutions,
            string source, out bool substituted)
        {
            substituted = false;
            var matches = Regex.Matches(source, "Math\\.(\\w+\\()");
            if (matches.Count == 0) return source;
            substituted = true;
            
            var stringBuilder = new StringBuilder();
            var offset = 0;
            foreach (Match match in matches)
            {
                var name = match.Groups[1].Value;
                var variable = match.Groups[1].Value.ToLower();
                
                substitutions[name] = variable;
                reverseSubstitutions[variable] = name;
                
                stringBuilder.Append(source.Substring(offset, match.Index - offset));
                stringBuilder.Append(variable);
                offset = match.Index + match.Length;
            }
            stringBuilder.Append(source.Substring(offset, source.Length - offset));
            return stringBuilder.ToString();
        }
        
        private static readonly Regex VariableRegex = new Regex("[_a-zA-Z][_a-zA-Z0-9\\.]*");
        private static string SubstituteAsVariables(Dictionary<string, string> substitutions, Dictionary<string, string> reverseSubstitutions,
            string source, ref int indexer, ref int substitutedCount)
        {
            var matches = VariableRegex.Matches(source);
            if (matches.Count == 0) return source;
            substitutedCount++;
            
            var stringBuilder = new StringBuilder();
            var offset = 0;
            foreach (Match match in matches)
            {
                string variable = substitutions.TryGetValue(match.Value, out string found)
                    ? found : "xxx" + indexer++;

                substitutions[match.Value] = variable;
                reverseSubstitutions[variable] = match.Value;
                
                stringBuilder.Append(source.Substring(offset, match.Index - offset));
                stringBuilder.Append(variable);
                offset = match.Index + match.Length;
            }
            stringBuilder.Append(source.Substring(offset, source.Length - offset));
            return stringBuilder.ToString();
        }
        
        private static string SubstituteCallsAsVariables(Dictionary<string, string> substitutions, Dictionary<string, string> reverseSubstitutions,
            string source, ref int indexer, out int substitutedCount)
        {
            substitutedCount = 0;
            var matches = FindCalls(source);
            if (matches.Count == 0) return source;
            substitutedCount = 1;
            
            var stringBuilder = new StringBuilder();
            var offset = 0;
            foreach (var (from, count) in matches)
            {
                string value = source.Substring(from, count);
                string variable = substitutions.TryGetValue(value, out string found)
                    ? found : "xxx" + indexer++;

                substitutions[value] = variable;
                reverseSubstitutions[variable] = value;
                
                stringBuilder.Append(source.Substring(offset, from - offset));
                stringBuilder.Append(variable);
                offset = from + count;
            }
            stringBuilder.Append(source.Substring(offset, source.Length - offset));
            return stringBuilder.ToString();
        }

        private static List<(int from, int count)> FindCalls(string source)
        {
            var bracketsIndex = 0;
            var bracketsCount = 0;
            var squareBracketsCount = 0;
            var result = new List<(int from, int count)>();
            var preWord = new StringBuilder();
            for (var i = 0; i < source.Length; i++)
            {
                switch (source[i])
                {
                    case '(':
                    {
                        var preString = preWord.ToString();
                        if (preString.StartsWith("Math.") && !preString.StartsWith("Math.Pow")) continue;
                        if (preWord.Length != 0 && bracketsCount == 0)
                        {
                            bracketsIndex = i;
                            bracketsCount++;
                        }
                        if (bracketsCount != 0 || squareBracketsCount != 0) bracketsCount++;
                        break;
                    }
                    case ')' when bracketsCount > 0:
                    {
                        bracketsCount--;
                        if (bracketsCount == 0 && squareBracketsCount == 0) result.Add((bracketsIndex, i - bracketsIndex + 1));
                        break;
                    }
                    case '[':
                    {
                        if (preWord.Length != 0 && squareBracketsCount == 0) bracketsIndex = i;
                        squareBracketsCount++;
                        break;
                    }
                    case ']' when squareBracketsCount > 0:
                    {
                        squareBracketsCount--;
                        if (bracketsCount == 0 && squareBracketsCount == 0) result.Add((bracketsIndex, i - bracketsIndex + 1));
                        break;
                    }
                }

                if ((~63 & source[i]) == 64 && (31 & source[i]) <= 26 || source[i] == 95 || source[i] == 46)
                    preWord.Append(source[i]);
                else preWord.Clear();
            }
            return result;
        }

        private static string RevertSubstitutions(Dictionary<string, string> reverseSubstitutions, string source)
        {
            var matches = new Regex("xxx\\d+").Matches(source);
            if (matches.Count == 0) return source;
            
            var stringBuilder = new StringBuilder();
            var offset = 0;
            foreach (Match match in matches)
            {
                reverseSubstitutions.TryGetValue(match.Value, out var found);

                stringBuilder.Append(source.Substring(offset, match.Index - offset));
                stringBuilder.Append(found);
                offset = match.Index + match.Length;
            }
            stringBuilder.Append(source.Substring(offset, source.Length - offset));
            return stringBuilder.ToString();
        }

        private static string RevertMathSubstitutions(Dictionary<string, string> reverseSubstitutions, string source)
        {
            var matches = new Regex("\\w+\\(").Matches(source);
            if (matches.Count == 0) return source;
            
            var stringBuilder = new StringBuilder();
            var offset = 0;
            foreach (Match match in matches)
            {
                if (!reverseSubstitutions.TryGetValue(match.Value, out var found))
                    continue;

                stringBuilder.Append(source.Substring(offset, match.Index - offset));
                stringBuilder.Append("Math." + CultureInfo.CurrentCulture.TextInfo.ToTitleCase(found.ToLower()));
                offset = match.Index + match.Length;
            }
            stringBuilder.Append(source.Substring(offset, source.Length - offset));
            return stringBuilder.ToString();
        }
    }
}