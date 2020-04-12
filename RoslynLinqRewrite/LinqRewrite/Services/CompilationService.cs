using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using LinqRewrite.Core;
using MathNet.Symbolics;
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

        public int Build(string[] args)
        {
            try
            {
                if (args.First().EndsWith(".sln"))
                    CompileSolution(args[0]);
                else if (args.First().EndsWith(".csproj"))
                    CompileProject(args[0]);
                else CompileFile(args[0]);
            }
            catch (ProcessException ex)
            {
                return ex.ExitCode;
            }
            return 0;
        }

        public int Rewrite(string[] args)
        {
            try
            {
                var dstDir = args.FirstOrDefault(x => x.StartsWith("--"))?.Replace("--rewriteDst=", "");
                if (args.First().EndsWith(".sln"))
                    RewriteSolution(args[0], dstDir);
                else if (args.First().EndsWith(".csproj"))
                    RewriteProject(args[0], dstDir);
                else RewriteFile(args[0], dstDir);
            }
            catch (ProcessException ex)
            {
                return ex.ExitCode;
            }
            return 0;
        }

        public void RewriteSolution(string path, string dstDir)
        {
            MSBuildLocator.RegisterDefaults();
            var msWorkspace = MSBuildWorkspace.Create();
            var solution = msWorkspace.OpenSolutionAsync(path).Result;
            solution.Projects.ForEach(x => RewriteProject(x, dstDir));
        }

        public void CompileSolution(string path)
        {
            throw new NotImplementedException("Not implemented solution compilation");
        }

        public void RewriteProject(string path, string dstDir)
        {
            MSBuildLocator.RegisterDefaults();
            var msWorkspace = MSBuildWorkspace.Create();
            var project = msWorkspace.OpenProjectAsync(path).Result;
            Directory.Delete(dstDir, true);
            RewriteProject(project, dstDir);
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
            Directory.Delete(outputDirectory, true);
            Directory.CreateDirectory(outputDirectory);
            foreach (var reference in project.MetadataReferences)
                File.Copy(reference.Display, Path.Combine(outputDirectory, Path.GetFileName(reference.Display)), true);
            compilation.Emit(project.OutputFilePath);
        }

        public void RewriteFile(string path, string dstDir)
        {
            var source = File.ReadAllText(path);
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
            
            Directory.Delete(dstDir, true);
            Directory.CreateDirectory(dstDir);
            File.WriteAllText(rewritten.ToString(), Path.Combine(dstDir, Path.GetFileName(path)));
        }

        public void CompileFile(string path)
        {
            var source = File.ReadAllText(path);
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
            syntaxTree = CSharpSyntaxTree.ParseText(rewriter.Visit(syntaxTree.GetRoot()).ToString(), new CSharpParseOptions(kind: isScript ? SourceCodeKind.Script : SourceCodeKind.Regular));
            
            compilation = isScript
                ? CSharpCompilation.CreateScriptCompilation("LinqRewriteExample", syntaxTree, references)
                : CSharpCompilation.Create("LinqRewriteExample", new[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            
            var outputDirectory = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(path)), "bin");
            Directory.Delete(outputDirectory, true);
            Directory.CreateDirectory(outputDirectory);
            compilation.Emit(Path.Combine(outputDirectory, Path.GetFileName(path)));
        }

        private static List<SyntaxTree> GetRewrittenTrees(List<SyntaxTree> syntaxTrees, CSharpCompilation compilation)
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

        private bool PrintDiagnostics(Compilation compilation)
        {
            foreach (var item in compilation.GetDiagnostics())
            {
                _printService.PrintDiagnostic(item);
                if (item.Severity == DiagnosticSeverity.Error) return true;
            }
            return false;
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

        private static CSharpCompilation CompileRelease(Project project, List<SyntaxTree> syntaxTrees)
        {
            var references = project.MetadataReferences;
            var compilationOptions = project.CompilationOptions.WithOptimizationLevel(OptimizationLevel.Release);
            
            return CSharpCompilation.Create(project.AssemblyName, syntaxTrees, references,
                (CSharpCompilationOptions)compilationOptions);
        }
    }
}