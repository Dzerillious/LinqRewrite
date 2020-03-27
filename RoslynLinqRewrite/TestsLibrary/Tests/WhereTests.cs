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
            ArrayWhereToSimpleList().TestEquals(nameof(ArrayWhereToSimpleList), ArrayWhereToSimpleListRewritten());
            SelectWhereToSimpleList().TestEquals(nameof(SelectWhereToSimpleList), SelectWhereToSimpleListRewritten());
            MultipleSelectWhereToSimpleList().TestEquals(nameof(MultipleSelectWhereToSimpleList), MultipleSelectWhereToSimpleListRewritten());
            SelectWhereToArray().TestEquals(nameof(SelectWhereToArray), SelectWhereToArrayRewritten());
            MultipleSelectWhereToArray().TestEquals(nameof(MultipleSelectWhereToArray), MultipleSelectWhereToArrayRewritten());
            
            for (int i = -2; i < 1002; i++)
                ParametrizedWhere(i).TestEquals(nameof(ParametrizedWhere) + i, ParametrizedWhereRewritten(i));
            
            for (int i = -2; i < 1002; i++)
                ParametrizedWhereToArray(i).TestEquals(nameof(ParametrizedWhereToArray) + i, ParametrizedWhereToArrayRewritten(i));
            
            for (int i = -2; i < 1002; i++)
                ParametrizedEnumerableWhereToArray(i).TestEquals(nameof(ParametrizedEnumerableWhereToArray) + i, ParametrizedEnumerableWhereToArrayRewritten(i));

            for (int i = -2; i < 1002; i++)
                ParametrizedWhereToSimpleList(i).TestEquals(nameof(ParametrizedWhereToSimpleList) + i, ParametrizedWhereToSimpleListRewritten(i));
            
            WhereChangingParam().TestEquals(nameof(WhereChangingParam), WhereChangingParamRewritten());
            WhereChangingParamToArray().TestEquals(nameof(WhereChangingParamToArray), WhereChangingParamToArrayRewritten());
            WhereChangingParamToSimpleList().TestEquals(nameof(WhereChangingParamToSimpleList), WhereChangingParamToSimpleListRewritten());
            WhereIndexToArray().TestEquals(nameof(WhereIndexToArray), WhereIndexToArrayRewritten());
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

        public IEnumerable<int> ParametrizedWhereToSimpleListRewritten(int offset)
        {
            return ArrayItems.Where(x => x > offset)
                .ToSimpleList();
        } //EndMethod
        
        [NoRewrite]
        public IEnumerable<int> ParametrizedEnumerableWhereToArray(int offset)
        {
            return EnumerableItems.Where(x => x > offset)
                .ToSimpleList();
        } //EndMethod

        public IEnumerable<int> ParametrizedEnumerableWhereToArrayRewritten(int offset)
        {
            return EnumerableItems.Where(x => x > offset)
                .ToArray();
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