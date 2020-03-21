using System;
using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;

namespace TestsLibrary
{
    public static class TestExtensions
    {
        [NoRewrite]
        public static void WriteCollectionEquals<T>(this IEnumerable<T> collection, string name, IEnumerable<T> collection2)
        {
            if (collection.SequenceEqual(collection2))
                Console.WriteLine($"{name} is valid");
            else
            {
                Console.Write($"{name} is invalid\nCollection1: ");
                foreach(var item in collection)
                    Console.Write(item + " ");
                
                Console.WriteLine();
                Console.Write("Collection2: ");
                foreach(var item in collection2)
                    Console.Write(item + " ");
            }
        }
    }
}