using System;
using System.IO;
using System.Linq;
using System.Reflection;
using LinqRewrite.CompileCsc;
using LinqRewrite.DataStructures;
using LinqRewrite.Services;

#if false
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Tooling;
using Microsoft.Dnx.Runtime.Common.CommandLine;
#endif

namespace LinqRewrite
{
    public class Program
    {
        private readonly CompilationService _compilationService;
        private readonly PrintService _printService;
        
#if false
        private static IServiceProvider _hostServices;
        private static IApplicationEnvironment _environment;
        private static IRuntimeEnvironment _runtimeEnv;
        public Program(IServiceProvider hostServices, IApplicationEnvironment environment, IRuntimeEnvironment runtimeEnv)
        {
            _hostServices = hostServices;
            _environment = environment;
            _runtimeEnv = runtimeEnv;
        }
#endif
        public Program()
        {
            _compilationService = CompilationService.Instance;
            _printService = PrintService.Instance;
        }
        
        public static int Main(string[] args)
        {
            var program = new Program();
            try
            {
                return program.ArgsProcessing(args);
            }
            catch (ExitException ex)
            {
                return ex.Code;
            }
            catch (Exception ex)
            {
                program.OnException(ex);
                return 1;
            }
        }

        public void OnException(Exception ex)
        {
            _printService.PrintLine(ex.ToString());
        }

        private int ArgsProcessing(string[] args)
        {
            if (Path.GetFileName(Assembly.GetEntryAssembly().Location).Equals("csc.exe", StringComparison.OrdinalIgnoreCase) || args.Contains("--csc"))
                return UseCsc(args);
            
            if (args.Contains("-h") || args.Contains("--help") || args.Contains("/?"))
                return _printService.PrintHelp();

            if (args.Contains("--show"))
                return _compilationService.FileRewrite(args);

            if (!args.Contains("/p:Configuration=Release"))
                Console.WriteLine("Note: for consistency with MSBuild, this tool compiles by default in debug mode. Consider specifying /p:Configuration=Release.");
            
            return _compilationService.BuildProject(args);
        }

        // This exe works in this way:
        // 1. It launches msbuild with a custom CscToolPath
        // 2. Is launched again by msbuild and acts as a csc.exe compiler
        // In order to more easily debug the "inner" execution, you can set the above variable to 1 and then launch
        // roslyn-linq-rewrite <path-to-csproj>. Then, set the command line options in Visual Studio to
        // @C:\Path\To\roslyn-linq-rewrite-csc-command-line.rsp
        // Don't forget to also set the working directory to be the folder with the .csproj.
        // That file will be located in the project folder (not in the initial working directory)
        // You can now debug what happens when the program is being called by msbuild for the actual compilation.
        private static int UseCsc(string[] args)
        {
            var saveCmdline = Environment.GetEnvironmentVariable("ROSLYN_LINQ_REWRITE_DUMP_CSC_CMDLINE");
            if (!string.IsNullOrEmpty(saveCmdline) && saveCmdline != "0")
            {
                File.WriteAllText("roslyn-linq-rewrite-csc-command-line.txt", Environment.CommandLine);
                var at = args.FirstOrDefault(x => x.StartsWith("@"));
                if (at != null)
                {
                    var atFile = File.ReadAllText(at.Substring(1));
                    File.WriteAllText("roslyn-linq-rewrite-csc-command-line.rsp", atFile);
                }
            }
            args = args.Where(x => x != "--csc").ToArray();
            return ProgramLinqRewrite.MainInternal(args);
        }
        
        private static bool FilesLookEqual(string a, string b)
        {
            var sfi = new FileInfo(a);
            var dfi = new FileInfo(b);
            return sfi.Exists == dfi.Exists && sfi.LastWriteTimeUtc == dfi.LastWriteTimeUtc && sfi.Length == dfi.Length;
        }
    }
}
