using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class WhereTests
    {
        [Datapoints]
        private int[] EnumerableItems = Enumerable.Range(0, 1000).ToArray();
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 1000).ToArray();
        public double Selector(int x) => x + 3;
        public double Selector(double x) => x + 3;
        public bool Predicate(int x) => x > 500;
        public bool Predicate(double x) => x > 500;
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArrayWhereToSimpleList), ArrayWhereToSimpleList, ArrayWhereToSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(SelectWhereToSimpleList), SelectWhereToSimpleList, SelectWhereToSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(MultipleSelectWhereToSimpleList), MultipleSelectWhereToSimpleList, MultipleSelectWhereToSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(SelectWhereToArray), SelectWhereToArray, SelectWhereToArrayRewritten);
            TestsExtensions.TestEquals(nameof(MultipleSelectWhereToArray), MultipleSelectWhereToArray, MultipleSelectWhereToArrayRewritten);
            
            for (int i = -2; i < 1002; i++)
                TestsExtensions.TestEquals(nameof(ParametrizedWhere) + i, () => ParametrizedWhere(i), () => ParametrizedWhereRewritten(i));
            
            TestsExtensions.TestEquals(nameof(WhereChangingParam), WhereChangingParam, WhereChangingParamRewritten);
            TestsExtensions.TestEquals(nameof(WhereChangingParamToArray), WhereChangingParamToArray, WhereChangingParamToArrayRewritten);
            TestsExtensions.TestEquals(nameof(WhereChangingParamToSimpleList), WhereChangingParamToSimpleList, WhereChangingParamToSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(WhereIndexToArray), WhereIndexToArray, WhereIndexToArrayRewritten);
        }
        
        [NoRewrite]
        public IEnumerable<int> ArrayWhereToSimpleList()
        {
            return ArrayItems.Where(x => x > 500).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> ArrayWhereToSimpleListRewritten()
        {
            return ArrayItems.Where(x => x > 500).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SelectWhereToSimpleList()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500).ToSimpleList();
        } //EndMethod

        public IEnumerable<int> SelectWhereToSimpleListRewritten()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500).ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MultipleSelectWhereToSimpleList()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .ToSimpleList();
        } //EndMethod

        public IEnumerable<int> MultipleSelectWhereToSimpleListRewritten()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> SelectWhereToArray()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500).ToArray();
        } //EndMethod

        public IEnumerable<int> SelectWhereToArrayRewritten()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500).ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> MultipleSelectWhereToArray()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .ToSimpleList();
        } //EndMethod

        public IEnumerable<int> MultipleSelectWhereToArrayRewritten()
        {
            return ArrayItems.Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .Select(x => x + 5)
                .Where(x => x > 500)
                .ToSimpleList();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<double> MultipleSelectMethodWhereToArray()
        {
            return ArrayItems.Select(Selector)
                .Where(Predicate)
                .Select(Selector)
                .Where(Predicate)
                .Select(Selector)
                .Where(Predicate)
                .Select(Selector)
                .Where(Predicate)
                .ToArray();
        } //EndMethod

        public IEnumerable<double> MultipleSelectWhereMethodToArrayRewritten()
        {
            return ArrayItems.Select(Selector)
                .Where(Predicate)
                .Select(Selector)
                .Where(Predicate)
                .Select(Selector)
                .Where(Predicate)
                .Select(Selector)
                .Where(Predicate)
                .ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ParametrizedWhere(int offset)
        {
            return ArrayItems.Where(x => x > offset);
        } //EndMethod

        public IEnumerable<int> ParametrizedWhereRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ParametrizedWhereToArray(int offset)
        {
            return ArrayItems.Where(x => x > offset)
                .ToArray();
        } //EndMethod

        public IEnumerable<int> ParametrizedWhereToArrayRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset)
                .ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> ParametrizedWhereToSimpleList(int offset)
        {
            return ArrayItems.Where(x => x > offset)
                .ToSimpleList();
        } //EndMethod
        
        [NoRewrite]
        public IEnumerable<int> WhereChangingParam()
        {
            var a = 50;
            return ArrayItems.Where(x => x > 2 * a)
                .Select(x => x + a++);
        } //EndMethod

        public IEnumerable<int> WhereChangingParamRewritten()
        {
            var a = 50;
            return ArrayItems.Where(x => x > 2 * a)
                .Select(x => x + a++);
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> WhereChangingParamToArray()
        {
            var a = 50;
            return ArrayItems.Where(x => x > 2 * a)
                .Select(x => x + a++)
                .ToArray();
        } //EndMethod

        public IEnumerable<int> WhereChangingParamToArrayRewritten()
        {
            var a = 50;
            return ArrayItems.Where(x => x > 2 * a)
                .Select(x => x + a++)
                .ToArray();
        } //EndMethod


        [NoRewrite]
        public IEnumerable<int> WhereChangingParamToSimpleList()
        {
            var a = 50;
            return ArrayItems.Where(x => x > 2 * a)
                .Select(x => x + a++)
                .ToSimpleList();
        } //EndMethod

        public IEnumerable<int> WhereChangingParamToSimpleListRewritten()
        {
            var a = 50;
            return ArrayItems.Where(x => x > 2 * a)
                .Select(x => x + a++)
                .ToSimpleList();
        } //EndMethod
        
        [NoRewrite]
        public IEnumerable<int> WhereIndexToArray()
        {
            return ArrayItems.Where((x, i) => x > 200 + i / 2)
                .ToArray();
        } //EndMethod

        public IEnumerable<int> WhereIndexToArrayRewritten()
        {
            return ArrayItems.Where((x, i) => x > 200 + i / 2)
                .ToArray();
        } //EndMethod
    }
}