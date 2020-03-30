using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ExceptTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private int[] ArrayItems2 = Enumerable.Range(30, 130).ToArray();
        [Datapoints]
        private SimpleList<int> SimpleListItems = Enumerable.Range(10, 110).ToSimpleList();
        [Datapoints]
        private SimpleList<int> SimpleListItems2 = Enumerable.Range(40, 140).ToSimpleList();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(20, 120);
        [Datapoints]
        private IEnumerable<int> EnumerableItems2 = Enumerable.Range(50, 150);
        
        public void RunTests()
        {
        }

        [NoRewrite]
        public IEnumerable<int> ArrayExceptArray()
        {
            return ArrayItems.Except(ArrayItems2);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> ArrayExceptSimpleList()
        {
            return ArrayItems.Except(SimpleListItems2);
        } //EndMethod
    }
}