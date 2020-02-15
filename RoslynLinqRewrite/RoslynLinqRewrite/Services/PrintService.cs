﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.CodeAnalysis;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class PrintService
    {
        private static PrintService _instance;
        public static PrintService Instance => _instance ??= new PrintService();

        public int PrintHelp()
        {
            Console.WriteLine($"roslyn-linq-rewrite {typeof(Program).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}");
            Console.WriteLine(
                $@"github.com/antiufo/roslyn-linq-rewrite

Usage:
  roslyn-linq-rewrite <path-to-csproj> [msbuild-options]
  roslyn-linq-rewrite <path-to-sln> [msbuild-options]
  roslyn-linq-rewrite --show <path-to-cs>

If you prefer to call msbuild directly, use msbuild /t:Rebuild /p:CscToolPath=""{Path.GetDirectoryName(typeof(Program).Assembly.Location)}""
However, you won't see statistics about the rewritten methods.

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
            Console.WriteLine(item);
            Console.ResetColor();
        }

        public bool PrintFile(string path)
        {
            PrintLine();
            if (!File.Exists(path)) return false;
            
            PrintLine(File.ReadAllText(path));
            return true;
        }

        public void PrintLine(string line = "") => Console.WriteLine(line);
    }
}