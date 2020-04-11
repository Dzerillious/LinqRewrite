using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using LinqRewrite.Core;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.MSBuild;
using Shaman.Runtime;

namespace LinqRewrite.Services
{
    public class CompilationService
    {
        private static CompilationService _instance;
        public static CompilationService Instance => _instance ??= new CompilationService();
        private readonly PrintService _printService;

        public CompilationService()
        {
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
            var buildArgs = GetBuildArgs(args);
            try
            {
                CompileProject(buildArgs[1].ToString());
            }
            catch (ProcessException ex)
            {
                return ex.ExitCode;
            }
            return 0;
        }

        public int RewriteProject(string[] args)
        {
            var buildArgs = GetBuildArgs(args);
            try
            {
                var dstDir = args.FirstOrDefault(x => x.StartsWith("--"))?.Replace("--reProj=", "");
                if (args.First().EndsWith(".sln"))
                    RewriteSolution(buildArgs[1].ToString(), dstDir);
                else if (args.First().EndsWith(".csproj"))
                    RewriteProject(buildArgs[1].ToString(), dstDir);
            }
            catch (ProcessException ex)
            {
                return ex.ExitCode;
            }
            return 0;
        }

        private static List<object> GetBuildArgs(string[] args)
        {
            var buildArgs = new List<object>();
            // if(!args.Any(x => x.StartsWith("/t:") || x.StartsWith("/target:")))
            //     buildArgs.Add(new ProcessUtils.RawCommandLineArgument("/t:Rebuild"));

            buildArgs.Add(new ProcessUtils.RawCommandLineArgument(
                $"/p:CscToolPath=\"{Path.GetDirectoryName(typeof(Program).GetTypeInfo().Assembly.Location)}\""));
            buildArgs.AddRange(args);

            return buildArgs;
        }

        public void RewriteProject(string path, string dstDir)
        {
            MSBuildLocator.RegisterDefaults();
            var msWorkspace = MSBuildWorkspace.Create();
            var project = msWorkspace.OpenProjectAsync(path).Result;
            RewriteProject(project, dstDir);
        }

        public void RewriteSolution(string path, string dstDir)
        {
            MSBuildLocator.RegisterDefaults();
            var msWorkspace = MSBuildWorkspace.Create();
            var solution = msWorkspace.OpenSolutionAsync(path).Result;
            solution.Projects.ForEach(x => RewriteProject(x, dstDir));
        }

        public void RewriteProject(Project project, string dstDir)
        {
            var documents = project.Documents.ToArray();
            var syntaxTrees = project.Documents.Select(document => CSharpSyntaxTree.ParseText(File.ReadAllText(document.FilePath))).ToList();

            var compilation = CompileRelease(project, syntaxTrees);
            if(PrintDiagnostics(compilation)) return;

            var projectDir =  Path.GetDirectoryName(project.FilePath);
            CopyFile(project.FilePath, projectDir, dstDir);

            var rewrittenTrees = GetRewrittenTrees(syntaxTrees, compilation);
            for (var i = 0; i < rewrittenTrees.Count; i++)
                WriteFile(documents[i].FilePath, rewrittenTrees[i].ToString(), projectDir, dstDir);
            
            Directory.CreateDirectory(dstDir);
            foreach (var document in project.AdditionalDocuments)
                CopyFile(document.FilePath, projectDir, dstDir);
        }

        private static CSharpCompilation CompileRelease(Project project, List<SyntaxTree> syntaxTrees)
        {
            var references = project.MetadataReferences;
            var compilationOptions = project.CompilationOptions.WithOptimizationLevel(OptimizationLevel.Release);
            
            return CSharpCompilation.Create(project.AssemblyName, syntaxTrees, references,
                    (CSharpCompilationOptions)compilationOptions);
        }

        private static void WriteFile(string fileName, string content, string projectDir, string dstDir)
        {
            var writePath = fileName.Replace(projectDir, dstDir);
            Directory.CreateDirectory(Path.GetDirectoryName(writePath));
            File.WriteAllText(writePath, content);
        }

        private static void CopyFile(string fileName, string projectDir, string dstDir)
        {
            var copiedPath = fileName.Replace(projectDir, dstDir);
            Directory.CreateDirectory(Path.GetDirectoryName(copiedPath));
            File.Copy(fileName, copiedPath, true);
        }

        public void CompileProject(string path)
        {
            var msWorkspace = MSBuildWorkspace.Create();
            var p = msWorkspace.OpenProjectAsync(path);
            var project = p.Result;
            var syntaxTrees = project.Documents.Select(document => CSharpSyntaxTree.ParseText(File.ReadAllText(document.FilePath))).ToList();

            var compilation = CompileRelease(project, syntaxTrees);
            if(PrintDiagnostics(compilation)) return;
            syntaxTrees = GetRewrittenTrees(syntaxTrees, compilation);

            compilation = CompileRelease(project, syntaxTrees);
            if(PrintDiagnostics(compilation)) return;

            var outputDirectory = Path.GetDirectoryName(project.OutputFilePath);
            Directory.CreateDirectory(outputDirectory);
            foreach (var reference in project.MetadataReferences)
                File.Copy(reference.Display, Path.Combine(outputDirectory, Path.GetFileName(reference.Display)), true);
            compilation.Emit(project.OutputFilePath);
        }

        private List<SyntaxTree> GetRewrittenTrees(List<SyntaxTree> syntaxTrees, CSharpCompilation compilation)
        {
            var rewrittenTrees = new List<SyntaxTree>();
            foreach (var syntaxTree in syntaxTrees)
            {
                var rewriter = new LinqRewriter(compilation.GetSemanticModel(syntaxTree));
                var rewritten = rewriter.Visit(syntaxTree.GetRoot());
                rewrittenTrees.Add(CSharpSyntaxTree.ParseText(rewritten.ToString()));
            }
            return rewrittenTrees;
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