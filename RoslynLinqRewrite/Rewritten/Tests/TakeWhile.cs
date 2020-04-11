using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class TakeWhile
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayTakeWhile), ArrayTakeWhile, ArrayTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileReverse), ArrayTakeWhileReverse, ArrayTakeWhileReverseRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileTrue), ArrayTakeWhileTrue, ArrayTakeWhileTrueRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileFalse), ArrayTakeWhileFalse, ArrayTakeWhileFalseRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeWhile), ArraySelectTakeWhile, ArraySelectTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereTakeWhile), ArrayWhereTakeWhile, ArrayWhereTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileParam), ArrayTakeWhileParam, ArrayTakeWhileParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParam), ArrayTakeWhileChangingParam, ArrayTakeWhileChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParam2), ArrayTakeWhileChangingParam2, ArrayTakeWhileChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParams), ArrayTakeWhileChangingParams, ArrayTakeWhileChangingParamsRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileToArray), ArrayTakeWhileToArray, ArrayTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileReverseToArray), ArrayTakeWhileReverseToArray, ArrayTakeWhileReverseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileTrueToArray), ArrayTakeWhileTrueToArray, ArrayTakeWhileTrueToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileFalseToArray), ArrayTakeWhileFalseToArray, ArrayTakeWhileFalseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectTakeWhileToArray), ArraySelectTakeWhileToArray, ArraySelectTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereTakeWhileToArray), ArrayWhereTakeWhileToArray, ArrayWhereTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileParamToArray), ArrayTakeWhileParamToArray, ArrayTakeWhileParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParamToArray), ArrayTakeWhileChangingParamToArray, ArrayTakeWhileChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParamToArray2), ArrayTakeWhileChangingParamToArray2, ArrayTakeWhileChangingParamToArray2Rewritten);
        TestsExtensions.TestEquals(nameof(ArrayTakeWhileChangingParamsToArray), ArrayTakeWhileChangingParamsToArray, ArrayTakeWhileChangingParamsToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhile), EnumerableTakeWhile, EnumerableTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileReverse), EnumerableTakeWhileReverse, EnumerableTakeWhileReverseRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileTrue), EnumerableTakeWhileTrue, EnumerableTakeWhileTrueRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileFalse), EnumerableTakeWhileFalse, EnumerableTakeWhileFalseRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSelectTakeWhile), EnumerableSelectTakeWhile, EnumerableSelectTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableWhereTakeWhile), EnumerableWhereTakeWhile, EnumerableWhereTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileParam), EnumerableTakeWhileParam, EnumerableTakeWhileParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParam), EnumerableTakeWhileChangingParam, EnumerableTakeWhileChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParam2), EnumerableTakeWhileChangingParam2, EnumerableTakeWhileChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParams), EnumerableTakeWhileChangingParams, EnumerableTakeWhileChangingParamsRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileToArray), EnumerableTakeWhileToArray, EnumerableTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileReverseToArray), EnumerableTakeWhileReverseToArray, EnumerableTakeWhileReverseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileTrueToArray), EnumerableTakeWhileTrueToArray, EnumerableTakeWhileTrueToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileFalseToArray), EnumerableTakeWhileFalseToArray, EnumerableTakeWhileFalseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSelectTakeWhileToArray), EnumerableSelectTakeWhileToArray, EnumerableSelectTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableWhereTakeWhileToArray), EnumerableWhereTakeWhileToArray, EnumerableWhereTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileParamToArray), EnumerableTakeWhileParamToArray, EnumerableTakeWhileParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParamToArray), EnumerableTakeWhileChangingParamToArray, EnumerableTakeWhileChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParamToArray2), EnumerableTakeWhileChangingParamToArray2, EnumerableTakeWhileChangingParamToArray2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableTakeWhileChangingParamsToArray), EnumerableTakeWhileChangingParamsToArray, EnumerableTakeWhileChangingParamsToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhile), RangeTakeWhile, RangeTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileReverse), RangeTakeWhileReverse, RangeTakeWhileReverseRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileTrue), RangeTakeWhileTrue, RangeTakeWhileTrueRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileFalse), RangeTakeWhileFalse, RangeTakeWhileFalseRewritten);
        TestsExtensions.TestEquals(nameof(RangeSelectTakeWhile), RangeSelectTakeWhile, RangeSelectTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(RangeWhereTakeWhile), RangeWhereTakeWhile, RangeWhereTakeWhileRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileParam), RangeTakeWhileParam, RangeTakeWhileParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParam), RangeTakeWhileChangingParam, RangeTakeWhileChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParam2), RangeTakeWhileChangingParam2, RangeTakeWhileChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParams), RangeTakeWhileChangingParams, RangeTakeWhileChangingParamsRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileToArray), RangeTakeWhileToArray, RangeTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileReverseToArray), RangeTakeWhileReverseToArray, RangeTakeWhileReverseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileTrueToArray), RangeTakeWhileTrueToArray, RangeTakeWhileTrueToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileFalseToArray), RangeTakeWhileFalseToArray, RangeTakeWhileFalseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSelectTakeWhileToArray), RangeSelectTakeWhileToArray, RangeSelectTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeWhereTakeWhileToArray), RangeWhereTakeWhileToArray, RangeWhereTakeWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileParamToArray), RangeTakeWhileParamToArray, RangeTakeWhileParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParamToArray), RangeTakeWhileChangingParamToArray, RangeTakeWhileChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParamToArray2), RangeTakeWhileChangingParamToArray2, RangeTakeWhileChangingParamToArray2Rewritten);
        TestsExtensions.TestEquals(nameof(RangeTakeWhileChangingParamsToArray), RangeTakeWhileChangingParamsToArray, RangeTakeWhileChangingParamsToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhile()
    {
        return ArrayItems.TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileRewritten()
    {
        return ArrayTakeWhileRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileReverse()
    {
        return ArrayItems.TakeWhile(x => x > 50);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileReverseRewritten()
    {
        return ArrayTakeWhileReverseRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileTrue()
    {
        return ArrayItems.TakeWhile(x => true);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileTrueRewritten()
    {
        return ArrayTakeWhileTrueRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileFalse()
    {
        return ArrayItems.TakeWhile(x => false);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileFalseRewritten()
    {
        return ArrayTakeWhileFalseRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeWhile()
    {
        return ArrayItems.Select(x => x + 20).TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeWhileRewritten()
    {
        return ArraySelectTakeWhileRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereTakeWhile()
    {
        return ArrayItems.Where(x => x > 20).TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> ArrayWhereTakeWhileRewritten()
    {
        return ArrayWhereTakeWhileRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileParam()
    {
        var a = 50;
        return ArrayItems.TakeWhile(x => x < a);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileParamRewritten()
    {
        var a = 50;
        return ArrayTakeWhileParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileChangingParam()
    {
        var a = 50;
        return ArrayItems.TakeWhile(x => x < a++);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileChangingParamRewritten()
    {
        var a = 50;
        return ArrayTakeWhileChangingParamRewritten_ProceduralLinq1(ArrayItems, x => x < a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileChangingParam2()
    {
        var a = 50;
        return ArrayItems.TakeWhile(x => x < a--);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileChangingParam2Rewritten()
    {
        var a = 50;
        return ArrayTakeWhileChangingParam2Rewritten_ProceduralLinq1(ArrayItems, x => x < a--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileChangingParams()
    {
        var a = 50;
        var b = 50;
        return ArrayItems.TakeWhile(x => x < a++ - b--);
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileChangingParamsRewritten()
    {
        var a = 50;
        var b = 50;
        return ArrayTakeWhileChangingParamsRewritten_ProceduralLinq1(ArrayItems, x => x < a++ - b--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileToArray()
    {
        return ArrayItems.TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileToArrayRewritten()
    {
        return ArrayTakeWhileToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileReverseToArray()
    {
        return ArrayItems.TakeWhile(x => x > 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileReverseToArrayRewritten()
    {
        return ArrayTakeWhileReverseToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileTrueToArray()
    {
        return ArrayItems.TakeWhile(x => true).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileTrueToArrayRewritten()
    {
        return ArrayTakeWhileTrueToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileFalseToArray()
    {
        return ArrayItems.TakeWhile(x => false).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileFalseToArrayRewritten()
    {
        return ArrayTakeWhileFalseToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectTakeWhileToArray()
    {
        return ArrayItems.Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectTakeWhileToArrayRewritten()
    {
        return ArraySelectTakeWhileToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereTakeWhileToArray()
    {
        return ArrayItems.Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereTakeWhileToArrayRewritten()
    {
        return ArrayWhereTakeWhileToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileParamToArray()
    {
        var a = 50;
        return ArrayItems.TakeWhile(x => x < a).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileParamToArrayRewritten()
    {
        var a = 50;
        return ArrayTakeWhileParamToArrayRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileChangingParamToArray()
    {
        var a = 50;
        return ArrayItems.TakeWhile(x => x < a++).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileChangingParamToArrayRewritten()
    {
        var a = 50;
        return ArrayTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileChangingParamToArray2()
    {
        var a = 50;
        return ArrayItems.TakeWhile(x => x < a--).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileChangingParamToArray2Rewritten()
    {
        var a = 50;
        return ArrayTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayTakeWhileChangingParamsToArray()
    {
        var a = 50;
        var b = 50;
        return ArrayItems.TakeWhile(x => x < a++ - b--).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayTakeWhileChangingParamsToArrayRewritten()
    {
        var a = 50;
        var b = 50;
        return ArrayTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref a, ref b, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhile()
    {
        return EnumerableItems.TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileRewritten()
    {
        return EnumerableTakeWhileRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileReverse()
    {
        return EnumerableItems.TakeWhile(x => x > 50);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileReverseRewritten()
    {
        return EnumerableTakeWhileReverseRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileTrue()
    {
        return EnumerableItems.TakeWhile(x => true);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileTrueRewritten()
    {
        return EnumerableTakeWhileTrueRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileFalse()
    {
        return EnumerableItems.TakeWhile(x => false);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileFalseRewritten()
    {
        return EnumerableTakeWhileFalseRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSelectTakeWhile()
    {
        return EnumerableItems.Select(x => x + 20).TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> EnumerableSelectTakeWhileRewritten()
    {
        return EnumerableSelectTakeWhileRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableWhereTakeWhile()
    {
        return EnumerableItems.Where(x => x > 20).TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> EnumerableWhereTakeWhileRewritten()
    {
        return EnumerableWhereTakeWhileRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileParam()
    {
        var a = 50;
        return EnumerableItems.TakeWhile(x => x < a);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileParamRewritten()
    {
        var a = 50;
        return EnumerableTakeWhileParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileChangingParam()
    {
        var a = 50;
        return EnumerableItems.TakeWhile(x => x < a++);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileChangingParamRewritten()
    {
        var a = 50;
        return EnumerableTakeWhileChangingParamRewritten_ProceduralLinq1(EnumerableItems, x => x < a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileChangingParam2()
    {
        var a = 50;
        return EnumerableItems.TakeWhile(x => x < a--);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileChangingParam2Rewritten()
    {
        var a = 50;
        return EnumerableTakeWhileChangingParam2Rewritten_ProceduralLinq1(EnumerableItems, x => x < a--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileChangingParams()
    {
        var a = 50;
        var b = 50;
        return EnumerableItems.TakeWhile(x => x < a++ - b--);
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileChangingParamsRewritten()
    {
        var a = 50;
        var b = 50;
        return EnumerableTakeWhileChangingParamsRewritten_ProceduralLinq1(EnumerableItems, x => x < a++ - b--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileToArray()
    {
        return EnumerableItems.TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileToArrayRewritten()
    {
        return EnumerableTakeWhileToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileReverseToArray()
    {
        return EnumerableItems.TakeWhile(x => x > 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileReverseToArrayRewritten()
    {
        return EnumerableTakeWhileReverseToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileTrueToArray()
    {
        return EnumerableItems.TakeWhile(x => true).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileTrueToArrayRewritten()
    {
        return EnumerableTakeWhileTrueToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileFalseToArray()
    {
        return EnumerableItems.TakeWhile(x => false).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileFalseToArrayRewritten()
    {
        return EnumerableTakeWhileFalseToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSelectTakeWhileToArray()
    {
        return EnumerableItems.Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSelectTakeWhileToArrayRewritten()
    {
        return EnumerableSelectTakeWhileToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableWhereTakeWhileToArray()
    {
        return EnumerableItems.Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableWhereTakeWhileToArrayRewritten()
    {
        return EnumerableWhereTakeWhileToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileParamToArray()
    {
        var a = 50;
        return EnumerableItems.TakeWhile(x => x < a).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileParamToArrayRewritten()
    {
        var a = 50;
        return EnumerableTakeWhileParamToArrayRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileChangingParamToArray()
    {
        var a = 50;
        return EnumerableItems.TakeWhile(x => x < a++).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileChangingParamToArrayRewritten()
    {
        var a = 50;
        return EnumerableTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileChangingParamToArray2()
    {
        var a = 50;
        return EnumerableItems.TakeWhile(x => x < a--).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileChangingParamToArray2Rewritten()
    {
        var a = 50;
        return EnumerableTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableTakeWhileChangingParamsToArray()
    {
        var a = 50;
        var b = 50;
        return EnumerableItems.TakeWhile(x => x < a++ - b--).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableTakeWhileChangingParamsToArrayRewritten()
    {
        var a = 50;
        var b = 50;
        return EnumerableTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref a, ref b, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhile()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileRewritten()
    {
        return RangeTakeWhileRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileReverse()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => x > 50);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileReverseRewritten()
    {
        return RangeTakeWhileReverseRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileTrue()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => true);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileTrueRewritten()
    {
        return RangeTakeWhileTrueRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileFalse()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => false);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileFalseRewritten()
    {
        return RangeTakeWhileFalseRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSelectTakeWhile()
    {
        return Enumerable.Range(0, 100).Select(x => x + 20).TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> RangeSelectTakeWhileRewritten()
    {
        return RangeSelectTakeWhileRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeWhereTakeWhile()
    {
        return Enumerable.Range(0, 100).Where(x => x > 20).TakeWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> RangeWhereTakeWhileRewritten()
    {
        return RangeWhereTakeWhileRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileParamRewritten()
    {
        var a = 50;
        return RangeTakeWhileParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileChangingParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a++);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileChangingParamRewritten()
    {
        var a = 50;
        return RangeTakeWhileChangingParamRewritten_ProceduralLinq1(x => x < a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileChangingParam2()
    {
        var a = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a--);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileChangingParam2Rewritten()
    {
        var a = 50;
        return RangeTakeWhileChangingParam2Rewritten_ProceduralLinq1(x => x < a--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileChangingParams()
    {
        var a = 50;
        var b = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a++ - b--);
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileChangingParamsRewritten()
    {
        var a = 50;
        var b = 50;
        return RangeTakeWhileChangingParamsRewritten_ProceduralLinq1(x => x < a++ - b--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileToArray()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileToArrayRewritten()
    {
        return RangeTakeWhileToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileReverseToArray()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => x > 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileReverseToArrayRewritten()
    {
        return RangeTakeWhileReverseToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileTrueToArray()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => true).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileTrueToArrayRewritten()
    {
        return RangeTakeWhileTrueToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileFalseToArray()
    {
        return Enumerable.Range(0, 100).TakeWhile(x => false).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileFalseToArrayRewritten()
    {
        return RangeTakeWhileFalseToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSelectTakeWhileToArray()
    {
        return Enumerable.Range(0, 100).Select(x => x + 20).TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSelectTakeWhileToArrayRewritten()
    {
        return RangeSelectTakeWhileToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeWhereTakeWhileToArray()
    {
        return Enumerable.Range(0, 100).Where(x => x > 20).TakeWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeWhereTakeWhileToArrayRewritten()
    {
        return RangeWhereTakeWhileToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileParamToArray()
    {
        var a = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileParamToArrayRewritten()
    {
        var a = 50;
        return RangeTakeWhileParamToArrayRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileChangingParamToArray()
    {
        var a = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a++).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileChangingParamToArrayRewritten()
    {
        var a = 50;
        return RangeTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileChangingParamToArray2()
    {
        var a = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a--).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileChangingParamToArray2Rewritten()
    {
        var a = 50;
        return RangeTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeTakeWhileChangingParamsToArray()
    {
        var a = 50;
        var b = 50;
        return Enumerable.Range(0, 100).TakeWhile(x => x < a++ - b--).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeTakeWhileChangingParamsToArrayRewritten()
    {
        var a = 50;
        var b = 50;
        return RangeTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref a, ref b);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2297;
        v2297 = (0);
        for (; v2297 < (ArrayItems.Length); v2297 += 1)
        {
            if (!((((ArrayItems[v2297])) < 50)))
                break;
            yield return ((ArrayItems[v2297]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileReverseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2298;
        v2298 = (0);
        for (; v2298 < (ArrayItems.Length); v2298 += 1)
        {
            if (!((((ArrayItems[v2298])) > 50)))
                break;
            yield return ((ArrayItems[v2298]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileTrueRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2299;
        v2299 = (0);
        for (; v2299 < (ArrayItems.Length); v2299 += 1)
        {
            if (!((true)))
                break;
            yield return ((ArrayItems[v2299]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2300;
        v2300 = (0);
        for (; v2300 < (ArrayItems.Length); v2300 += 1)
        {
            if (!((false)))
                break;
            yield return ((ArrayItems[v2300]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectTakeWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2301;
        int v2302;
        v2301 = (0);
        for (; v2301 < (ArrayItems.Length); v2301 += 1)
        {
            v2302 = (20 + ArrayItems[v2301]);
            if (!(((v2302) < 50)))
                break;
            yield return (v2302);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereTakeWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2303;
        v2303 = (0);
        for (; v2303 < (ArrayItems.Length); v2303 += 1)
        {
            if (!((((ArrayItems[v2303])) > 20)))
                continue;
            if (!(((((ArrayItems[v2303]))) < 50)))
                break;
            yield return (((ArrayItems[v2303])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2304;
        v2304 = (0);
        for (; v2304 < (ArrayItems.Length); v2304 += 1)
        {
            if (!((((ArrayItems[v2304])) < a)))
                break;
            yield return ((ArrayItems[v2304]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2306)
    {
        int v2305;
        v2305 = (0);
        for (; v2305 < (ArrayItems.Length); v2305 += 1)
        {
            if (!(v2306(((ArrayItems[v2305])))))
                break;
            yield return ((ArrayItems[v2305]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParam2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2308)
    {
        int v2307;
        v2307 = (0);
        for (; v2307 < (ArrayItems.Length); v2307 += 1)
        {
            if (!(v2308(((ArrayItems[v2307])))))
                break;
            yield return ((ArrayItems[v2307]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParamsRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2310)
    {
        int v2309;
        v2309 = (0);
        for (; v2309 < (ArrayItems.Length); v2309 += 1)
        {
            if (!(v2310(((ArrayItems[v2309])))))
                break;
            yield return ((ArrayItems[v2309]));
        }

        yield break;
    }

    int[] ArrayTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2311;
        int v2312;
        int v2313;
        int v2314;
        int[] v2315;
        v2312 = 0;
        v2313 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2313 -= (v2313 % 2);
        v2314 = 8;
        v2315 = new int[8];
        v2311 = (0);
        for (; v2311 < (ArrayItems.Length); v2311 += 1)
        {
            if (!((((ArrayItems[v2311])) < 50)))
                break;
            if (v2312 >= v2314)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2315, ref v2313, out v2314);
            v2315[v2312] = ((ArrayItems[v2311]));
            v2312++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2315, v2312);
    }

    int[] ArrayTakeWhileReverseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2316;
        int v2317;
        int v2318;
        int v2319;
        int[] v2320;
        v2317 = 0;
        v2318 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2318 -= (v2318 % 2);
        v2319 = 8;
        v2320 = new int[8];
        v2316 = (0);
        for (; v2316 < (ArrayItems.Length); v2316 += 1)
        {
            if (!((((ArrayItems[v2316])) > 50)))
                break;
            if (v2317 >= v2319)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2320, ref v2318, out v2319);
            v2320[v2317] = ((ArrayItems[v2316]));
            v2317++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2320, v2317);
    }

    int[] ArrayTakeWhileTrueToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2321;
        int v2322;
        int v2323;
        int v2324;
        int[] v2325;
        v2322 = 0;
        v2323 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2323 -= (v2323 % 2);
        v2324 = 8;
        v2325 = new int[8];
        v2321 = (0);
        for (; v2321 < (ArrayItems.Length); v2321 += 1)
        {
            if (!((true)))
                break;
            if (v2322 >= v2324)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2325, ref v2323, out v2324);
            v2325[v2322] = ((ArrayItems[v2321]));
            v2322++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2325, v2322);
    }

    int[] ArrayTakeWhileFalseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2326;
        int v2327;
        int v2328;
        int v2329;
        int[] v2330;
        v2327 = 0;
        v2328 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2328 -= (v2328 % 2);
        v2329 = 8;
        v2330 = new int[8];
        v2326 = (0);
        for (; v2326 < (ArrayItems.Length); v2326 += 1)
        {
            if (!((false)))
                break;
            if (v2327 >= v2329)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2330, ref v2328, out v2329);
            v2330[v2327] = ((ArrayItems[v2326]));
            v2327++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2330, v2327);
    }

    int[] ArraySelectTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2331;
        int v2332;
        int v2333;
        int v2334;
        int v2335;
        int[] v2336;
        v2333 = 0;
        v2334 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2334 -= (v2334 % 2);
        v2335 = 8;
        v2336 = new int[8];
        v2331 = (0);
        for (; v2331 < (ArrayItems.Length); v2331 += 1)
        {
            v2332 = (20 + ArrayItems[v2331]);
            if (!(((v2332) < 50)))
                break;
            if (v2333 >= v2335)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2336, ref v2334, out v2335);
            v2336[v2333] = (v2332);
            v2333++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2336, v2333);
    }

    int[] ArrayWhereTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2337;
        int v2338;
        int v2339;
        int v2340;
        int[] v2341;
        v2338 = 0;
        v2339 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2339 -= (v2339 % 2);
        v2340 = 8;
        v2341 = new int[8];
        v2337 = (0);
        for (; v2337 < (ArrayItems.Length); v2337 += 1)
        {
            if (!((((ArrayItems[v2337])) > 20)))
                continue;
            if (!(((((ArrayItems[v2337]))) < 50)))
                break;
            if (v2338 >= v2340)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2341, ref v2339, out v2340);
            v2341[v2338] = (((ArrayItems[v2337])));
            v2338++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2341, v2338);
    }

    int[] ArrayTakeWhileParamToArrayRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2342;
        int v2343;
        int v2344;
        int v2345;
        int[] v2346;
        v2343 = 0;
        v2344 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2344 -= (v2344 % 2);
        v2345 = 8;
        v2346 = new int[8];
        v2342 = (0);
        for (; v2342 < (ArrayItems.Length); v2342 += 1)
        {
            if (!((((ArrayItems[v2342])) < a)))
                break;
            if (v2343 >= v2345)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2346, ref v2344, out v2345);
            v2346[v2343] = ((ArrayItems[v2342]));
            v2343++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2346, v2343);
    }

    int[] ArrayTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2347;
        int v2348;
        int v2349;
        int v2350;
        int[] v2351;
        v2348 = 0;
        v2349 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2349 -= (v2349 % 2);
        v2350 = 8;
        v2351 = new int[8];
        v2347 = (0);
        for (; v2347 < (ArrayItems.Length); v2347 += 1)
        {
            if (!((((ArrayItems[v2347])) < a++)))
                break;
            if (v2348 >= v2350)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2351, ref v2349, out v2350);
            v2351[v2348] = ((ArrayItems[v2347]));
            v2348++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2351, v2348);
    }

    int[] ArrayTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2352;
        int v2353;
        int v2354;
        int v2355;
        int[] v2356;
        v2353 = 0;
        v2354 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2354 -= (v2354 % 2);
        v2355 = 8;
        v2356 = new int[8];
        v2352 = (0);
        for (; v2352 < (ArrayItems.Length); v2352 += 1)
        {
            if (!((((ArrayItems[v2352])) < a--)))
                break;
            if (v2353 >= v2355)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2356, ref v2354, out v2355);
            v2356[v2353] = ((ArrayItems[v2352]));
            v2353++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2356, v2353);
    }

    int[] ArrayTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, int[] ArrayItems)
    {
        int v2357;
        int v2358;
        int v2359;
        int v2360;
        int[] v2361;
        v2358 = 0;
        v2359 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2359 -= (v2359 % 2);
        v2360 = 8;
        v2361 = new int[8];
        v2357 = (0);
        for (; v2357 < (ArrayItems.Length); v2357 += 1)
        {
            if (!((((ArrayItems[v2357])) < a++ - b--)))
                break;
            if (v2358 >= v2360)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2361, ref v2359, out v2360);
            v2361[v2358] = ((ArrayItems[v2357]));
            v2358++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2361, v2358);
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2362;
        int v2363;
        v2362 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2362.MoveNext())
            {
                v2363 = (v2362.Current);
                if (!(((v2363) < 50)))
                    break;
                yield return (v2363);
            }
        }
        finally
        {
            v2362.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileReverseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2364;
        int v2365;
        v2364 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2364.MoveNext())
            {
                v2365 = (v2364.Current);
                if (!(((v2365) > 50)))
                    break;
                yield return (v2365);
            }
        }
        finally
        {
            v2364.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileTrueRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2366;
        int v2367;
        v2366 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2366.MoveNext())
            {
                v2367 = (v2366.Current);
                if (!((true)))
                    break;
                yield return (v2367);
            }
        }
        finally
        {
            v2366.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileFalseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2368;
        int v2369;
        v2368 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2368.MoveNext())
            {
                v2369 = (v2368.Current);
                if (!((false)))
                    break;
                yield return (v2369);
            }
        }
        finally
        {
            v2368.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSelectTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2370;
        int v2371;
        v2370 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2370.MoveNext())
            {
                v2371 = (20 + v2370.Current);
                if (!(((v2371) < 50)))
                    break;
                yield return (v2371);
            }
        }
        finally
        {
            v2370.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2372;
        int v2373;
        v2372 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2372.MoveNext())
            {
                v2373 = (v2372.Current);
                if (!(((v2373) > 20)))
                    continue;
                if (!((((v2373)) < 50)))
                    break;
                yield return ((v2373));
            }
        }
        finally
        {
            v2372.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2374;
        int v2375;
        v2374 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2374.MoveNext())
            {
                v2375 = (v2374.Current);
                if (!(((v2375) < a)))
                    break;
                yield return (v2375);
            }
        }
        finally
        {
            v2374.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParamRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2378)
    {
        IEnumerator<int> v2376;
        int v2377;
        v2376 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2376.MoveNext())
            {
                v2377 = (v2376.Current);
                if (!(v2378((v2377))))
                    break;
                yield return (v2377);
            }
        }
        finally
        {
            v2376.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParam2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2381)
    {
        IEnumerator<int> v2379;
        int v2380;
        v2379 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2379.MoveNext())
            {
                v2380 = (v2379.Current);
                if (!(v2381((v2380))))
                    break;
                yield return (v2380);
            }
        }
        finally
        {
            v2379.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParamsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2384)
    {
        IEnumerator<int> v2382;
        int v2383;
        v2382 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2382.MoveNext())
            {
                v2383 = (v2382.Current);
                if (!(v2384((v2383))))
                    break;
                yield return (v2383);
            }
        }
        finally
        {
            v2382.Dispose();
        }

        yield break;
    }

    int[] EnumerableTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2385;
        int v2386;
        int v2387;
        int v2388;
        int[] v2389;
        v2385 = EnumerableItems.GetEnumerator();
        v2387 = 0;
        v2388 = 8;
        v2389 = new int[8];
        try
        {
            while (v2385.MoveNext())
            {
                v2386 = (v2385.Current);
                if (!(((v2386) < 50)))
                    break;
                if (v2387 >= v2388)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2389, ref v2388);
                v2389[v2387] = (v2386);
                v2387++;
            }
        }
        finally
        {
            v2385.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2389, v2387);
    }

    int[] EnumerableTakeWhileReverseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2390;
        int v2391;
        int v2392;
        int v2393;
        int[] v2394;
        v2390 = EnumerableItems.GetEnumerator();
        v2392 = 0;
        v2393 = 8;
        v2394 = new int[8];
        try
        {
            while (v2390.MoveNext())
            {
                v2391 = (v2390.Current);
                if (!(((v2391) > 50)))
                    break;
                if (v2392 >= v2393)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2394, ref v2393);
                v2394[v2392] = (v2391);
                v2392++;
            }
        }
        finally
        {
            v2390.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2394, v2392);
    }

    int[] EnumerableTakeWhileTrueToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2395;
        int v2396;
        int v2397;
        int v2398;
        int[] v2399;
        v2395 = EnumerableItems.GetEnumerator();
        v2397 = 0;
        v2398 = 8;
        v2399 = new int[8];
        try
        {
            while (v2395.MoveNext())
            {
                v2396 = (v2395.Current);
                if (!((true)))
                    break;
                if (v2397 >= v2398)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2399, ref v2398);
                v2399[v2397] = (v2396);
                v2397++;
            }
        }
        finally
        {
            v2395.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2399, v2397);
    }

    int[] EnumerableTakeWhileFalseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2400;
        int v2401;
        int v2402;
        int v2403;
        int[] v2404;
        v2400 = EnumerableItems.GetEnumerator();
        v2402 = 0;
        v2403 = 8;
        v2404 = new int[8];
        try
        {
            while (v2400.MoveNext())
            {
                v2401 = (v2400.Current);
                if (!((false)))
                    break;
                if (v2402 >= v2403)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2404, ref v2403);
                v2404[v2402] = (v2401);
                v2402++;
            }
        }
        finally
        {
            v2400.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2404, v2402);
    }

    int[] EnumerableSelectTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2405;
        int v2406;
        int v2407;
        int v2408;
        int[] v2409;
        v2405 = EnumerableItems.GetEnumerator();
        v2407 = 0;
        v2408 = 8;
        v2409 = new int[8];
        try
        {
            while (v2405.MoveNext())
            {
                v2406 = (20 + v2405.Current);
                if (!(((v2406) < 50)))
                    break;
                if (v2407 >= v2408)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2409, ref v2408);
                v2409[v2407] = (v2406);
                v2407++;
            }
        }
        finally
        {
            v2405.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2409, v2407);
    }

    int[] EnumerableWhereTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2410;
        int v2411;
        int v2412;
        int v2413;
        int[] v2414;
        v2410 = EnumerableItems.GetEnumerator();
        v2412 = 0;
        v2413 = 8;
        v2414 = new int[8];
        try
        {
            while (v2410.MoveNext())
            {
                v2411 = (v2410.Current);
                if (!(((v2411) > 20)))
                    continue;
                if (!((((v2411)) < 50)))
                    break;
                if (v2412 >= v2413)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2414, ref v2413);
                v2414[v2412] = ((v2411));
                v2412++;
            }
        }
        finally
        {
            v2410.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2414, v2412);
    }

    int[] EnumerableTakeWhileParamToArrayRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2415;
        int v2416;
        int v2417;
        int v2418;
        int[] v2419;
        v2415 = EnumerableItems.GetEnumerator();
        v2417 = 0;
        v2418 = 8;
        v2419 = new int[8];
        try
        {
            while (v2415.MoveNext())
            {
                v2416 = (v2415.Current);
                if (!(((v2416) < a)))
                    break;
                if (v2417 >= v2418)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2419, ref v2418);
                v2419[v2417] = (v2416);
                v2417++;
            }
        }
        finally
        {
            v2415.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2419, v2417);
    }

    int[] EnumerableTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2420;
        int v2421;
        int v2422;
        int v2423;
        int[] v2424;
        v2420 = EnumerableItems.GetEnumerator();
        v2422 = 0;
        v2423 = 8;
        v2424 = new int[8];
        try
        {
            while (v2420.MoveNext())
            {
                v2421 = (v2420.Current);
                if (!(((v2421) < a++)))
                    break;
                if (v2422 >= v2423)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2424, ref v2423);
                v2424[v2422] = (v2421);
                v2422++;
            }
        }
        finally
        {
            v2420.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2424, v2422);
    }

    int[] EnumerableTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2425;
        int v2426;
        int v2427;
        int v2428;
        int[] v2429;
        v2425 = EnumerableItems.GetEnumerator();
        v2427 = 0;
        v2428 = 8;
        v2429 = new int[8];
        try
        {
            while (v2425.MoveNext())
            {
                v2426 = (v2425.Current);
                if (!(((v2426) < a--)))
                    break;
                if (v2427 >= v2428)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2429, ref v2428);
                v2429[v2427] = (v2426);
                v2427++;
            }
        }
        finally
        {
            v2425.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2429, v2427);
    }

    int[] EnumerableTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2430;
        int v2431;
        int v2432;
        int v2433;
        int[] v2434;
        v2430 = EnumerableItems.GetEnumerator();
        v2432 = 0;
        v2433 = 8;
        v2434 = new int[8];
        try
        {
            while (v2430.MoveNext())
            {
                v2431 = (v2430.Current);
                if (!(((v2431) < a++ - b--)))
                    break;
                if (v2432 >= v2433)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2434, ref v2433);
                v2434[v2432] = (v2431);
                v2432++;
            }
        }
        finally
        {
            v2430.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2434, v2432);
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileRewritten_ProceduralLinq1()
    {
        int v2435;
        v2435 = (0);
        for (; v2435 < (100); v2435 += (1))
        {
            if (!((((v2435)) < 50)))
                break;
            yield return ((v2435));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileReverseRewritten_ProceduralLinq1()
    {
        int v2436;
        v2436 = (0);
        for (; v2436 < (100); v2436 += (1))
        {
            if (!((((v2436)) > 50)))
                break;
            yield return ((v2436));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileTrueRewritten_ProceduralLinq1()
    {
        int v2437;
        v2437 = (0);
        for (; v2437 < (100); v2437 += (1))
        {
            if (!((true)))
                break;
            yield return ((v2437));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileFalseRewritten_ProceduralLinq1()
    {
        int v2438;
        v2438 = (0);
        for (; v2438 < (100); v2438 += (1))
        {
            if (!((false)))
                break;
            yield return ((v2438));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSelectTakeWhileRewritten_ProceduralLinq1()
    {
        int v2439;
        int v2440;
        v2439 = (0);
        for (; v2439 < (100); v2439 += (1))
        {
            v2440 = (20 + v2439);
            if (!(((v2440) < 50)))
                break;
            yield return (v2440);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereTakeWhileRewritten_ProceduralLinq1()
    {
        int v2441;
        v2441 = (0);
        for (; v2441 < (100); v2441 += (1))
        {
            if (!((((v2441)) > 20)))
                continue;
            if (!(((((v2441))) < 50)))
                break;
            yield return (((v2441)));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileParamRewritten_ProceduralLinq1(int a)
    {
        int v2442;
        v2442 = (0);
        for (; v2442 < (100); v2442 += (1))
        {
            if (!((((v2442)) < a)))
                break;
            yield return ((v2442));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParamRewritten_ProceduralLinq1(System.Func<int, bool> v2444)
    {
        int v2443;
        v2443 = (0);
        for (; v2443 < (100); v2443 += (1))
        {
            if (!(v2444(((v2443)))))
                break;
            yield return ((v2443));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParam2Rewritten_ProceduralLinq1(System.Func<int, bool> v2446)
    {
        int v2445;
        v2445 = (0);
        for (; v2445 < (100); v2445 += (1))
        {
            if (!(v2446(((v2445)))))
                break;
            yield return ((v2445));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParamsRewritten_ProceduralLinq1(System.Func<int, bool> v2448)
    {
        int v2447;
        v2447 = (0);
        for (; v2447 < (100); v2447 += (1))
        {
            if (!(v2448(((v2447)))))
                break;
            yield return ((v2447));
        }

        yield break;
    }

    int[] RangeTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2449;
        int v2450;
        int v2451;
        int v2452;
        int[] v2453;
        v2450 = 0;
        v2451 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2451 -= (v2451 % 2);
        v2452 = 8;
        v2453 = new int[8];
        v2449 = (0);
        for (; v2449 < (100); v2449 += (1))
        {
            if (!((((v2449)) < 50)))
                break;
            if (v2450 >= v2452)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2453, ref v2451, out v2452);
            v2453[v2450] = ((v2449));
            v2450++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2453, v2450);
    }

    int[] RangeTakeWhileReverseToArrayRewritten_ProceduralLinq1()
    {
        int v2454;
        int v2455;
        int v2456;
        int v2457;
        int[] v2458;
        v2455 = 0;
        v2456 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2456 -= (v2456 % 2);
        v2457 = 8;
        v2458 = new int[8];
        v2454 = (0);
        for (; v2454 < (100); v2454 += (1))
        {
            if (!((((v2454)) > 50)))
                break;
            if (v2455 >= v2457)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2458, ref v2456, out v2457);
            v2458[v2455] = ((v2454));
            v2455++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2458, v2455);
    }

    int[] RangeTakeWhileTrueToArrayRewritten_ProceduralLinq1()
    {
        int v2459;
        int v2460;
        int v2461;
        int v2462;
        int[] v2463;
        v2460 = 0;
        v2461 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2461 -= (v2461 % 2);
        v2462 = 8;
        v2463 = new int[8];
        v2459 = (0);
        for (; v2459 < (100); v2459 += (1))
        {
            if (!((true)))
                break;
            if (v2460 >= v2462)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2463, ref v2461, out v2462);
            v2463[v2460] = ((v2459));
            v2460++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2463, v2460);
    }

    int[] RangeTakeWhileFalseToArrayRewritten_ProceduralLinq1()
    {
        int v2464;
        int v2465;
        int v2466;
        int v2467;
        int[] v2468;
        v2465 = 0;
        v2466 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2466 -= (v2466 % 2);
        v2467 = 8;
        v2468 = new int[8];
        v2464 = (0);
        for (; v2464 < (100); v2464 += (1))
        {
            if (!((false)))
                break;
            if (v2465 >= v2467)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2468, ref v2466, out v2467);
            v2468[v2465] = ((v2464));
            v2465++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2468, v2465);
    }

    int[] RangeSelectTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2469;
        int v2470;
        int v2471;
        int v2472;
        int v2473;
        int[] v2474;
        v2471 = 0;
        v2472 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2472 -= (v2472 % 2);
        v2473 = 8;
        v2474 = new int[8];
        v2469 = (0);
        for (; v2469 < (100); v2469 += (1))
        {
            v2470 = (20 + v2469);
            if (!(((v2470) < 50)))
                break;
            if (v2471 >= v2473)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2474, ref v2472, out v2473);
            v2474[v2471] = (v2470);
            v2471++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2474, v2471);
    }

    int[] RangeWhereTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2475;
        int v2476;
        int v2477;
        int v2478;
        int[] v2479;
        v2476 = 0;
        v2477 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2477 -= (v2477 % 2);
        v2478 = 8;
        v2479 = new int[8];
        v2475 = (0);
        for (; v2475 < (100); v2475 += (1))
        {
            if (!((((v2475)) > 20)))
                continue;
            if (!(((((v2475))) < 50)))
                break;
            if (v2476 >= v2478)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2479, ref v2477, out v2478);
            v2479[v2476] = (((v2475)));
            v2476++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2479, v2476);
    }

    int[] RangeTakeWhileParamToArrayRewritten_ProceduralLinq1(int a)
    {
        int v2480;
        int v2481;
        int v2482;
        int v2483;
        int[] v2484;
        v2481 = 0;
        v2482 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2482 -= (v2482 % 2);
        v2483 = 8;
        v2484 = new int[8];
        v2480 = (0);
        for (; v2480 < (100); v2480 += (1))
        {
            if (!((((v2480)) < a)))
                break;
            if (v2481 >= v2483)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2484, ref v2482, out v2483);
            v2484[v2481] = ((v2480));
            v2481++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2484, v2481);
    }

    int[] RangeTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a)
    {
        int v2485;
        int v2486;
        int v2487;
        int v2488;
        int[] v2489;
        v2486 = 0;
        v2487 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2487 -= (v2487 % 2);
        v2488 = 8;
        v2489 = new int[8];
        v2485 = (0);
        for (; v2485 < (100); v2485 += (1))
        {
            if (!((((v2485)) < a++)))
                break;
            if (v2486 >= v2488)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2489, ref v2487, out v2488);
            v2489[v2486] = ((v2485));
            v2486++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2489, v2486);
    }

    int[] RangeTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a)
    {
        int v2490;
        int v2491;
        int v2492;
        int v2493;
        int[] v2494;
        v2491 = 0;
        v2492 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2492 -= (v2492 % 2);
        v2493 = 8;
        v2494 = new int[8];
        v2490 = (0);
        for (; v2490 < (100); v2490 += (1))
        {
            if (!((((v2490)) < a--)))
                break;
            if (v2491 >= v2493)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2494, ref v2492, out v2493);
            v2494[v2491] = ((v2490));
            v2491++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2494, v2491);
    }

    int[] RangeTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b)
    {
        int v2495;
        int v2496;
        int v2497;
        int v2498;
        int[] v2499;
        v2496 = 0;
        v2497 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2497 -= (v2497 % 2);
        v2498 = 8;
        v2499 = new int[8];
        v2495 = (0);
        for (; v2495 < (100); v2495 += (1))
        {
            if (!((((v2495)) < a++ - b--)))
                break;
            if (v2496 >= v2498)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2499, ref v2497, out v2498);
            v2499[v2496] = ((v2495));
            v2496++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2499, v2496);
    }
}}