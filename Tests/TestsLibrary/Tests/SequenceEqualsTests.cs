using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class SequenceEqualTests
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

        private IEnumerable<int> MethodEnumerable()
        {
            for (int i = 25; i < 125; i++)
            {
                yield return i;
            }
        }

        private IEnumerable<int> MethodEnumerable2()
        {
            for (int i = 55; i < 155; i++)
            {
                yield return i;
            }
        }
        
        public void RunTests()
        {
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualArray), ArraySequenceEqualArray, ArraySequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualSimpleList), ArraySequenceEqualSimpleList, ArraySequenceEqualSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualEnumerable), ArraySequenceEqualEnumerable, ArraySequenceEqualEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualMethod), ArraySequenceEqualMethod, ArraySequenceEqualMethodRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualArray), SimpleListSequenceEqualArray, SimpleListSequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualSimpleList), SimpleListSequenceEqualSimpleList, SimpleListSequenceEqualSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualEnumerable), SimpleListSequenceEqualEnumerable, SimpleListSequenceEqualEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(SimpleListSequenceEqualMethod), SimpleListSequenceEqualMethod, SimpleListSequenceEqualMethodRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualArray), EnumerableSequenceEqualArray, EnumerableSequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualSimpleList), EnumerableSequenceEqualSimpleList, EnumerableSequenceEqualSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualEnumerable), EnumerableSequenceEqualEnumerable, EnumerableSequenceEqualEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(EnumerableSequenceEqualMethod), EnumerableSequenceEqualMethod, EnumerableSequenceEqualMethodRewritten);
            TestsExtensions.TestEquals(nameof(MethodSequenceEqualArray), MethodSequenceEqualArray, MethodSequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(MethodSequenceEqualSimpleList), MethodSequenceEqualSimpleList, MethodSequenceEqualSimpleListRewritten);
            TestsExtensions.TestEquals(nameof(MethodSequenceEqualEnumerable), MethodSequenceEqualEnumerable, MethodSequenceEqualEnumerableRewritten);
            TestsExtensions.TestEquals(nameof(MethodSequenceEqualMethod), MethodSequenceEqualMethod, MethodSequenceEqualMethodRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectSequenceEqualArray), ArraySelectSequenceEqualArray, ArraySelectSequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySelectSequenceEqualArraySelect), ArraySelectSequenceEqualArraySelect, ArraySelectSequenceEqualArraySelectRewritten);
            TestsExtensions.TestEquals(nameof(ArrayWhereSequenceEqualArrayWhere), ArrayWhereSequenceEqualArrayWhere, ArrayWhereSequenceEqualArrayWhereRewritten);
            TestsExtensions.TestEquals(nameof(SelectWhereArraySequenceEqualSelectWhereArray), SelectWhereArraySequenceEqualSelectWhereArray, SelectWhereArraySequenceEqualSelectWhereArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeSequenceEqualArray), RangeSequenceEqualArray, RangeSequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(RepeatSequenceEqualArray), RepeatSequenceEqualArray, RepeatSequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(EmptySequenceEqualArray), EmptySequenceEqualArray, EmptySequenceEqualArrayRewritten);
            TestsExtensions.TestEquals(nameof(RangeEmpty2Array), RangeEmpty2Array, RangeEmpty2ArrayRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualRange), ArraySequenceEqualRange, ArraySequenceEqualRangeRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualRepeat), ArraySequenceEqualRepeat, ArraySequenceEqualRepeatRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualEmpty), ArraySequenceEqualEmpty, ArraySequenceEqualEmptyRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualEmpty2), ArraySequenceEqualEmpty2, ArraySequenceEqualEmpty2Rewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualAll), ArraySequenceEqualAll, ArraySequenceEqualAllRewritten);
            TestsExtensions.TestEquals(nameof(ArraySequenceEqualNull), ArraySequenceEqualNull, ArraySequenceEqualNullRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctSequenceEqualArrayDistinct), ArrayDistinctSequenceEqualArrayDistinct, ArrayDistinctSequenceEqualArrayDistinctRewritten);
            TestsExtensions.TestEquals(nameof(ArrayDistinctSequenceEqualArrayDistinct2), ArrayDistinctSequenceEqualArrayDistinct, ArrayDistinctSequenceEqualArrayDistinct2Rewritten);
        }

        public bool ArraySequenceEqualArray()
        {
            return ArrayItems.SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualArrayRewritten()
        {
            return ArrayItems.SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool ArraySequenceEqualSimpleList()
        {
            return ArrayItems.SequenceEqual(SimpleListItems2);
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualSimpleListRewritten()
        {
            return ArrayItems.SequenceEqual(SimpleListItems2);
        } //EndMethod


        public bool ArraySequenceEqualEnumerable()
        {
            return ArrayItems.SequenceEqual(EnumerableItems2);
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualEnumerableRewritten()
        {
            return ArrayItems.SequenceEqual(EnumerableItems2);
        } //EndMethod


        public bool ArraySequenceEqualMethod()
        {
            return ArrayItems.SequenceEqual(MethodEnumerable2());
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualMethodRewritten()
        {
            return ArrayItems.SequenceEqual(MethodEnumerable2());
        } //EndMethod


        public bool SimpleListSequenceEqualArray()
        {
            return SimpleListItems.SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool SimpleListSequenceEqualArrayRewritten()
        {
            return SimpleListItems.SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool SimpleListSequenceEqualSimpleList()
        {
            return SimpleListItems.SequenceEqual(SimpleListItems2);
        } //EndMethod

        [LinqRewrite]
		public bool SimpleListSequenceEqualSimpleListRewritten()
        {
            return SimpleListItems.SequenceEqual(SimpleListItems2);
        } //EndMethod


        public bool SimpleListSequenceEqualEnumerable()
        {
            return SimpleListItems.SequenceEqual(EnumerableItems2);
        } //EndMethod

        [LinqRewrite]
		public bool SimpleListSequenceEqualEnumerableRewritten()
        {
            return SimpleListItems.SequenceEqual(EnumerableItems2);
        } //EndMethod


        public bool SimpleListSequenceEqualMethod()
        {
            return SimpleListItems.SequenceEqual(MethodEnumerable2());
        } //EndMethod

        [LinqRewrite]
		public bool SimpleListSequenceEqualMethodRewritten()
        {
            return SimpleListItems.SequenceEqual(MethodEnumerable2());
        } //EndMethod


        public bool EnumerableSequenceEqualArray()
        {
            return EnumerableItems.SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool EnumerableSequenceEqualArrayRewritten()
        {
            return EnumerableItems.SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool EnumerableSequenceEqualSimpleList()
        {
            return EnumerableItems.SequenceEqual(SimpleListItems2);
        } //EndMethod

        [LinqRewrite]
		public bool EnumerableSequenceEqualSimpleListRewritten()
        {
            return EnumerableItems.SequenceEqual(SimpleListItems2);
        } //EndMethod


        public bool EnumerableSequenceEqualEnumerable()
        {
            return EnumerableItems.SequenceEqual(EnumerableItems2);
        } //EndMethod

        [LinqRewrite]
		public bool EnumerableSequenceEqualEnumerableRewritten()
        {
            return EnumerableItems.SequenceEqual(EnumerableItems2);
        } //EndMethod


        public bool EnumerableSequenceEqualMethod()
        {
            return EnumerableItems.SequenceEqual(MethodEnumerable2());
        } //EndMethod

        [LinqRewrite]
		public bool EnumerableSequenceEqualMethodRewritten()
        {
            return EnumerableItems.SequenceEqual(MethodEnumerable2());
        } //EndMethod


        public bool MethodSequenceEqualArray()
        {
            return MethodEnumerable().SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool MethodSequenceEqualArrayRewritten()
        {
            return MethodEnumerable().SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool MethodSequenceEqualSimpleList()
        {
            return MethodEnumerable().SequenceEqual(SimpleListItems2);
        } //EndMethod

        [LinqRewrite]
		public bool MethodSequenceEqualSimpleListRewritten()
        {
            return MethodEnumerable().SequenceEqual(SimpleListItems2);
        } //EndMethod


        public bool MethodSequenceEqualEnumerable()
        {
            return MethodEnumerable().SequenceEqual(EnumerableItems2);
        } //EndMethod

        [LinqRewrite]
		public bool MethodSequenceEqualEnumerableRewritten()
        {
            return MethodEnumerable().SequenceEqual(EnumerableItems2);
        } //EndMethod


        public bool MethodSequenceEqualMethod()
        {
            return MethodEnumerable().SequenceEqual(MethodEnumerable2());
        } //EndMethod

        [LinqRewrite]
		public bool MethodSequenceEqualMethodRewritten()
        {
            return MethodEnumerable().SequenceEqual(MethodEnumerable2());
        } //EndMethod


        public bool ArraySelectSequenceEqualArray()
        {
            return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool ArraySelectSequenceEqualArrayRewritten()
        {
            return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool ArraySelectSequenceEqualArraySelect()
        {
            return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2.Select(x => x + 50));
        } //EndMethod

        [LinqRewrite]
		public bool ArraySelectSequenceEqualArraySelectRewritten()
        {
            return ArrayItems.Select(x => x + 50).SequenceEqual(ArrayItems2.Select(x => x + 50));
        } //EndMethod


        public bool ArrayWhereSequenceEqualArrayWhere()
        {
            return ArrayItems.Where(x => x > 50).SequenceEqual(ArrayItems2.Where(x => x > 50));
        } //EndMethod

        [LinqRewrite]
		public bool ArrayWhereSequenceEqualArrayWhereRewritten()
        {
            return ArrayItems.Where(x => x > 50).SequenceEqual(ArrayItems2.Where(x => x > 50));
        } //EndMethod


        public bool SelectWhereArraySequenceEqualSelectWhereArray()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).SequenceEqual(ArrayItems2.Select(x => x + 10).Where(x => x > 80));
        } //EndMethod

        [LinqRewrite]
		public bool SelectWhereArraySequenceEqualSelectWhereArrayRewritten()
        {
            return ArrayItems.Select(x => x + 10).Where(x => x > 80).SequenceEqual(ArrayItems2.Select(x => x + 10).Where(x => x > 80));
        } //EndMethod


        public bool RangeSequenceEqualArray()
        {
            return Enumerable.Range(20, 100).SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool RangeSequenceEqualArrayRewritten()
        {
            return Enumerable.Range(20, 100).SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool RepeatSequenceEqualArray()
        {
            return Enumerable.Repeat(20, 100).SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool RepeatSequenceEqualArrayRewritten()
        {
            return Enumerable.Repeat(20, 100).SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool EmptySequenceEqualArray()
        {
            return Enumerable.Empty<int>().SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool EmptySequenceEqualArrayRewritten()
        {
            return Enumerable.Empty<int>().SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool RangeEmpty2Array()
        {
            return ArrayItems.Where(x => false).SequenceEqual(ArrayItems2);
        } //EndMethod

        [LinqRewrite]
		public bool RangeEmpty2ArrayRewritten()
        {
            return ArrayItems.Where(x => false).SequenceEqual(ArrayItems2);
        } //EndMethod


        public bool ArraySequenceEqualRange()
        {
            return ArrayItems.SequenceEqual(Enumerable.Range(70, 260));
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualRangeRewritten()
        {
            return ArrayItems.SequenceEqual(Enumerable.Range(70, 260));
        } //EndMethod


        public bool ArraySequenceEqualRepeat()
        {
            return ArrayItems.SequenceEqual(Enumerable.Repeat(70, 100));
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualRepeatRewritten()
        {
            return ArrayItems.SequenceEqual(Enumerable.Repeat(70, 100));
        } //EndMethod


        public bool ArraySequenceEqualEmpty()
        {
            return ArrayItems.SequenceEqual(Enumerable.Empty<int>());
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualEmptyRewritten()
        {
            return ArrayItems.SequenceEqual(Enumerable.Empty<int>());
        } //EndMethod


        public bool ArraySequenceEqualEmpty2()
        {
            return ArrayItems.SequenceEqual(ArrayItems2.Where(x => false));
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualEmpty2Rewritten()
        {
            return ArrayItems.SequenceEqual(ArrayItems2.Where(x => false));
        } //EndMethod


        public bool ArraySequenceEqualAll()
        {
            return ArrayItems.SequenceEqual(Enumerable.Range(0, 1000));
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualAllRewritten()
        {
            return ArrayItems.SequenceEqual(Enumerable.Range(0, 1000));
        } //EndMethod


        public bool ArraySequenceEqualNull()
        {
            return ArrayItems.SequenceEqual(null);
        } //EndMethod

        [LinqRewrite]
		public bool ArraySequenceEqualNullRewritten()
        {
            return ArrayItems.SequenceEqual(null);
        } //EndMethod


        public bool ArrayDistinctSequenceEqualArrayDistinct()
        {
            return ArrayItems.Distinct().SequenceEqual(ArrayItems.Distinct());
        } //EndMethod

        [LinqRewrite]
		public bool ArrayDistinctSequenceEqualArrayDistinctRewritten()
        {
            return ArrayItems.Distinct().SequenceEqual(ArrayItems.Distinct());
        } //EndMethod


        public bool ArrayDistinctSequenceEqualArrayDistinct2()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).SequenceEqual(ArrayItems.Distinct(EqualityComparer<int>.Default));
        } //EndMethod

        [LinqRewrite]
		public bool ArrayDistinctSequenceEqualArrayDistinct2Rewritten()
        {
            return ArrayItems.Distinct(EqualityComparer<int>.Default).SequenceEqual(ArrayItems.Distinct(EqualityComparer<int>.Default));
        } //EndMethod

    }
}