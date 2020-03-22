using System.Collections.Generic;
using System.Linq;

namespace LinqRewrite
{
    public class SelectTests
    {
        public int[] Values = Enumerable.Range(0, 100).ToArray();
        public static int[] StaticValues = Enumerable.Range(0, 100).ToArray();
        public int Selector(int a) => a + 3;

        public void Tester()
        {
            
        }
        
        public IEnumerable<int> Select1(double num)
        {
            return Values.Select(x => x + 3);
        }
        
        public IEnumerable<int> Select2(double num)
        {
            return Values.Select(Selector);
        }
        
        public IEnumerable<int> Select3(double num)
        {
            return Values.Select(Selector).ToArray();
        }
        
        public IEnumerable<int> Select4(double num)
        {
            return Values.Select(Selector).ToList();
        }
        
        public IEnumerable<float> Select5(double num)
        {
            return Values.Select(x => (float)x).ToList();
        }
        
        public IEnumerable<int> Select6(double num)
        {
            return Values.Select(x => Selector(x)).ToList();
        }
        
        public IEnumerable<int> Select7(double num)
        {
            return Values.Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .ToArray();
        }
        
        public IEnumerable<int> Select8(double num)
        {
            return Values.Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .ToArray();
        }
        
        public IEnumerable<int> Select9(double num)
        {
            var a = Enumerable.Range(1, 100).ToArray();
            return a.Select(x => x + 3).ToArray();
        }
        
        public IEnumerable<int> Select10(double num)
        {
            return StaticValues.Select(x => x + 3).ToArray();
        }
        
        public static IEnumerable<int> Select11(double num)
        {
            return StaticValues.Select(x => x + 3).ToArray();
        }
        
        public static IEnumerable<int> Select12(double num)
        {
            var a = Enumerable.Range(1, 100).ToArray();
            return a.Select(x => x + 3).ToArray();
        }
    }

    public class StaticSelectTests
    {
        public static int[] StaticValues = Enumerable.Range(0, 100).ToArray();
        
        public static IEnumerable<int> Select13(double num)
        {
            var StaticValues = Enumerable.Range(1, 100).ToArray();
            return StaticValues.Select(x => x + 3).ToArray();
        }
        
        public static IEnumerable<int> Select14(double num)
        {
            var a = Enumerable.Range(1, 100).ToArray();
            return a.Select(x => x + 3).ToArray();
        }
        
        public static IEnumerable<IEnumerable<int>> Select15(double num)
        {
            var a = Enumerable.Range(1, 100).ToArray();
            return a.Select(x => a).ToArray();
        }
        
        public static IEnumerable<IEnumerable<int>> Select16(double num)
        {
            var a = Enumerable.Range(1, 100).ToArray();
            return a.Select(x => a.Where(y => y > 5)).ToArray();
        }
    }
}