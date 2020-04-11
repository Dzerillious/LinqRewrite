using System;
using System.Linq;
using LinqRewrite.DataStructures;
using LinqRewrite.Services;

namespace LinqRewrite
{
    public class Program
    {
        private readonly CompilationService _compilationService;
        private readonly PrintService _printService;
        
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

            if (args.Any(x => x.StartsWith("--reProj")))
                return _compilationService.RewriteProject(args);

            if (!args.Contains("/p:Configuration=Release"))
                Console.WriteLine("Note: for consistency with MSBuild, this tool compiles by default in debug mode. Consider specifying /p:Configuration=Release.");
            
            return _compilationService.BuildProject(args);
        }
    }
}
