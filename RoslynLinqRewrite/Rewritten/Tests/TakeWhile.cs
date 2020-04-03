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
        int v2098;
        v2098 = 0;
        for (; v2098 < ArrayItems.Length; v2098++)
        {
            if (!((ArrayItems[v2098] < 50)))
                break;
            yield return ArrayItems[v2098];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileReverseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2099;
        v2099 = 0;
        for (; v2099 < ArrayItems.Length; v2099++)
        {
            if (!((ArrayItems[v2099] > 50)))
                break;
            yield return ArrayItems[v2099];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileTrueRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2100;
        v2100 = 0;
        for (; v2100 < ArrayItems.Length; v2100++)
        {
            if (!((true)))
                break;
            yield return ArrayItems[v2100];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2101;
        v2101 = 0;
        for (; v2101 < ArrayItems.Length; v2101++)
        {
            if (!((false)))
                break;
            yield return ArrayItems[v2101];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectTakeWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2102;
        int v2103;
        v2102 = 0;
        for (; v2102 < ArrayItems.Length; v2102++)
        {
            v2103 = (ArrayItems[v2102] + 20);
            if (!((v2103 < 50)))
                break;
            yield return v2103;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereTakeWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2104;
        v2104 = 0;
        for (; v2104 < ArrayItems.Length; v2104++)
        {
            if (!((ArrayItems[v2104] > 20)))
                continue;
            if (!((ArrayItems[v2104] < 50)))
                break;
            yield return ArrayItems[v2104];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2105;
        v2105 = 0;
        for (; v2105 < ArrayItems.Length; v2105++)
        {
            if (!((ArrayItems[v2105] < a)))
                break;
            yield return ArrayItems[v2105];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2107)
    {
        int v2106;
        v2106 = 0;
        for (; v2106 < ArrayItems.Length; v2106++)
        {
            if (!(v2107(ArrayItems[v2106])))
                break;
            yield return ArrayItems[v2106];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParam2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2109)
    {
        int v2108;
        v2108 = 0;
        for (; v2108 < ArrayItems.Length; v2108++)
        {
            if (!(v2109(ArrayItems[v2108])))
                break;
            yield return ArrayItems[v2108];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParamsRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2111)
    {
        int v2110;
        v2110 = 0;
        for (; v2110 < ArrayItems.Length; v2110++)
        {
            if (!(v2111(ArrayItems[v2110])))
                break;
            yield return ArrayItems[v2110];
        }
    }

    int[] ArrayTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2112;
        int v2113;
        int v2114;
        int v2115;
        int[] v2116;
        v2113 = 0;
        v2114 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2114 -= (v2114 % 2);
        v2115 = 8;
        v2116 = new int[8];
        v2112 = 0;
        for (; v2112 < ArrayItems.Length; v2112++)
        {
            if (!((ArrayItems[v2112] < 50)))
                break;
            if (v2113 >= v2115)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2116, ref v2114, out v2115);
            v2116[v2113] = ArrayItems[v2112];
            v2113++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2116, v2113);
    }

    int[] ArrayTakeWhileReverseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2117;
        int v2118;
        int v2119;
        int v2120;
        int[] v2121;
        v2118 = 0;
        v2119 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2119 -= (v2119 % 2);
        v2120 = 8;
        v2121 = new int[8];
        v2117 = 0;
        for (; v2117 < ArrayItems.Length; v2117++)
        {
            if (!((ArrayItems[v2117] > 50)))
                break;
            if (v2118 >= v2120)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2121, ref v2119, out v2120);
            v2121[v2118] = ArrayItems[v2117];
            v2118++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2121, v2118);
    }

    int[] ArrayTakeWhileTrueToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2122;
        int v2123;
        int v2124;
        int v2125;
        int[] v2126;
        v2123 = 0;
        v2124 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2124 -= (v2124 % 2);
        v2125 = 8;
        v2126 = new int[8];
        v2122 = 0;
        for (; v2122 < ArrayItems.Length; v2122++)
        {
            if (!((true)))
                break;
            if (v2123 >= v2125)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2126, ref v2124, out v2125);
            v2126[v2123] = ArrayItems[v2122];
            v2123++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2126, v2123);
    }

    int[] ArrayTakeWhileFalseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2127;
        int v2128;
        int v2129;
        int v2130;
        int[] v2131;
        v2128 = 0;
        v2129 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2129 -= (v2129 % 2);
        v2130 = 8;
        v2131 = new int[8];
        v2127 = 0;
        for (; v2127 < ArrayItems.Length; v2127++)
        {
            if (!((false)))
                break;
            if (v2128 >= v2130)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2131, ref v2129, out v2130);
            v2131[v2128] = ArrayItems[v2127];
            v2128++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2131, v2128);
    }

    int[] ArraySelectTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2132;
        int v2133;
        int v2134;
        int v2135;
        int v2136;
        int[] v2137;
        v2134 = 0;
        v2135 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2135 -= (v2135 % 2);
        v2136 = 8;
        v2137 = new int[8];
        v2132 = 0;
        for (; v2132 < ArrayItems.Length; v2132++)
        {
            v2133 = (ArrayItems[v2132] + 20);
            if (!((v2133 < 50)))
                break;
            if (v2134 >= v2136)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2137, ref v2135, out v2136);
            v2137[v2134] = v2133;
            v2134++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2137, v2134);
    }

    int[] ArrayWhereTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2138;
        int v2139;
        int v2140;
        int v2141;
        int[] v2142;
        v2139 = 0;
        v2140 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2140 -= (v2140 % 2);
        v2141 = 8;
        v2142 = new int[8];
        v2138 = 0;
        for (; v2138 < ArrayItems.Length; v2138++)
        {
            if (!((ArrayItems[v2138] > 20)))
                continue;
            if (!((ArrayItems[v2138] < 50)))
                break;
            if (v2139 >= v2141)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2142, ref v2140, out v2141);
            v2142[v2139] = ArrayItems[v2138];
            v2139++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2142, v2139);
    }

    int[] ArrayTakeWhileParamToArrayRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2143;
        int v2144;
        int v2145;
        int v2146;
        int[] v2147;
        v2144 = 0;
        v2145 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2145 -= (v2145 % 2);
        v2146 = 8;
        v2147 = new int[8];
        v2143 = 0;
        for (; v2143 < ArrayItems.Length; v2143++)
        {
            if (!((ArrayItems[v2143] < a)))
                break;
            if (v2144 >= v2146)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2147, ref v2145, out v2146);
            v2147[v2144] = ArrayItems[v2143];
            v2144++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2147, v2144);
    }

    int[] ArrayTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2148;
        int v2149;
        int v2150;
        int v2151;
        int[] v2152;
        v2149 = 0;
        v2150 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2150 -= (v2150 % 2);
        v2151 = 8;
        v2152 = new int[8];
        v2148 = 0;
        for (; v2148 < ArrayItems.Length; v2148++)
        {
            if (!((ArrayItems[v2148] < a++)))
                break;
            if (v2149 >= v2151)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2152, ref v2150, out v2151);
            v2152[v2149] = ArrayItems[v2148];
            v2149++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2152, v2149);
    }

    int[] ArrayTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2153;
        int v2154;
        int v2155;
        int v2156;
        int[] v2157;
        v2154 = 0;
        v2155 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2155 -= (v2155 % 2);
        v2156 = 8;
        v2157 = new int[8];
        v2153 = 0;
        for (; v2153 < ArrayItems.Length; v2153++)
        {
            if (!((ArrayItems[v2153] < a--)))
                break;
            if (v2154 >= v2156)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2157, ref v2155, out v2156);
            v2157[v2154] = ArrayItems[v2153];
            v2154++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2157, v2154);
    }

    int[] ArrayTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, int[] ArrayItems)
    {
        int v2158;
        int v2159;
        int v2160;
        int v2161;
        int[] v2162;
        v2159 = 0;
        v2160 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v2160 -= (v2160 % 2);
        v2161 = 8;
        v2162 = new int[8];
        v2158 = 0;
        for (; v2158 < ArrayItems.Length; v2158++)
        {
            if (!((ArrayItems[v2158] < a++ - b--)))
                break;
            if (v2159 >= v2161)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v2162, ref v2160, out v2161);
            v2162[v2159] = ArrayItems[v2158];
            v2159++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2162, v2159);
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2163;
        int v2164;
        v2163 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2163.MoveNext())
            {
                v2164 = v2163.Current;
                if (!((v2164 < 50)))
                    break;
                yield return v2164;
            }
        }
        finally
        {
            v2163.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileReverseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2165;
        int v2166;
        v2165 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2165.MoveNext())
            {
                v2166 = v2165.Current;
                if (!((v2166 > 50)))
                    break;
                yield return v2166;
            }
        }
        finally
        {
            v2165.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileTrueRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2167;
        int v2168;
        v2167 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2167.MoveNext())
            {
                v2168 = v2167.Current;
                if (!((true)))
                    break;
                yield return v2168;
            }
        }
        finally
        {
            v2167.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileFalseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2169;
        int v2170;
        v2169 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2169.MoveNext())
            {
                v2170 = v2169.Current;
                if (!((false)))
                    break;
                yield return v2170;
            }
        }
        finally
        {
            v2169.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSelectTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2171;
        int v2172;
        v2171 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2171.MoveNext())
            {
                v2172 = (v2171.Current + 20);
                if (!((v2172 < 50)))
                    break;
                yield return v2172;
            }
        }
        finally
        {
            v2171.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2173;
        int v2174;
        v2173 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2173.MoveNext())
            {
                v2174 = v2173.Current;
                if (!((v2174 > 20)))
                    continue;
                if (!((v2174 < 50)))
                    break;
                yield return v2174;
            }
        }
        finally
        {
            v2173.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2175;
        int v2176;
        v2175 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2175.MoveNext())
            {
                v2176 = v2175.Current;
                if (!((v2176 < a)))
                    break;
                yield return v2176;
            }
        }
        finally
        {
            v2175.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParamRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2179)
    {
        IEnumerator<int> v2177;
        int v2178;
        v2177 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2177.MoveNext())
            {
                v2178 = v2177.Current;
                if (!(v2179(v2178)))
                    break;
                yield return v2178;
            }
        }
        finally
        {
            v2177.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParam2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2182)
    {
        IEnumerator<int> v2180;
        int v2181;
        v2180 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2180.MoveNext())
            {
                v2181 = v2180.Current;
                if (!(v2182(v2181)))
                    break;
                yield return v2181;
            }
        }
        finally
        {
            v2180.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParamsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2185)
    {
        IEnumerator<int> v2183;
        int v2184;
        v2183 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2183.MoveNext())
            {
                v2184 = v2183.Current;
                if (!(v2185(v2184)))
                    break;
                yield return v2184;
            }
        }
        finally
        {
            v2183.Dispose();
        }
    }

    int[] EnumerableTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2186;
        int v2187;
        int v2188;
        int v2189;
        int[] v2190;
        v2186 = EnumerableItems.GetEnumerator();
        v2188 = 0;
        v2189 = 8;
        v2190 = new int[8];
        try
        {
            while (v2186.MoveNext())
            {
                v2187 = v2186.Current;
                if (!((v2187 < 50)))
                    break;
                if (v2188 >= v2189)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2190, ref v2189);
                v2190[v2188] = v2187;
                v2188++;
            }
        }
        finally
        {
            v2186.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2190, v2188);
    }

    int[] EnumerableTakeWhileReverseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2191;
        int v2192;
        int v2193;
        int v2194;
        int[] v2195;
        v2191 = EnumerableItems.GetEnumerator();
        v2193 = 0;
        v2194 = 8;
        v2195 = new int[8];
        try
        {
            while (v2191.MoveNext())
            {
                v2192 = v2191.Current;
                if (!((v2192 > 50)))
                    break;
                if (v2193 >= v2194)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2195, ref v2194);
                v2195[v2193] = v2192;
                v2193++;
            }
        }
        finally
        {
            v2191.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2195, v2193);
    }

    int[] EnumerableTakeWhileTrueToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2196;
        int v2197;
        int v2198;
        int v2199;
        int[] v2200;
        v2196 = EnumerableItems.GetEnumerator();
        v2198 = 0;
        v2199 = 8;
        v2200 = new int[8];
        try
        {
            while (v2196.MoveNext())
            {
                v2197 = v2196.Current;
                if (!((true)))
                    break;
                if (v2198 >= v2199)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2200, ref v2199);
                v2200[v2198] = v2197;
                v2198++;
            }
        }
        finally
        {
            v2196.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2200, v2198);
    }

    int[] EnumerableTakeWhileFalseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2201;
        int v2202;
        int v2203;
        int v2204;
        int[] v2205;
        v2201 = EnumerableItems.GetEnumerator();
        v2203 = 0;
        v2204 = 8;
        v2205 = new int[8];
        try
        {
            while (v2201.MoveNext())
            {
                v2202 = v2201.Current;
                if (!((false)))
                    break;
                if (v2203 >= v2204)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2205, ref v2204);
                v2205[v2203] = v2202;
                v2203++;
            }
        }
        finally
        {
            v2201.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2205, v2203);
    }

    int[] EnumerableSelectTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2206;
        int v2207;
        int v2208;
        int v2209;
        int[] v2210;
        v2206 = EnumerableItems.GetEnumerator();
        v2208 = 0;
        v2209 = 8;
        v2210 = new int[8];
        try
        {
            while (v2206.MoveNext())
            {
                v2207 = (v2206.Current + 20);
                if (!((v2207 < 50)))
                    break;
                if (v2208 >= v2209)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2210, ref v2209);
                v2210[v2208] = v2207;
                v2208++;
            }
        }
        finally
        {
            v2206.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2210, v2208);
    }

    int[] EnumerableWhereTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2211;
        int v2212;
        int v2213;
        int v2214;
        int[] v2215;
        v2211 = EnumerableItems.GetEnumerator();
        v2213 = 0;
        v2214 = 8;
        v2215 = new int[8];
        try
        {
            while (v2211.MoveNext())
            {
                v2212 = v2211.Current;
                if (!((v2212 > 20)))
                    continue;
                if (!((v2212 < 50)))
                    break;
                if (v2213 >= v2214)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2215, ref v2214);
                v2215[v2213] = v2212;
                v2213++;
            }
        }
        finally
        {
            v2211.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2215, v2213);
    }

    int[] EnumerableTakeWhileParamToArrayRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2216;
        int v2217;
        int v2218;
        int v2219;
        int[] v2220;
        v2216 = EnumerableItems.GetEnumerator();
        v2218 = 0;
        v2219 = 8;
        v2220 = new int[8];
        try
        {
            while (v2216.MoveNext())
            {
                v2217 = v2216.Current;
                if (!((v2217 < a)))
                    break;
                if (v2218 >= v2219)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2220, ref v2219);
                v2220[v2218] = v2217;
                v2218++;
            }
        }
        finally
        {
            v2216.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2220, v2218);
    }

    int[] EnumerableTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2221;
        int v2222;
        int v2223;
        int v2224;
        int[] v2225;
        v2221 = EnumerableItems.GetEnumerator();
        v2223 = 0;
        v2224 = 8;
        v2225 = new int[8];
        try
        {
            while (v2221.MoveNext())
            {
                v2222 = v2221.Current;
                if (!((v2222 < a++)))
                    break;
                if (v2223 >= v2224)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2225, ref v2224);
                v2225[v2223] = v2222;
                v2223++;
            }
        }
        finally
        {
            v2221.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2225, v2223);
    }

    int[] EnumerableTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2226;
        int v2227;
        int v2228;
        int v2229;
        int[] v2230;
        v2226 = EnumerableItems.GetEnumerator();
        v2228 = 0;
        v2229 = 8;
        v2230 = new int[8];
        try
        {
            while (v2226.MoveNext())
            {
                v2227 = v2226.Current;
                if (!((v2227 < a--)))
                    break;
                if (v2228 >= v2229)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2230, ref v2229);
                v2230[v2228] = v2227;
                v2228++;
            }
        }
        finally
        {
            v2226.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2230, v2228);
    }

    int[] EnumerableTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2231;
        int v2232;
        int v2233;
        int v2234;
        int[] v2235;
        v2231 = EnumerableItems.GetEnumerator();
        v2233 = 0;
        v2234 = 8;
        v2235 = new int[8];
        try
        {
            while (v2231.MoveNext())
            {
                v2232 = v2231.Current;
                if (!((v2232 < a++ - b--)))
                    break;
                if (v2233 >= v2234)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2235, ref v2234);
                v2235[v2233] = v2232;
                v2233++;
            }
        }
        finally
        {
            v2231.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2235, v2233);
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileRewritten_ProceduralLinq1()
    {
        int v2236;
        int v2237;
        v2236 = 0;
        for (; v2236 < 100; v2236++)
        {
            v2237 = (v2236 + 0);
            if (!((v2237 < 50)))
                break;
            yield return v2237;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileReverseRewritten_ProceduralLinq1()
    {
        int v2238;
        int v2239;
        v2238 = 0;
        for (; v2238 < 100; v2238++)
        {
            v2239 = (v2238 + 0);
            if (!((v2239 > 50)))
                break;
            yield return v2239;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileTrueRewritten_ProceduralLinq1()
    {
        int v2240;
        int v2241;
        v2240 = 0;
        for (; v2240 < 100; v2240++)
        {
            v2241 = (v2240 + 0);
            if (!((true)))
                break;
            yield return v2241;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileFalseRewritten_ProceduralLinq1()
    {
        int v2242;
        int v2243;
        v2242 = 0;
        for (; v2242 < 100; v2242++)
        {
            v2243 = (v2242 + 0);
            if (!((false)))
                break;
            yield return v2243;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSelectTakeWhileRewritten_ProceduralLinq1()
    {
        int v2244;
        int v2245;
        v2244 = 0;
        for (; v2244 < 100; v2244++)
        {
            v2245 = ((v2244 + 0) + 20);
            if (!((v2245 < 50)))
                break;
            yield return v2245;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereTakeWhileRewritten_ProceduralLinq1()
    {
        int v2246;
        int v2247;
        v2246 = 0;
        for (; v2246 < 100; v2246++)
        {
            v2247 = (v2246 + 0);
            if (!((v2247 > 20)))
                continue;
            if (!((v2247 < 50)))
                break;
            yield return v2247;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileParamRewritten_ProceduralLinq1(int a)
    {
        int v2248;
        int v2249;
        v2248 = 0;
        for (; v2248 < 100; v2248++)
        {
            v2249 = (v2248 + 0);
            if (!((v2249 < a)))
                break;
            yield return v2249;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParamRewritten_ProceduralLinq1(System.Func<int, bool> v2252)
    {
        int v2250;
        int v2251;
        v2250 = 0;
        for (; v2250 < 100; v2250++)
        {
            v2251 = (v2250 + 0);
            if (!(v2252(v2251)))
                break;
            yield return v2251;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParam2Rewritten_ProceduralLinq1(System.Func<int, bool> v2255)
    {
        int v2253;
        int v2254;
        v2253 = 0;
        for (; v2253 < 100; v2253++)
        {
            v2254 = (v2253 + 0);
            if (!(v2255(v2254)))
                break;
            yield return v2254;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParamsRewritten_ProceduralLinq1(System.Func<int, bool> v2258)
    {
        int v2256;
        int v2257;
        v2256 = 0;
        for (; v2256 < 100; v2256++)
        {
            v2257 = (v2256 + 0);
            if (!(v2258(v2257)))
                break;
            yield return v2257;
        }
    }

    int[] RangeTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2259;
        int v2260;
        int v2261;
        int v2262;
        int v2263;
        int[] v2264;
        v2261 = 0;
        v2262 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2262 -= (v2262 % 2);
        v2263 = 8;
        v2264 = new int[8];
        v2259 = 0;
        for (; v2259 < 100; v2259++)
        {
            v2260 = (v2259 + 0);
            if (!((v2260 < 50)))
                break;
            if (v2261 >= v2263)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2264, ref v2262, out v2263);
            v2264[v2261] = v2260;
            v2261++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2264, v2261);
    }

    int[] RangeTakeWhileReverseToArrayRewritten_ProceduralLinq1()
    {
        int v2265;
        int v2266;
        int v2267;
        int v2268;
        int v2269;
        int[] v2270;
        v2267 = 0;
        v2268 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2268 -= (v2268 % 2);
        v2269 = 8;
        v2270 = new int[8];
        v2265 = 0;
        for (; v2265 < 100; v2265++)
        {
            v2266 = (v2265 + 0);
            if (!((v2266 > 50)))
                break;
            if (v2267 >= v2269)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2270, ref v2268, out v2269);
            v2270[v2267] = v2266;
            v2267++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2270, v2267);
    }

    int[] RangeTakeWhileTrueToArrayRewritten_ProceduralLinq1()
    {
        int v2271;
        int v2272;
        int v2273;
        int v2274;
        int v2275;
        int[] v2276;
        v2273 = 0;
        v2274 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2274 -= (v2274 % 2);
        v2275 = 8;
        v2276 = new int[8];
        v2271 = 0;
        for (; v2271 < 100; v2271++)
        {
            v2272 = (v2271 + 0);
            if (!((true)))
                break;
            if (v2273 >= v2275)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2276, ref v2274, out v2275);
            v2276[v2273] = v2272;
            v2273++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2276, v2273);
    }

    int[] RangeTakeWhileFalseToArrayRewritten_ProceduralLinq1()
    {
        int v2277;
        int v2278;
        int v2279;
        int v2280;
        int v2281;
        int[] v2282;
        v2279 = 0;
        v2280 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2280 -= (v2280 % 2);
        v2281 = 8;
        v2282 = new int[8];
        v2277 = 0;
        for (; v2277 < 100; v2277++)
        {
            v2278 = (v2277 + 0);
            if (!((false)))
                break;
            if (v2279 >= v2281)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2282, ref v2280, out v2281);
            v2282[v2279] = v2278;
            v2279++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2282, v2279);
    }

    int[] RangeSelectTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2283;
        int v2284;
        int v2285;
        int v2286;
        int v2287;
        int[] v2288;
        v2285 = 0;
        v2286 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2286 -= (v2286 % 2);
        v2287 = 8;
        v2288 = new int[8];
        v2283 = 0;
        for (; v2283 < 100; v2283++)
        {
            v2284 = ((v2283 + 0) + 20);
            if (!((v2284 < 50)))
                break;
            if (v2285 >= v2287)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2288, ref v2286, out v2287);
            v2288[v2285] = v2284;
            v2285++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2288, v2285);
    }

    int[] RangeWhereTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2289;
        int v2290;
        int v2291;
        int v2292;
        int v2293;
        int[] v2294;
        v2291 = 0;
        v2292 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2292 -= (v2292 % 2);
        v2293 = 8;
        v2294 = new int[8];
        v2289 = 0;
        for (; v2289 < 100; v2289++)
        {
            v2290 = (v2289 + 0);
            if (!((v2290 > 20)))
                continue;
            if (!((v2290 < 50)))
                break;
            if (v2291 >= v2293)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2294, ref v2292, out v2293);
            v2294[v2291] = v2290;
            v2291++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2294, v2291);
    }

    int[] RangeTakeWhileParamToArrayRewritten_ProceduralLinq1(int a)
    {
        int v2295;
        int v2296;
        int v2297;
        int v2298;
        int v2299;
        int[] v2300;
        v2297 = 0;
        v2298 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2298 -= (v2298 % 2);
        v2299 = 8;
        v2300 = new int[8];
        v2295 = 0;
        for (; v2295 < 100; v2295++)
        {
            v2296 = (v2295 + 0);
            if (!((v2296 < a)))
                break;
            if (v2297 >= v2299)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2300, ref v2298, out v2299);
            v2300[v2297] = v2296;
            v2297++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2300, v2297);
    }

    int[] RangeTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a)
    {
        int v2301;
        int v2302;
        int v2303;
        int v2304;
        int v2305;
        int[] v2306;
        v2303 = 0;
        v2304 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2304 -= (v2304 % 2);
        v2305 = 8;
        v2306 = new int[8];
        v2301 = 0;
        for (; v2301 < 100; v2301++)
        {
            v2302 = (v2301 + 0);
            if (!((v2302 < a++)))
                break;
            if (v2303 >= v2305)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2306, ref v2304, out v2305);
            v2306[v2303] = v2302;
            v2303++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2306, v2303);
    }

    int[] RangeTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a)
    {
        int v2307;
        int v2308;
        int v2309;
        int v2310;
        int v2311;
        int[] v2312;
        v2309 = 0;
        v2310 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2310 -= (v2310 % 2);
        v2311 = 8;
        v2312 = new int[8];
        v2307 = 0;
        for (; v2307 < 100; v2307++)
        {
            v2308 = (v2307 + 0);
            if (!((v2308 < a--)))
                break;
            if (v2309 >= v2311)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2312, ref v2310, out v2311);
            v2312[v2309] = v2308;
            v2309++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2312, v2309);
    }

    int[] RangeTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b)
    {
        int v2313;
        int v2314;
        int v2315;
        int v2316;
        int v2317;
        int[] v2318;
        v2315 = 0;
        v2316 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2316 -= (v2316 % 2);
        v2317 = 8;
        v2318 = new int[8];
        v2313 = 0;
        for (; v2313 < 100; v2313++)
        {
            v2314 = (v2313 + 0);
            if (!((v2314 < a++ - b--)))
                break;
            if (v2315 >= v2317)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2318, ref v2316, out v2317);
            v2318[v2315] = v2314;
            v2315++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2318, v2315);
    }
}}