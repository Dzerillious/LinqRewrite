using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
    public class AnyTests
    {
        [Datapoints]
        private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
        [Datapoints]
        private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
        
        public bool Predicate(int x) => x > 50;

        public void RunTests()
        {
            ArrayAny().TestEquals(nameof(ArrayAny), ArrayAnyRewritten());        
            ArraySelectAny().TestEquals(nameof(ArraySelectAny), ArraySelectAnyRewritten());        
            ArrayWhereAny().TestEquals(nameof(ArrayWhereAny), ArrayWhereAnyRewritten());        
            ArrayEmptyAny().TestEquals(nameof(ArrayEmptyAny), ArrayEmptyAnyRewritten());        
            ArraySelectEmptyAny().TestEquals(nameof(ArraySelectEmptyAny), ArraySelectEmptyAnyRewritten());        
            ArrayWhereEmptyAny().TestEquals(nameof(ArrayWhereEmptyAny), ArrayWhereEmptyAnyRewritten());        
            ArrayAnyFalse().TestEquals(nameof(ArrayAnyFalse), ArrayAnyFalseRewritten());        
            ArrayAnyPredicate().TestEquals(nameof(ArrayAnyPredicate), ArrayAnyPredicateRewritten());        
            ArrayAnyParameter().TestEquals(nameof(ArrayAnyParameter), ArrayAnyParameterRewritten());        
            ArrayAnyChangingParameter().TestEquals(nameof(ArrayAnyChangingParameter), ArrayAnyChangingParameterRewritten());        
            EnumerableAnyChangingParameter().TestEquals(nameof(EnumerableAnyChangingParameter), EnumerableAnyChangingParameterRewritten());        
            EnumerableAny().TestEquals(nameof(EnumerableAny), EnumerableAnyRewritten()); 
            RepeatAny().TestEquals(nameof(RepeatAny), RepeatAnyRewritten());
            RangeAny().TestEquals(nameof(RangeAny), RangeAnyRewritten());
            RepeatAnyTrue().TestEquals(nameof(RepeatAnyTrue), RepeatAnyTrueRewritten());
        }
        
        [NoRewrite]
        public bool ArrayAny()
        {
            return ArrayItems.Any(x => x > 50);
        } //EndMethod

        public bool ArrayAnyRewritten()
        {
            return ArrayItems.Any(x => x > 50);
        } //EndMethod

        
        [NoRewrite]
        public bool ArraySelectAny()
        {
            return ArrayItems.Select(x => x + 10).Any(x => x > 50);
        } //EndMethod

        public bool ArraySelectAnyRewritten()
        {
            return ArrayItems.Select(x => x + 10).Any(x => x > 50);
        } //EndMethod

        
        [NoRewrite]
        public bool ArrayWhereAny()
        {
            return ArrayItems.Where(x => x > 40).Any(x => x > 50);
        } //EndMethod

        public bool ArrayWhereAnyRewritten()
        {
            return ArrayItems.Where(x => x > 40).Any(x => x > 50);
        } //EndMethod

        
        [NoRewrite]
        public bool ArrayEmptyAny()
        {
            return ArrayItems.Any();
        } //EndMethod

        public bool ArrayEmptyAnyRewritten()
        {
            return ArrayItems.Any();
        } //EndMethod

        
        [NoRewrite]
        public bool ArraySelectEmptyAny()
        {
            return ArrayItems.Select(x => x - 40).Any();
        } //EndMethod

        public bool ArraySelectEmptyAnyRewritten()
        {
            return ArrayItems.Select(x => x - 40).Any();
        } //EndMethod

        
        [NoRewrite]
        public bool ArrayWhereEmptyAny()
        {
            return ArrayItems.Where(x => x > 40).Any();
        } //EndMethod

        public bool ArrayWhereEmptyAnyRewritten()
        {
            return ArrayItems.Where(x => x > 40).Any();
        } //EndMethod

        
        [NoRewrite]
        public bool ArrayAnyFalse()
        {
            return ArrayItems.Any(x => x > 105);
        } //EndMethod

        public bool ArrayAnyFalseRewritten()
        {
            return ArrayItems.Any(x => x > 105);
        } //EndMethod

        
        [NoRewrite]
        public bool ArrayAnyPredicate()
        {
            return ArrayItems.Any(Predicate);
        } //EndMethod

        public bool ArrayAnyPredicateRewritten()
        {
            return ArrayItems.Any(Predicate);
        } //EndMethod

        
        [NoRewrite]
        public bool ArrayAnyParameter()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a);
        } //EndMethod

        public bool ArrayAnyParameterRewritten()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a);
        } //EndMethod

        
        [NoRewrite]
        public bool ArrayAnyChangingParameter()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a++);
        } //EndMethod

        public bool ArrayAnyChangingParameterRewritten()
        {
            var a = 5;
            return ArrayItems.Any(x => x > a++);
        } //EndMethod

        
        [NoRewrite]
        public bool EnumerableAnyChangingParameter()
        {
            var a = 5;
            return EnumerableItems.Any(x => x > a++);
        } //EndMethod

        public bool EnumerableAnyChangingParameterRewritten()
        {
            var a = 5;
            return EnumerableItems.Any(x => x > a++);
        } //EndMethod

        
        [NoRewrite]
        public bool EnumerableAny()
        {
            return EnumerableItems.Any(x => x > 50);
        } //EndMethod

        public bool EnumerableAnyRewritten()
        {
            return EnumerableItems.Any(x => x > 50);
        } //EndMethod

        
        [NoRewrite]
        public bool RangeAny()
        {
            return Enumerable.Range(0, 100).Any(x => x > 50);
        } //EndMethod

        public bool RangeAnyRewritten()
        {
            return Enumerable.Range(0, 100).Any(x => x > 50);
        } //EndMethod

        
        [NoRewrite]
        public bool RepeatAny()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > 50);
        } //EndMethod

        public bool RepeatAnyRewritten()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > 50);
        } //EndMethod

        
        [NoRewrite]
        public bool RepeatAnyTrue()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > -1);
        } //EndMethod

        public bool RepeatAnyTrueRewritten()
        {
            return Enumerable.Repeat(0, 100).Any(x => x > -1);
        } //EndMethod


    }
}