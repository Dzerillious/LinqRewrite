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
        
        [NoRewrite]
        public static void TestEquals<T>(this IEnumerable<T> first, string name, IEnumerable<T> second)
        {
            var firstArray = first.ToArray();
            var secondArray = second.ToArray();
            
            if (firstArray.SequenceEqual(secondArray)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else
            {
                Console.WriteLine("\n-------------------------------------------------------------\n");
                Console.Write($"[{_valid}/{++_tests}] {name} is invalid\n\nCollection 1: ");
                foreach (var x1 in firstArray)
                    Console.Write(x1 + " ");
                
                Console.Write("\n\nCollection 2: ");
                foreach (var x1 in secondArray)
                    Console.Write(x1 + " ");
                
                Console.WriteLine("\n\n-------------------------------------------------------------\n");
            }
        }
        
        public static void TestEquals(this int first, string name, int second)
        {
            if (first.Equals(second)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{++_tests}/{_valid}] {name} is invalid. Value 1: {first}. Value 2: {second}");
        }
        
        public static void TestEquals(this bool first, string name, bool second)
        {
            if (first.Equals(second)) Console.WriteLine($"[{++_valid}/{++_tests}] {name} is valid");
            else Console.WriteLine($"[{++_tests}/{_valid}] {name} is invalid. Value 1: {first}. Value 2: {second}");
        }
        
        public static void TestEquals(this double first, string name, double second)
        {
            if (Math.Abs(first - second) < double.Epsilon) Console.WriteLine($"[{++_tests}/{++_valid}] {name} is valid");
            else Console.WriteLine($"[{++_tests}/{_valid}] {name} is invalid. Value 1: {first}. Value 2: {second}");
        }
    }
}