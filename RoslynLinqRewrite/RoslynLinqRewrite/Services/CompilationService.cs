using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Shaman.Runtime;

namespace Shaman.Roslyn.LinqRewrite.Services
{
    public class CompilationService
    {
        private static CompilationService _instance;
        public static CompilationService Instance => _instance ??= new CompilationService();

        private readonly MsBuildService _msBuildService;
        private readonly PrintService _printService;

        public CompilationService()
        {
            _msBuildService = MsBuildService.Instance;
            _printService = PrintService.Instance;
        }

        public int FileRewrite(string[] args)
        {
            var file = args.FirstOrDefault(x => !x.StartsWith("--"));
            if (file == null) throw new ArgumentException("No input .cs was specified.");
            CompileExample(file, false);
            return 0;
        }

        public int BuildSolution(string[] args)
        {
            // MSBuild doesn't take CscToolPath into account when deciding whether to recompile. Rebuild always.
            var buildArgs = GetBuildArgs(args);
            var exitCode = 0;
            
            var infoFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.txt");
            Environment.SetEnvironmentVariable("ROSLYN_LINQ_REWRITE_OUT_STATISTICS_TO", infoFile);
            
            try
            {
                _msBuildService.RunMsbuild(buildArgs);
            }
            catch (ProcessException ex)
            {
                exitCode = ex.ExitCode;
            }

            if (_printService.PrintFile(infoFile))
                File.Delete(infoFile);

            return exitCode;
        }

        private List<object> GetBuildArgs(string[] args)
        {
            var buildArgs = new List<object>();
            if(!args.Any(x => x.StartsWith("/t:") || x.StartsWith("/target:")))
                buildArgs.Add(new ProcessUtils.RawCommandLineArgument("/t:Rebuild"));

            buildArgs.Add(new ProcessUtils.RawCommandLineArgument(
                $"/p:CscToolPath=\"{Path.GetDirectoryName(typeof(Program).GetTypeInfo().Assembly.Location)}\""));
            buildArgs.AddRange(args);

            return buildArgs;
        }

        public void CompileExample(string path, bool devPath = true)
        {
            var source = File.ReadAllText(devPath ? Path.Combine("../../Samples/", path) : path);
            var isScript = Path.GetExtension(path).Equals(".csx");
            
            var syntaxTree = CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(kind: isScript ? SourceCodeKind.Script : SourceCodeKind.Regular));
            var references = new[] {
                MetadataReference.CreateFromFile(typeof(int).GetTypeInfo().Assembly.Location), // mscorlib
                MetadataReference.CreateFromFile(typeof(Uri).GetTypeInfo().Assembly.Location), // System
                MetadataReference.CreateFromFile(typeof(Enumerable).GetTypeInfo().Assembly.Location), // System.Core
                };
            
            var compilation = isScript
                ? CSharpCompilation.CreateScriptCompilation("LinqRewriteExample", syntaxTree, references)
                : CSharpCompilation.Create("LinqRewriteExample", new[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var hasErrs = false;
            foreach (var item in compilation.GetDiagnostics())
            {
                if (item.Severity == DiagnosticSeverity.Error) hasErrs = true;
                _printService.PrintDiagnostic(item);
            }

            if (hasErrs) return;
            var rewriter = new LinqRewriter(compilation.GetSemanticModel(syntaxTree));
            var rewritten = rewriter.Visit(syntaxTree.GetRoot());

            foreach (var item in compilation.GetDiagnostics())
            {
                if (item.Severity == DiagnosticSeverity.Error) hasErrs = true;
                if (item.Severity == DiagnosticSeverity.Warning) continue;
                _printService.PrintDiagnostic(item);
            }
            if (hasErrs) return;
            Console.WriteLine(rewritten.ToString());
        }
    }
}