using BenchmarkDotNet.Running;

namespace BenchmarkLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SelectBenchmarks>();
        }
    }
}