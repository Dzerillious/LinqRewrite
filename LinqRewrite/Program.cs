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
                var ret = program.ArgsProcessing(args);
                program.PrintLine("Pres any key to continue.");
                Console.ReadKey();
                return ret;
            }
            catch (Exception ex)
            {
                program.PrintLine(ex.ToString());
                program.PrintLine("Pres any key to continue.");
                Console.ReadKey();
                return 1;
            }
        }

        public void PrintLine(string line)
        {
            _printService.PrintLine(line);
        }

        private int ArgsProcessing(string[] args)
        {
            if (args.Length == 0 || args.Contains("-h") || args.Contains("--help") || args.Contains("/?"))
                return _printService.PrintHelp();

            return args.Any(x => x.StartsWith("--rewriteDst")) 
                ? _compilationService.Rewrite(args) 
                : _compilationService.Build(args);
        }
    }
}
