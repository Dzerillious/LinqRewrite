using System;
using System.IO;
using System.Linq;
using System.Reflection;
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
            if (args.Contains("-h") || args.Contains("--help") || args.Contains("/?"))
                return _printService.PrintHelp();

            if (args.Contains("--show"))
                return _compilationService.FileRewrite(args);

            if (!args.Contains("/p:Configuration=Release"))
                Console.WriteLine("Note: for consistency with MSBuild, this tool compiles by default in debug mode. Consider specifying /p:Configuration=Release.");
            
            return _compilationService.BuildProject(args);
        }
        
        private static bool FilesLookEqual(string a, string b)
        {
            var sfi = new FileInfo(a);
            var dfi = new FileInfo(b);
            return sfi.Exists == dfi.Exists && sfi.LastWriteTimeUtc == dfi.LastWriteTimeUtc && sfi.Length == dfi.Length;
        }
    }
}
