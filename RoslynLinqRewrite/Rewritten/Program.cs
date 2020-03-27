using TestsLibrary.Tests;

namespace TestsLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            new SelectTests().RunTests();
            new WhereTests().RunTests();
            new AggregateTests().RunTests();
            new AnyTests().RunTests();
            new AverageTests().RunTests();
            new CastTests().RunTests();
            new ContainsTests().RunTests();
            new CountTests().RunTests();
            new ElementAtTests().RunTests();
            new ElementAtOrDefaultOrDefaultTests().RunTests();
            new DistinctTests().RunTests();
        }
    }
}