using System;
using System.IO;
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
            PrintLine($"roslyn-linq-rewrite {typeof(Program).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}");
            PrintLine($@"github.com/antiufo/roslyn-linq-rewrite

Usage:
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