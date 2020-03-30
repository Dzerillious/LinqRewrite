using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
    public class RangeTests
    {
        public void RunTests()
        {
        }

        [NoRewrite]
        public IEnumerable<int> RangeTest1()
        {
            return Enumerable.Range(0, 100);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RangeTest2()
        {
            return Enumerable.Range(-100, 100);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RangeTest3()
        {
            return Enumerable.Range(0, -100);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RangeTest4()
        {
            return Enumerable.Range(123, 23);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RangeTestToArray()
        {
            return Enumerable.Range(123, 23).ToArray();
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RangeTestToList()
        {
            return Enumerable.Range(123, 23).ToList();
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RangeTestToSimpleList()
        {
            return Enumerable.Range(123, 23).ToSimpleList();
        } //EndMethod
    }
}