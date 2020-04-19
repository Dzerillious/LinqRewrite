using System;
using System.Linq;
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

            return args.Any(x => x.StartsWith("--rewriteDst")) 
                ? _compilationService.Rewrite(args) 
                : _compilationService.Build(args);
        }
    }
}
