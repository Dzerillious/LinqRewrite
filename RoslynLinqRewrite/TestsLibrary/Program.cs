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
            // new CastTests().RunTests();
            // new OfTypeTests().RunTests();
            new ContainsTests().RunTests();
            new CountTests().RunTests();
            new ElementAtTests().RunTests();
            new ElementAtOrDefaultOrDefaultTests().RunTests();
            new DistinctTests().RunTests();
            new EmptyTests().RunTests();
            
            new FirstTests().RunTests();
            new FirstOrDefaultTests().RunTests();
            new LastTests().RunTests();
            new LastOrDefaultTests().RunTests();
            new SingleTests().RunTests();
            new SingleOrDefaultTests().RunTests();
            
            new RangeTests().RunTests();
            new RepeatTests().RunTests();
        }
    }
}