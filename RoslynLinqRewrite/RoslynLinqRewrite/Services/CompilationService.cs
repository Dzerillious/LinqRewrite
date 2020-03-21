using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.MSBuild;
using Shaman.Runtime;
using Project = Microsoft.CodeAnalysis.Project;

namespace LinqRewrite.Services
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

        public int BuildProject(string[] args)
        {
            // MSBuild doesn't take CscToolPath into account when deciding whether to recompile. Rebuild always.
            var buildArgs = GetBuildArgs(args);
            var exitCode = 0;
            
            try
            {
                CompileProject(buildArgs[1].ToString());
            }
            catch (ProcessException ex)
            {
                exitCode = ex.ExitCode;
            }

            return exitCode;
        }

        private List<object> GetBuildArgs(string[] args)
        {
            var buildArgs = new List<object>();
            // if(!args.Any(x => x.StartsWith("/t:") || x.StartsWith("/target:")))
            //     buildArgs.Add(new ProcessUtils.RawCommandLineArgument("/t:Rebuild"));

            buildArgs.Add(new ProcessUtils.RawCommandLineArgument(
                $"/p:CscToolPath=\"{Path.GetDirectoryName(typeof(Program).GetTypeInfo().Assembly.Location)}\""));
            buildArgs.AddRange(args);

            return buildArgs;
        }

        public void CompileProject(string path)
        {
            var msWorkspace = MSBuildWorkspace.Create();
            var p = msWorkspace.OpenProjectAsync(path);
            var project = p.Result;

            var syntaxTrees = new List<SyntaxTree>();
            var references = project.MetadataReferences;
            foreach (var document in project.Documents)
                syntaxTrees.Add(CSharpSyntaxTree.ParseText(File.ReadAllText(document.FilePath)));

            var compilationOptions = project.CompilationOptions.WithOptimizationLevel(OptimizationLevel.Release);
            var compilation = CSharpCompilation.Create(project.AssemblyName, syntaxTrees, references,
                (CSharpCompilationOptions)compilationOptions);
            
            if(PrintDiagnostics(compilation)) return;

            var rewrittenTrees = new List<SyntaxTree>();
            foreach (var syntaxTree in syntaxTrees)
            {
                var rewriter = new LinqRewriter(compilation.GetSemanticModel(syntaxTree));
                var rewritten = rewriter.Visit(syntaxTree.GetRoot());
                rewrittenTrees.Add(CSharpSyntaxTree.Create((CSharpSyntaxNode) rewritten));
            }

            compilation = CSharpCompilation.Create(project.AssemblyName, rewrittenTrees, references,
                (CSharpCompilationOptions)compilationOptions);

            if(PrintDiagnostics(compilation)) return;

            var outputDirectory = Path.GetDirectoryName(project.OutputFilePath);
            Directory.CreateDirectory(outputDirectory);
            foreach (var reference in references)
                File.Copy(reference.Display, Path.Combine(outputDirectory, Path.GetFileName(reference.Display)), true);
            compilation.Emit(project.OutputFilePath);
        }

        private bool PrintDiagnostics(CSharpCompilation compilation)
        {
            foreach (var item in compilation.GetDiagnostics())
            {
                _printService.PrintDiagnostic(item);
                if (item.Severity == DiagnosticSeverity.Error) return true;
            }
            return false;
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

            if(PrintDiagnostics(compilation)) return;
            var rewriter = new LinqRewriter(compilation.GetSemanticModel(syntaxTree));
            var rewritten = rewriter.Visit(syntaxTree.GetRoot());

            Console.WriteLine(rewritten.ToString());
        }
    }
}