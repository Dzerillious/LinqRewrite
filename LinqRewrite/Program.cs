// Forked and modified from https://github.com/antiufo/roslyn-linq-rewrite/tree/master/RoslynLinqRewrite

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
                program.PrintLine(ret ? "Rewrite was successful." : "There was an error in rewrite.");
                return ret ? 0 : 1;
            }
            catch (Exception ex)
            {
                program.PrintLine(ex.ToString());
                return 1;
            }
        }

        public void PrintLine(string line)
        {
            _printService.PrintLine(line);
        }

        private bool ArgsProcessing(string[] args)
        {
            if (args.Length < 2 || args.Contains("-h") || args.Contains("--help"))
                return _printService.PrintHelp();

            return _compilationService.Rewrite(args);
        }
    }
}
