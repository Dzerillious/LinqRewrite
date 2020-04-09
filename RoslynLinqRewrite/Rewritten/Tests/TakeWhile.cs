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
        int v2524;
        int v2525;
        v2524 = (0);
        for (; v2524 < (ArrayItems.Length); v2524++)
        {
            v2525 = (ArrayItems[v2524]);
            if (!(((v2525) < 50)))
                break;
            yield return (v2525);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileReverseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2526;
        int v2527;
        v2526 = (0);
        for (; v2526 < (ArrayItems.Length); v2526++)
        {
            v2527 = (ArrayItems[v2526]);
            if (!(((v2527) > 50)))
                break;
            yield return (v2527);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileTrueRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2528;
        int v2529;
        v2528 = (0);
        for (; v2528 < (ArrayItems.Length); v2528++)
        {
            v2529 = (ArrayItems[v2528]);
            if (!((true)))
                break;
            yield return (v2529);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2530;
        int v2531;
        v2530 = (0);
        for (; v2530 < (ArrayItems.Length); v2530++)
        {
            v2531 = (ArrayItems[v2530]);
            if (!((false)))
                break;
            yield return (v2531);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectTakeWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2532;
        int v2533;
        v2532 = (0);
        for (; v2532 < (ArrayItems.Length); v2532++)
        {
            v2533 = (20 + ArrayItems[v2532]);
            if (!(((v2533) < 50)))
                break;
            yield return (v2533);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereTakeWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2534;
        int v2535;
        v2534 = (0);
        for (; v2534 < (ArrayItems.Length); v2534++)
        {
            v2535 = (ArrayItems[v2534]);
            if (!(((v2535) > 20)))
                continue;
            v2535 = (v2535);
            if (!(((v2535) < 50)))
                break;
            yield return (v2535);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2536;
        int v2537;
        v2536 = (0);
        for (; v2536 < (ArrayItems.Length); v2536++)
        {
            v2537 = (ArrayItems[v2536]);
            if (!(((v2537) < a)))
                break;
            yield return (v2537);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2540)
    {
        int v2538;
        int v2539;
        v2538 = (0);
        for (; v2538 < (ArrayItems.Length); v2538++)
        {
            v2539 = (ArrayItems[v2538]);
            if (!(v2540((v2539))))
                break;
            yield return (v2539);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParam2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2543)
    {
        int v2541;
        int v2542;
        v2541 = (0);
        for (; v2541 < (ArrayItems.Length); v2541++)
        {
            v2542 = (ArrayItems[v2541]);
            if (!(v2543((v2542))))
                break;
            yield return (v2542);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayTakeWhileChangingParamsRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2546)
    {
        int v2544;
        int v2545;
        v2544 = (0);
        for (; v2544 < (ArrayItems.Length); v2544++)
        {
            v2545 = (ArrayItems[v2544]);
            if (!(v2546((v2545))))
                break;
            yield return (v2545);
        }

        yield break;
    }

    int[] ArrayTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2547;
        int v2548;
        int v2549;
        int v2550;
        int v2551;
        int[] v2552;
        v2549 = 0;
        v2550 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2550 -= (v2550 % 2);
        v2551 = 8;
        v2552 = new int[8];
        v2547 = (0);
        for (; v2547 < (ArrayItems.Length); v2547++)
        {
            v2548 = (ArrayItems[v2547]);
            if (!(((v2548) < 50)))
                break;
            if (v2549 >= v2551)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2552, ref v2550, out v2551);
            v2552[v2549] = (v2548);
            v2549++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2552, v2549);
    }

    int[] ArrayTakeWhileReverseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2553;
        int v2554;
        int v2555;
        int v2556;
        int v2557;
        int[] v2558;
        v2555 = 0;
        v2556 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2556 -= (v2556 % 2);
        v2557 = 8;
        v2558 = new int[8];
        v2553 = (0);
        for (; v2553 < (ArrayItems.Length); v2553++)
        {
            v2554 = (ArrayItems[v2553]);
            if (!(((v2554) > 50)))
                break;
            if (v2555 >= v2557)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2558, ref v2556, out v2557);
            v2558[v2555] = (v2554);
            v2555++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2558, v2555);
    }

    int[] ArrayTakeWhileTrueToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2559;
        int v2560;
        int v2561;
        int v2562;
        int v2563;
        int[] v2564;
        v2561 = 0;
        v2562 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2562 -= (v2562 % 2);
        v2563 = 8;
        v2564 = new int[8];
        v2559 = (0);
        for (; v2559 < (ArrayItems.Length); v2559++)
        {
            v2560 = (ArrayItems[v2559]);
            if (!((true)))
                break;
            if (v2561 >= v2563)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2564, ref v2562, out v2563);
            v2564[v2561] = (v2560);
            v2561++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2564, v2561);
    }

    int[] ArrayTakeWhileFalseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2565;
        int v2566;
        int v2567;
        int v2568;
        int v2569;
        int[] v2570;
        v2567 = 0;
        v2568 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2568 -= (v2568 % 2);
        v2569 = 8;
        v2570 = new int[8];
        v2565 = (0);
        for (; v2565 < (ArrayItems.Length); v2565++)
        {
            v2566 = (ArrayItems[v2565]);
            if (!((false)))
                break;
            if (v2567 >= v2569)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2570, ref v2568, out v2569);
            v2570[v2567] = (v2566);
            v2567++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2570, v2567);
    }

    int[] ArraySelectTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2571;
        int v2572;
        int v2573;
        int v2574;
        int v2575;
        int[] v2576;
        v2573 = 0;
        v2574 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2574 -= (v2574 % 2);
        v2575 = 8;
        v2576 = new int[8];
        v2571 = (0);
        for (; v2571 < (ArrayItems.Length); v2571++)
        {
            v2572 = (20 + ArrayItems[v2571]);
            if (!(((v2572) < 50)))
                break;
            if (v2573 >= v2575)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2576, ref v2574, out v2575);
            v2576[v2573] = (v2572);
            v2573++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2576, v2573);
    }

    int[] ArrayWhereTakeWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2577;
        int v2578;
        int v2579;
        int v2580;
        int v2581;
        int[] v2582;
        v2579 = 0;
        v2580 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2580 -= (v2580 % 2);
        v2581 = 8;
        v2582 = new int[8];
        v2577 = (0);
        for (; v2577 < (ArrayItems.Length); v2577++)
        {
            v2578 = (ArrayItems[v2577]);
            if (!(((v2578) > 20)))
                continue;
            v2578 = (v2578);
            if (!(((v2578) < 50)))
                break;
            if (v2579 >= v2581)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2582, ref v2580, out v2581);
            v2582[v2579] = (v2578);
            v2579++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2582, v2579);
    }

    int[] ArrayTakeWhileParamToArrayRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2583;
        int v2584;
        int v2585;
        int v2586;
        int v2587;
        int[] v2588;
        v2585 = 0;
        v2586 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2586 -= (v2586 % 2);
        v2587 = 8;
        v2588 = new int[8];
        v2583 = (0);
        for (; v2583 < (ArrayItems.Length); v2583++)
        {
            v2584 = (ArrayItems[v2583]);
            if (!(((v2584) < a)))
                break;
            if (v2585 >= v2587)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2588, ref v2586, out v2587);
            v2588[v2585] = (v2584);
            v2585++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2588, v2585);
    }

    int[] ArrayTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2589;
        int v2590;
        int v2591;
        int v2592;
        int v2593;
        int[] v2594;
        v2591 = 0;
        v2592 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2592 -= (v2592 % 2);
        v2593 = 8;
        v2594 = new int[8];
        v2589 = (0);
        for (; v2589 < (ArrayItems.Length); v2589++)
        {
            v2590 = (ArrayItems[v2589]);
            if (!(((v2590) < a++)))
                break;
            if (v2591 >= v2593)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2594, ref v2592, out v2593);
            v2594[v2591] = (v2590);
            v2591++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2594, v2591);
    }

    int[] ArrayTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2595;
        int v2596;
        int v2597;
        int v2598;
        int v2599;
        int[] v2600;
        v2597 = 0;
        v2598 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2598 -= (v2598 % 2);
        v2599 = 8;
        v2600 = new int[8];
        v2595 = (0);
        for (; v2595 < (ArrayItems.Length); v2595++)
        {
            v2596 = (ArrayItems[v2595]);
            if (!(((v2596) < a--)))
                break;
            if (v2597 >= v2599)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2600, ref v2598, out v2599);
            v2600[v2597] = (v2596);
            v2597++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2600, v2597);
    }

    int[] ArrayTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, int[] ArrayItems)
    {
        int v2601;
        int v2602;
        int v2603;
        int v2604;
        int v2605;
        int[] v2606;
        v2603 = 0;
        v2604 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2604 -= (v2604 % 2);
        v2605 = 8;
        v2606 = new int[8];
        v2601 = (0);
        for (; v2601 < (ArrayItems.Length); v2601++)
        {
            v2602 = (ArrayItems[v2601]);
            if (!(((v2602) < a++ - b--)))
                break;
            if (v2603 >= v2605)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2606, ref v2604, out v2605);
            v2606[v2603] = (v2602);
            v2603++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2606, v2603);
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2607;
        int v2608;
        v2607 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2607.MoveNext())
            {
                v2608 = (v2607.Current);
                if (!(((v2608) < 50)))
                    break;
                yield return (v2608);
            }
        }
        finally
        {
            v2607.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileReverseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2609;
        int v2610;
        v2609 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2609.MoveNext())
            {
                v2610 = (v2609.Current);
                if (!(((v2610) > 50)))
                    break;
                yield return (v2610);
            }
        }
        finally
        {
            v2609.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileTrueRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2611;
        int v2612;
        v2611 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2611.MoveNext())
            {
                v2612 = (v2611.Current);
                if (!((true)))
                    break;
                yield return (v2612);
            }
        }
        finally
        {
            v2611.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileFalseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2613;
        int v2614;
        v2613 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2613.MoveNext())
            {
                v2614 = (v2613.Current);
                if (!((false)))
                    break;
                yield return (v2614);
            }
        }
        finally
        {
            v2613.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSelectTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2615;
        int v2616;
        v2615 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2615.MoveNext())
            {
                v2616 = (20 + v2615.Current);
                if (!(((v2616) < 50)))
                    break;
                yield return (v2616);
            }
        }
        finally
        {
            v2615.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereTakeWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2617;
        int v2618;
        v2617 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2617.MoveNext())
            {
                v2618 = (v2617.Current);
                if (!(((v2618) > 20)))
                    continue;
                v2618 = (v2618);
                if (!(((v2618) < 50)))
                    break;
                yield return (v2618);
            }
        }
        finally
        {
            v2617.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2619;
        int v2620;
        v2619 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2619.MoveNext())
            {
                v2620 = (v2619.Current);
                if (!(((v2620) < a)))
                    break;
                yield return (v2620);
            }
        }
        finally
        {
            v2619.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParamRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2623)
    {
        IEnumerator<int> v2621;
        int v2622;
        v2621 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2621.MoveNext())
            {
                v2622 = (v2621.Current);
                if (!(v2623((v2622))))
                    break;
                yield return (v2622);
            }
        }
        finally
        {
            v2621.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParam2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2626)
    {
        IEnumerator<int> v2624;
        int v2625;
        v2624 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2624.MoveNext())
            {
                v2625 = (v2624.Current);
                if (!(v2626((v2625))))
                    break;
                yield return (v2625);
            }
        }
        finally
        {
            v2624.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableTakeWhileChangingParamsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2629)
    {
        IEnumerator<int> v2627;
        int v2628;
        v2627 = EnumerableItems.GetEnumerator();
        try
        {
            while (v2627.MoveNext())
            {
                v2628 = (v2627.Current);
                if (!(v2629((v2628))))
                    break;
                yield return (v2628);
            }
        }
        finally
        {
            v2627.Dispose();
        }

        yield break;
    }

    int[] EnumerableTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2630;
        int v2631;
        int v2632;
        int v2633;
        int[] v2634;
        v2630 = EnumerableItems.GetEnumerator();
        v2632 = 0;
        v2633 = 8;
        v2634 = new int[8];
        try
        {
            while (v2630.MoveNext())
            {
                v2631 = (v2630.Current);
                if (!(((v2631) < 50)))
                    break;
                if (v2632 >= v2633)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2634, ref v2633);
                v2634[v2632] = (v2631);
                v2632++;
            }
        }
        finally
        {
            v2630.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2634, v2632);
    }

    int[] EnumerableTakeWhileReverseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2635;
        int v2636;
        int v2637;
        int v2638;
        int[] v2639;
        v2635 = EnumerableItems.GetEnumerator();
        v2637 = 0;
        v2638 = 8;
        v2639 = new int[8];
        try
        {
            while (v2635.MoveNext())
            {
                v2636 = (v2635.Current);
                if (!(((v2636) > 50)))
                    break;
                if (v2637 >= v2638)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2639, ref v2638);
                v2639[v2637] = (v2636);
                v2637++;
            }
        }
        finally
        {
            v2635.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2639, v2637);
    }

    int[] EnumerableTakeWhileTrueToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2640;
        int v2641;
        int v2642;
        int v2643;
        int[] v2644;
        v2640 = EnumerableItems.GetEnumerator();
        v2642 = 0;
        v2643 = 8;
        v2644 = new int[8];
        try
        {
            while (v2640.MoveNext())
            {
                v2641 = (v2640.Current);
                if (!((true)))
                    break;
                if (v2642 >= v2643)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2644, ref v2643);
                v2644[v2642] = (v2641);
                v2642++;
            }
        }
        finally
        {
            v2640.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2644, v2642);
    }

    int[] EnumerableTakeWhileFalseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2645;
        int v2646;
        int v2647;
        int v2648;
        int[] v2649;
        v2645 = EnumerableItems.GetEnumerator();
        v2647 = 0;
        v2648 = 8;
        v2649 = new int[8];
        try
        {
            while (v2645.MoveNext())
            {
                v2646 = (v2645.Current);
                if (!((false)))
                    break;
                if (v2647 >= v2648)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2649, ref v2648);
                v2649[v2647] = (v2646);
                v2647++;
            }
        }
        finally
        {
            v2645.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2649, v2647);
    }

    int[] EnumerableSelectTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2650;
        int v2651;
        int v2652;
        int v2653;
        int[] v2654;
        v2650 = EnumerableItems.GetEnumerator();
        v2652 = 0;
        v2653 = 8;
        v2654 = new int[8];
        try
        {
            while (v2650.MoveNext())
            {
                v2651 = (20 + v2650.Current);
                if (!(((v2651) < 50)))
                    break;
                if (v2652 >= v2653)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2654, ref v2653);
                v2654[v2652] = (v2651);
                v2652++;
            }
        }
        finally
        {
            v2650.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2654, v2652);
    }

    int[] EnumerableWhereTakeWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2655;
        int v2656;
        int v2657;
        int v2658;
        int[] v2659;
        v2655 = EnumerableItems.GetEnumerator();
        v2657 = 0;
        v2658 = 8;
        v2659 = new int[8];
        try
        {
            while (v2655.MoveNext())
            {
                v2656 = (v2655.Current);
                if (!(((v2656) > 20)))
                    continue;
                v2656 = (v2656);
                if (!(((v2656) < 50)))
                    break;
                if (v2657 >= v2658)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2659, ref v2658);
                v2659[v2657] = (v2656);
                v2657++;
            }
        }
        finally
        {
            v2655.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2659, v2657);
    }

    int[] EnumerableTakeWhileParamToArrayRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2660;
        int v2661;
        int v2662;
        int v2663;
        int[] v2664;
        v2660 = EnumerableItems.GetEnumerator();
        v2662 = 0;
        v2663 = 8;
        v2664 = new int[8];
        try
        {
            while (v2660.MoveNext())
            {
                v2661 = (v2660.Current);
                if (!(((v2661) < a)))
                    break;
                if (v2662 >= v2663)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2664, ref v2663);
                v2664[v2662] = (v2661);
                v2662++;
            }
        }
        finally
        {
            v2660.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2664, v2662);
    }

    int[] EnumerableTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2665;
        int v2666;
        int v2667;
        int v2668;
        int[] v2669;
        v2665 = EnumerableItems.GetEnumerator();
        v2667 = 0;
        v2668 = 8;
        v2669 = new int[8];
        try
        {
            while (v2665.MoveNext())
            {
                v2666 = (v2665.Current);
                if (!(((v2666) < a++)))
                    break;
                if (v2667 >= v2668)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2669, ref v2668);
                v2669[v2667] = (v2666);
                v2667++;
            }
        }
        finally
        {
            v2665.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2669, v2667);
    }

    int[] EnumerableTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2670;
        int v2671;
        int v2672;
        int v2673;
        int[] v2674;
        v2670 = EnumerableItems.GetEnumerator();
        v2672 = 0;
        v2673 = 8;
        v2674 = new int[8];
        try
        {
            while (v2670.MoveNext())
            {
                v2671 = (v2670.Current);
                if (!(((v2671) < a--)))
                    break;
                if (v2672 >= v2673)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2674, ref v2673);
                v2674[v2672] = (v2671);
                v2672++;
            }
        }
        finally
        {
            v2670.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2674, v2672);
    }

    int[] EnumerableTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2675;
        int v2676;
        int v2677;
        int v2678;
        int[] v2679;
        v2675 = EnumerableItems.GetEnumerator();
        v2677 = 0;
        v2678 = 8;
        v2679 = new int[8];
        try
        {
            while (v2675.MoveNext())
            {
                v2676 = (v2675.Current);
                if (!(((v2676) < a++ - b--)))
                    break;
                if (v2677 >= v2678)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2679, ref v2678);
                v2679[v2677] = (v2676);
                v2677++;
            }
        }
        finally
        {
            v2675.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2679, v2677);
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileRewritten_ProceduralLinq1()
    {
        int v2680;
        int v2681;
        v2680 = (0);
        for (; v2680 < (100); v2680++)
        {
            v2681 = (v2680);
            if (!(((v2681) < 50)))
                break;
            yield return (v2681);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileReverseRewritten_ProceduralLinq1()
    {
        int v2682;
        int v2683;
        v2682 = (0);
        for (; v2682 < (100); v2682++)
        {
            v2683 = (v2682);
            if (!(((v2683) > 50)))
                break;
            yield return (v2683);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileTrueRewritten_ProceduralLinq1()
    {
        int v2684;
        int v2685;
        v2684 = (0);
        for (; v2684 < (100); v2684++)
        {
            v2685 = (v2684);
            if (!((true)))
                break;
            yield return (v2685);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileFalseRewritten_ProceduralLinq1()
    {
        int v2686;
        int v2687;
        v2686 = (0);
        for (; v2686 < (100); v2686++)
        {
            v2687 = (v2686);
            if (!((false)))
                break;
            yield return (v2687);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSelectTakeWhileRewritten_ProceduralLinq1()
    {
        int v2688;
        int v2689;
        v2688 = (0);
        for (; v2688 < (100); v2688++)
        {
            v2689 = (20 + v2688);
            if (!(((v2689) < 50)))
                break;
            yield return (v2689);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereTakeWhileRewritten_ProceduralLinq1()
    {
        int v2690;
        int v2691;
        v2690 = (0);
        for (; v2690 < (100); v2690++)
        {
            v2691 = (v2690);
            if (!(((v2691) > 20)))
                continue;
            v2691 = (v2691);
            if (!(((v2691) < 50)))
                break;
            yield return (v2691);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileParamRewritten_ProceduralLinq1(int a)
    {
        int v2692;
        int v2693;
        v2692 = (0);
        for (; v2692 < (100); v2692++)
        {
            v2693 = (v2692);
            if (!(((v2693) < a)))
                break;
            yield return (v2693);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParamRewritten_ProceduralLinq1(System.Func<int, bool> v2696)
    {
        int v2694;
        int v2695;
        v2694 = (0);
        for (; v2694 < (100); v2694++)
        {
            v2695 = (v2694);
            if (!(v2696((v2695))))
                break;
            yield return (v2695);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParam2Rewritten_ProceduralLinq1(System.Func<int, bool> v2699)
    {
        int v2697;
        int v2698;
        v2697 = (0);
        for (; v2697 < (100); v2697++)
        {
            v2698 = (v2697);
            if (!(v2699((v2698))))
                break;
            yield return (v2698);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeTakeWhileChangingParamsRewritten_ProceduralLinq1(System.Func<int, bool> v2702)
    {
        int v2700;
        int v2701;
        v2700 = (0);
        for (; v2700 < (100); v2700++)
        {
            v2701 = (v2700);
            if (!(v2702((v2701))))
                break;
            yield return (v2701);
        }

        yield break;
    }

    int[] RangeTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2703;
        int v2704;
        int v2705;
        int v2706;
        int v2707;
        int[] v2708;
        v2705 = 0;
        v2706 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2706 -= (v2706 % 2);
        v2707 = 8;
        v2708 = new int[8];
        v2703 = (0);
        for (; v2703 < (100); v2703++)
        {
            v2704 = (v2703);
            if (!(((v2704) < 50)))
                break;
            if (v2705 >= v2707)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2708, ref v2706, out v2707);
            v2708[v2705] = (v2704);
            v2705++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2708, v2705);
    }

    int[] RangeTakeWhileReverseToArrayRewritten_ProceduralLinq1()
    {
        int v2709;
        int v2710;
        int v2711;
        int v2712;
        int v2713;
        int[] v2714;
        v2711 = 0;
        v2712 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2712 -= (v2712 % 2);
        v2713 = 8;
        v2714 = new int[8];
        v2709 = (0);
        for (; v2709 < (100); v2709++)
        {
            v2710 = (v2709);
            if (!(((v2710) > 50)))
                break;
            if (v2711 >= v2713)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2714, ref v2712, out v2713);
            v2714[v2711] = (v2710);
            v2711++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2714, v2711);
    }

    int[] RangeTakeWhileTrueToArrayRewritten_ProceduralLinq1()
    {
        int v2715;
        int v2716;
        int v2717;
        int v2718;
        int v2719;
        int[] v2720;
        v2717 = 0;
        v2718 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2718 -= (v2718 % 2);
        v2719 = 8;
        v2720 = new int[8];
        v2715 = (0);
        for (; v2715 < (100); v2715++)
        {
            v2716 = (v2715);
            if (!((true)))
                break;
            if (v2717 >= v2719)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2720, ref v2718, out v2719);
            v2720[v2717] = (v2716);
            v2717++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2720, v2717);
    }

    int[] RangeTakeWhileFalseToArrayRewritten_ProceduralLinq1()
    {
        int v2721;
        int v2722;
        int v2723;
        int v2724;
        int v2725;
        int[] v2726;
        v2723 = 0;
        v2724 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2724 -= (v2724 % 2);
        v2725 = 8;
        v2726 = new int[8];
        v2721 = (0);
        for (; v2721 < (100); v2721++)
        {
            v2722 = (v2721);
            if (!((false)))
                break;
            if (v2723 >= v2725)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2726, ref v2724, out v2725);
            v2726[v2723] = (v2722);
            v2723++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2726, v2723);
    }

    int[] RangeSelectTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2727;
        int v2728;
        int v2729;
        int v2730;
        int v2731;
        int[] v2732;
        v2729 = 0;
        v2730 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2730 -= (v2730 % 2);
        v2731 = 8;
        v2732 = new int[8];
        v2727 = (0);
        for (; v2727 < (100); v2727++)
        {
            v2728 = (20 + v2727);
            if (!(((v2728) < 50)))
                break;
            if (v2729 >= v2731)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2732, ref v2730, out v2731);
            v2732[v2729] = (v2728);
            v2729++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2732, v2729);
    }

    int[] RangeWhereTakeWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2733;
        int v2734;
        int v2735;
        int v2736;
        int v2737;
        int[] v2738;
        v2735 = 0;
        v2736 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2736 -= (v2736 % 2);
        v2737 = 8;
        v2738 = new int[8];
        v2733 = (0);
        for (; v2733 < (100); v2733++)
        {
            v2734 = (v2733);
            if (!(((v2734) > 20)))
                continue;
            v2734 = (v2734);
            if (!(((v2734) < 50)))
                break;
            if (v2735 >= v2737)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2738, ref v2736, out v2737);
            v2738[v2735] = (v2734);
            v2735++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2738, v2735);
    }

    int[] RangeTakeWhileParamToArrayRewritten_ProceduralLinq1(int a)
    {
        int v2739;
        int v2740;
        int v2741;
        int v2742;
        int v2743;
        int[] v2744;
        v2741 = 0;
        v2742 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2742 -= (v2742 % 2);
        v2743 = 8;
        v2744 = new int[8];
        v2739 = (0);
        for (; v2739 < (100); v2739++)
        {
            v2740 = (v2739);
            if (!(((v2740) < a)))
                break;
            if (v2741 >= v2743)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2744, ref v2742, out v2743);
            v2744[v2741] = (v2740);
            v2741++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2744, v2741);
    }

    int[] RangeTakeWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a)
    {
        int v2745;
        int v2746;
        int v2747;
        int v2748;
        int v2749;
        int[] v2750;
        v2747 = 0;
        v2748 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2748 -= (v2748 % 2);
        v2749 = 8;
        v2750 = new int[8];
        v2745 = (0);
        for (; v2745 < (100); v2745++)
        {
            v2746 = (v2745);
            if (!(((v2746) < a++)))
                break;
            if (v2747 >= v2749)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2750, ref v2748, out v2749);
            v2750[v2747] = (v2746);
            v2747++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2750, v2747);
    }

    int[] RangeTakeWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a)
    {
        int v2751;
        int v2752;
        int v2753;
        int v2754;
        int v2755;
        int[] v2756;
        v2753 = 0;
        v2754 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2754 -= (v2754 % 2);
        v2755 = 8;
        v2756 = new int[8];
        v2751 = (0);
        for (; v2751 < (100); v2751++)
        {
            v2752 = (v2751);
            if (!(((v2752) < a--)))
                break;
            if (v2753 >= v2755)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2756, ref v2754, out v2755);
            v2756[v2753] = (v2752);
            v2753++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2756, v2753);
    }

    int[] RangeTakeWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b)
    {
        int v2757;
        int v2758;
        int v2759;
        int v2760;
        int v2761;
        int[] v2762;
        v2759 = 0;
        v2760 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2760 -= (v2760 % 2);
        v2761 = 8;
        v2762 = new int[8];
        v2757 = (0);
        for (; v2757 < (100); v2757++)
        {
            v2758 = (v2757);
            if (!(((v2758) < a++ - b--)))
                break;
            if (v2759 >= v2761)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2762, ref v2760, out v2761);
            v2762[v2759] = (v2758);
            v2759++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2762, v2759);
    }
}}