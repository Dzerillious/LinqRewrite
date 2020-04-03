using System;
using System.Linq;
using TestsLibrary.Tests;

namespace TestsLibrary
{
    internal class Program
    {
        private static int[] items = null;
        public static void Main(string[] args)
        {
            new SelectTests().RunTests();
            new WhereTests().RunTests();
            new CastTests().RunTests();
            new OfTypeTests().RunTests();
            new ZipTests().RunTests();
            
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
            
            new SkipTests().RunTests();
            new TakeTests().RunTests();
            new SkipWhile().RunTests();
            new TakeWhile().RunTests();
            new ForEachTests().RunTests();
            
            // new ToArrayTests().RunTests();
            // new ToListTests().RunTests();
            // new ToSimpleListTests().RunTests();
            // new ToDictionaryTests().RunTests();
            // new ToLookupTests().RunTests();
            
            Console.ReadLine();
        }
    }
}