using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;

namespace TestsLibrary
{
    public static class TestsExtensions
    {
        private static int _tests;
        private static int _valid;

        private static (bool ex1, T val1, bool ex2, T val2) GetValues<T>(Func<T> first, Func<T> second)
        {
            var firstExcept = false;
            var secondExcept = false;
            
            T firstVal = default;
            T secondVal = default;
            try
            {
                firstVal = first();
            }
            catch (Exception)
            {
                firstExcept = true;
            }
            try
            {
                secondVal = second();
            }
            catch (Exception)
            {
                secondExcept = true;
            }
            return (firstExcept, firstVal, secondExcept, secondVal);
        }

        private static int[] items = null;
        private static (bool ex1, T[] val1, bool ex2, T[] val2) GetValues<T>(Func<IEnumerable<T>> first, Func<IEnumerable<T>> second)
        {
            var firstExcept = false;
            var secondExcept = false;
            
            T[] firstVal = default;
            T[] secondVal = default;
            try
            {
                firstVal = first().ToArray();
            }
            catch (Exception e)
            {
                firstExcept = true;
            }
            try
            {
                secondVal = second().ToArray();
            }
            catch (Exception e)
            {
                secondExcept = true;
            }
            return (firstExcept, firstVal, secondExcept, secondVal);
        }
        
        public static void TestEquals<T, Y>(string name, Func<ILookup<T, Y>> first, Func<ILookup<T, Y>> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Select(x => x.Key).SequenceEqual(val2.Select(x => x.Key))) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else
            {
                Console.WriteLine("\n-------------------------------------------------------------\n");
                Console.Write($"[{_valid}/{++_tests}] {name} is invalid\n\nCollection 1: ");
                if (ex1) Console.Write("Error");
                val1?.ForEach(x => Console.Write(x.Key + " "));
                
                Console.Write("\n\nCollection 2: ");
                if (ex2) Console.Write("Error");
                val2?.ForEach(x => Console.Write(x.Key + " "));
                
                Console.WriteLine("\n\n-------------------------------------------------------------\n");
            }
        }
        
        public static void TestEquals<T, Y>(string name, Func<Dictionary<T, Y>> first, Func<Dictionary<T, Y>> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Keys.SequenceEqual(val2.Keys) && val1.Values.SequenceEqual(val2.Values)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else
            {
                Console.WriteLine("\n-------------------------------------------------------------\n");
                Console.Write($"[{_valid}/{++_tests}] {name} is invalid\n\nCollection 1: ");
                if (ex1) Console.Write("Error");
                val1?.ForEach(x => Console.Write("k: " + x.Key + "v: " + x.Value + " "));
                
                Console.Write("\n\nCollection 2: ");
                if (ex2) Console.Write("Error");
                val2?.ForEach(x => Console.Write("k: " + x.Key + "v: " + x.Value + " "));
                
                Console.WriteLine("\n\n-------------------------------------------------------------\n");
            }
        }
        
        public static void TestEquals<T>(string name, Func<IEnumerable<IEnumerable<T>>> first, Func<IEnumerable<IEnumerable<T>>> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            if (ex1 && ex2 || !ex1 && !ex2 && val1.SequenceEqual(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            
            (ex1, val1, ex2, val2) = GetValues(first, second);
            if (ex1 && ex2 || !ex1 && !ex2 && val1.SequenceEqual(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else
            {
                Console.WriteLine("\n-------------------------------------------------------------\n");
                Console.Write($"[{_valid}/{++_tests}] {name} is invalid\n\nCollection 1: ");
                if (ex1) Console.Write("Error");
                val1?.ForEach(x => Console.Write(x + " "));
                
                Console.Write("\n\nCollection 2: ");
                if (ex2) Console.Write("Error");
                val2?.ForEach(x => Console.Write(x + " "));
                
                Console.WriteLine("\n\n-------------------------------------------------------------\n");
            }
        }
        
        public static void TestEquals<T>(string name, Func<IEnumerable<T>> first, Func<IEnumerable<T>> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            if (ex1 && ex2 || !ex1 && !ex2 && val1.SequenceEqual(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else
            {
                Console.WriteLine("\n-------------------------------------------------------------\n");
                Console.Write($"[{_valid}/{++_tests}] {name} is invalid\n\nCollection 1: ");
                if (ex1) Console.Write("Error");
                val1?.ForEach(x => Console.Write(x + " "));
                
                Console.Write("\n\nCollection 2: ");
                if (ex2) Console.Write("Error");
                val2?.ForEach(x => Console.Write(x + " "));
                
                Console.WriteLine("\n\n-------------------------------------------------------------\n");
            }
        }
        
        public static void TestEquals(string name, Func<int> first, Func<int> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Equals(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<int?> first, Func<int?> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Equals(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<long> first, Func<long> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Equals(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<long?> first, Func<long?> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Equals(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<bool> first, Func<bool> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Equals(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<bool?> first, Func<bool?> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && val1.Equals(val2)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<float> first, Func<float> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && Math.Abs(val1 - val2) < double.Epsilon) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<float?> first, Func<float?> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && 
                val1 == null && val2 == null || val1 != null && val2 != null && 
                Math.Abs((double)val1 - (double)val2) < double.Epsilon) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<double> first, Func<double> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && Math.Abs(val1 - val2) < double.Epsilon) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<double?> first, Func<double?> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && 
                val1 == null && val2 == null || val1 != null && val2 != null && 
                Math.Abs((double)val1 - (double)val2) < double.Epsilon) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<decimal> first, Func<decimal> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && Math.Abs(val1 - val2) <= decimal.Zero) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
        
        public static void TestEquals(string name, Func<decimal?> first, Func<decimal?> second)
        {
            var (ex1, val1, ex2, val2) = GetValues(first, second);
            
            if (ex1 && ex2 || !ex1 && !ex2 && 
                val1 == null && val2 == null || val1 != null && val2 != null && 
                Math.Abs((decimal)val1 - (decimal)val2) <= decimal.Zero) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{_valid}/{++_tests}] {name} is invalid. Value 1: {val1}. Value 2: {val2}");
        }
    }
}