using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;

namespace TestsLibrary.Tests
{
    public class RepeatTests
    {
        public void RunTests()
        {
        }

        [NoRewrite]
        public IEnumerable<int> RepeatTest1()
        {
            return Enumerable.Repeat(0, 100);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RepeatTest2()
        {
            return Enumerable.Repeat(-100, 100);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RepeatTest3()
        {
            return Enumerable.Repeat(0, -100);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RepeatTest4()
        {
            return Enumerable.Repeat(123, 23);
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RepeatTestToArray()
        {
            return Enumerable.Repeat(123, 23).ToArray();
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RepeatTestToList()
        {
            return Enumerable.Repeat(123, 23).ToList();
        } //EndMethod

        [NoRewrite]
        public IEnumerable<int> RepeatTestToSimpleList()
        {
            return Enumerable.Repeat(123, 23).ToSimpleList();
        } //EndMethod
    }
}