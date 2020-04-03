using TestsLibrary.Tests;

namespace TestsLibrary
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            new SelectTests().RunTests();
            new WhereTests().RunTests();
            // new CastTests().RunTests();
            // new OfTypeTests().RunTests();
            
            new AggregateTests().RunTests();
            new AverageTests().RunTests();
            
            new ContainsTests().RunTests();
            new AnyTests().RunTests();
            
            new CountTests().RunTests();
            new MaxTests().RunTests();
            new MinTests().RunTests();
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
            
            new ConcatTests().RunTests();
            new ExceptTests().RunTests();
            new IntersectTests().RunTests();
            new UnionTests().RunTests();
            new SequenceEqualTests().RunTests();
        }
    }
}