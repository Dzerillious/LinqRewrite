using System;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace LinqRewrite.Services
{
    public class PrintService
    {
        private static PrintService _instance;
        public static PrintService Instance => _instance ??= new PrintService();

        public int PrintHelp()
        {
            PrintLine($"LinqRewrite {typeof(Program).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}");
            PrintLine(@"https://gitlab.nesad.fit.vutbr.cz/xseryd00/roslyn-linq-rewrite

Improved version of roslyn-linq-rewrite (https://github.com/antiufo/roslyn-linq-rewrite). This tool rewrites LINQ queries in C# code using plain procedural code, minimizing allocations and dynamic dispatch, inlining lambdas, optimizing simple math expressions and using known information for optimization. It has two run modes. First to compile rewritten code into .dll or .exe, second to rewrite the code and save it into a specified folder. For proper behavior install NuGet package LinqRewrite.Core into project which you are rewriting.
    For basic queries which can be rewritten to simple expression (ArraySource.Select(x => x + 5).Last()) was speedup 50000x, for aggregations and simple changes of iteration was speedup several times and for queries over IEnumerable and with too few provided information was speedup up to 30% of System.Linq. There is no runtime overhead of compilation.
    For rewrite is needed to install NuGet package LinqRewrite.Core. Repository of rewriting program https://gitlab.nesad.fit.vutbr.cz/xseryd00/roslyn-linq-rewrite/.

Usage:
  roslyn-linq-rewrite --help

  roslyn-linq-rewrite <path-to-csproj>
  roslyn-linq-rewrite <path-to-sln>
  roslyn-linq-rewrite <path-to-cs>
  roslyn-linq-rewrite <path-to-csx>

  roslyn-linq-rewrite <path-to-csproj> --rewriteDst=""Folder where to rewrite""
  roslyn-linq-rewrite <path-to-sln> --rewriteDst=""Folder where to rewrite""
  roslyn-linq-rewrite <path-to-cs> --rewriteDst=""Folder where to rewrite""
  roslyn-linq-rewrite <path-to-csx> --rewriteDst=""Folder where to rewrite""


");
            return 0;
        }

        public void PrintDiagnostic(Diagnostic item)
        {
            switch (item.Severity)
            {
                case DiagnosticSeverity.Hidden: return;
                case DiagnosticSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case DiagnosticSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            PrintLine(item.ToString());
            Console.ResetColor();
        }

        public void PrintLine(string line = "") => Console.WriteLine(line);
    }
}