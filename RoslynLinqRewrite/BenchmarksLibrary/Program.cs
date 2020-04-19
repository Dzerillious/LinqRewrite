using BenchmarkDotNet.Running;

namespace BenchmarkLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}