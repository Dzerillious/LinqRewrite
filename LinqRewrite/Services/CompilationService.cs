// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

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

        public bool Rewrite(string[] args)
        {
            try
            {
                if (args.First().EndsWith(".sln"))
                    return RewriteSolution(args[0], args[1]);
                else if (args.First().EndsWith(".csproj"))
                {
                    if (MSBuildLocator.CanRegister) MSBuildLocator.RegisterDefaults();
                    var msWorkspace = MSBuildWorkspace.Create();
                    var project = msWorkspace.OpenProjectAsync(args[0]).Result;
                    if (Directory.Exists(args[1])) Directory.Delete(args[1], true);
                    return RewriteProject(msWorkspace, project, args[1]);
                }
                else return RewriteFile(args[0], args[1]);
            }
            catch (Exception ex)
            {
                _printService.PrintLine(ex.Message);
                return false;
            }
        }

        public bool RewriteSolution(string path, string dstDir)
        {
            if (MSBuildLocator.CanRegister) MSBuildLocator.RegisterDefaults();
            var msWorkspace = MSBuildWorkspace.Create();
            var solution = msWorkspace.OpenSolutionAsync(path).Result;
            return solution.Projects.All(project => RewriteProject(msWorkspace, project, dstDir));
        }

        public bool RewriteProject(MSBuildWorkspace workspace, Project project, string dstDir)
        {
            foreach (var referencedProject in project.AllProjectReferences)
            {
                var projectToCompile = workspace.CurrentSolution.GetProject(referencedProject.ProjectId);
                Directory.Delete(Path.GetDirectoryName(projectToCompile.OutputFilePath), true);
                if (!CompileProject(workspace, projectToCompile, projectToCompile.OutputFilePath)) return false;
                project = project.AddMetadataReferences(projectToCompile.MetadataReferences);
                project = project.AddMetadataReference(MetadataReference.CreateFromFile(projectToCompile.OutputFilePath));
            }
            var documents = project.Documents.ToArray();
            var syntaxTrees = project.Documents.Select(document => CSharpSyntaxTree.ParseText(File.ReadAllText(document.FilePath))).ToList();

            var compilation = CompileRelease(project, syntaxTrees);
            if(PrintDiagnostics(compilation)) return false;

            string projectDir =  Path.GetDirectoryName(project.FilePath);
            CopyFile(project.FilePath, projectDir, dstDir);

            var rewrittenTrees = GetRewrittenTrees(syntaxTrees, compilation);
            for (var i = 0; i < rewrittenTrees.Count; i++)
                WriteFile(documents[i].FilePath, rewrittenTrees[i].ToString(), projectDir, dstDir);
            
            Directory.CreateDirectory(dstDir);
            foreach (var document in project.AdditionalDocuments)
                CopyFile(document.FilePath, projectDir, dstDir);
            return true;
        }

        public bool CompileProject(MSBuildWorkspace workspace, Project project, string dstPath)
        {
            foreach (var referencedProject in project.AllProjectReferences)
            {
                var projectToCompile = workspace.CurrentSolution.GetProject(referencedProject.ProjectId);
                Directory.Delete(Path.GetDirectoryName(projectToCompile.OutputFilePath), true);
                CompileProject(workspace, projectToCompile, projectToCompile.OutputFilePath);
                project = project.AddMetadataReferences(projectToCompile.MetadataReferences);
                project = project.AddMetadataReference(MetadataReference.CreateFromFile(projectToCompile.OutputFilePath));
            }
            var syntaxTrees = project.Documents.Select(document => CSharpSyntaxTree.ParseText(File.ReadAllText(document.FilePath))).ToList();

            var compilation = CompileRelease(project, syntaxTrees);
            if(PrintDiagnostics(compilation)) return false;
            syntaxTrees = GetRewrittenTrees(syntaxTrees, compilation);

            compilation = CompileRelease(project, syntaxTrees);
            if(PrintDiagnostics(compilation)) return false;

            string dstDir = Path.GetDirectoryName(dstPath);
            Directory.CreateDirectory(dstDir);
            foreach (var reference in project.MetadataReferences)
                File.Copy(reference.Display, Path.Combine(dstDir, Path.GetFileName(reference.Display)), true);

            dstPath = project.CompilationOptions.OutputKind switch
            {
                OutputKind.ConsoleApplication => Path.ChangeExtension(dstPath, "exe"),
                OutputKind.WindowsApplication => Path.ChangeExtension(dstPath, "exe"),
                OutputKind.WindowsRuntimeApplication => Path.ChangeExtension(dstPath, "exe"),
                OutputKind.DynamicallyLinkedLibrary => Path.ChangeExtension(dstPath, "dll"),
                _ => null
            };
            if (dstPath == null)
            {
                _printService.PrintLine("Unsupported OutputKind");
                return false;
            }
            compilation.Emit(dstPath);
            return true;
        }

        public bool RewriteFile(string path, string dstDir)
        {
            string source = File.ReadAllText(path);
            var isScript = Path.GetExtension(path).Equals(".csx");
            
            var syntaxTree = CSharpSyntaxTree.ParseText(source, new CSharpParseOptions(kind: isScript ? SourceCodeKind.Script : SourceCodeKind.Regular));
            var references = new[] {
                MetadataReference.CreateFromFile(typeof(int).GetTypeInfo().Assembly.Location), // mscorlib
                MetadataReference.CreateFromFile(typeof(Uri).GetTypeInfo().Assembly.Location), // System
                MetadataReference.CreateFromFile(typeof(Enumerable).GetTypeInfo().Assembly.Location) // System.Core
                };
            
            var compilation = isScript
                ? CSharpCompilation.CreateScriptCompilation("LinqRewriteExample", syntaxTree, references)
                : CSharpCompilation.Create("LinqRewriteExample", new[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            if(PrintDiagnostics(compilation)) return false;
            var rewriter = new LinqRewriter(compilation.GetSemanticModel(syntaxTree));
            var rewrittenNode = rewriter.Visit(syntaxTree.GetRoot());
            
            Directory.Delete(dstDir, true);
            Directory.CreateDirectory(dstDir);
            File.WriteAllText(rewrittenNode.ToString(), Path.Combine(dstDir, Path.GetFileName(path)));
            return true;
        }

        private static List<SyntaxTree> GetRewrittenTrees(List<SyntaxTree> syntaxTrees, CSharpCompilation compilation)
        {
            var rewrittenTrees = new List<SyntaxTree>();
            foreach (var syntaxTree in syntaxTrees)
            {
                var rewriter = new LinqRewriter(compilation.GetSemanticModel(syntaxTree));
                var rewrittenNode = rewriter.Visit(syntaxTree.GetRoot());
                rewrittenTrees.Add(CSharpSyntaxTree.ParseText(rewrittenNode.ToString()));
            }
            return rewrittenTrees;
        }

        private bool PrintDiagnostics(Compilation compilation)
        {
            var error = false;
            foreach (Diagnostic item in compilation.GetDiagnostics())
            {
                _printService.PrintDiagnostic(item);
                if (item.Severity == DiagnosticSeverity.Error) error = true;
            }
            return error;
        }

        private static void WriteFile(string fileName, string content, string projectDir, string dstDir)
        {
            string writePath = fileName.Replace(projectDir, dstDir);
            Directory.CreateDirectory(Path.GetDirectoryName(writePath));
            File.WriteAllText(writePath, content);
        }

        private static void CopyFile(string fileName, string projectDir, string dstDir)
        {
            string copiedPath = fileName.Replace(projectDir, dstDir);
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