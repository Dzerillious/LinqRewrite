using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class ElementAtTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public void RunTests()
        {
            ArrayElementAt().TestEquals(nameof(ArrayElementAt), ArrayElementAtRewritten());
            ArraySelectElementAt().TestEquals(nameof(ArraySelectElementAt), ArraySelectElementAtRewritten());
            ArrayWhereElementAt().TestEquals(nameof(ArrayWhereElementAt), ArrayWhereElementAtRewritten());
            ArraySelectWhereElementAt().TestEquals(nameof(ArraySelectWhereElementAt), ArraySelectWhereElementAtRewritten());
            ArrayElementAtParam().TestEquals(nameof(ArrayElementAtParam), ArrayElementAtParamRewritten());
            EnumerableElementAt().TestEquals(nameof(EnumerableElementAt), EnumerableElementAtRewritten());
        }

        [NoRewrite]
        public int ArrayElementAt()
        {
            return ArrayItems.ElementAt(23);
        } //EndMethod

        public int ArrayElementAtRewritten()
        {
            return ArrayItems.ElementAt(23);
        } //EndMethod


        [NoRewrite]
        public int ArraySelectElementAt()
        {
            return ArrayItems.Select(x => x + 20).ElementAt(23);
        } //EndMethod

        public int ArraySelectElementAtRewritten()
        {
            return ArrayItems.Select(x => x + 20).ElementAt(23);
        } //EndMethod


        [NoRewrite]
        public int ArrayWhereElementAt()
        {
            return ArrayItems.Where(x => x > 30).ElementAt(23);
        } //EndMethod

        public int ArrayWhereElementAtRewritten()
        {
            return ArrayItems.Where(x => x > 30).ElementAt(23);
        } //EndMethod


        [NoRewrite]
        public int ArraySelectWhereElementAt()
        {
            return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAt(23);
        } //EndMethod

        public int ArraySelectWhereElementAtRewritten()
        {
            return ArrayItems.Select(x => x + 30).Where(x => x > 30).ElementAt(23);
        } //EndMethod


        [NoRewrite]
        public int ArrayElementAtParam()
        {
            var a = 23;
            return ArrayItems.ElementAt(a);
        } //EndMethod

        public int ArrayElementAtParamRewritten()
        {
            var a = 23;
            return ArrayItems.ElementAt(a);
        } //EndMethod


        [NoRewrite]
        public int EnumerableElementAt()
        {
            return EnumerableItems.ElementAt(23);
        } //EndMethod

        public int EnumerableElementAtRewritten()
        {
            return EnumerableItems.ElementAt(23);
        } //EndMethod

    }
}