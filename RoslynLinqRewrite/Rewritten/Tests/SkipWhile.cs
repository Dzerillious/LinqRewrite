using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SkipWhile
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArraySkipWhile), ArraySkipWhile, ArraySkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileReverse), ArraySkipWhileReverse, ArraySkipWhileReverseRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileTrue), ArraySkipWhileTrue, ArraySkipWhileTrueRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileFalse), ArraySkipWhileFalse, ArraySkipWhileFalseRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipWhile), ArraySelectSkipWhile, ArraySelectSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSkipWhile), ArrayWhereSkipWhile, ArrayWhereSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileParam), ArraySkipWhileParam, ArraySkipWhileParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParam), ArraySkipWhileChangingParam, ArraySkipWhileChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParam2), ArraySkipWhileChangingParam2, ArraySkipWhileChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParams), ArraySkipWhileChangingParams, ArraySkipWhileChangingParamsRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamsIndexed), ArraySkipWhileChangingParamsIndexed, ArraySkipWhileChangingParamsIndexedRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileToArray), ArraySkipWhileToArray, ArraySkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileReverseToArray), ArraySkipWhileReverseToArray, ArraySkipWhileReverseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileTrueToArray), ArraySkipWhileTrueToArray, ArraySkipWhileTrueToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileFalseToArray), ArraySkipWhileFalseToArray, ArraySkipWhileFalseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipWhileToArray), ArraySelectSkipWhileToArray, ArraySelectSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSkipWhileToArray), ArrayWhereSkipWhileToArray, ArrayWhereSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileParamToArray), ArraySkipWhileParamToArray, ArraySkipWhileParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamToArray), ArraySkipWhileChangingParamToArray, ArraySkipWhileChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamToArray2), ArraySkipWhileChangingParamToArray2, ArraySkipWhileChangingParamToArray2Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipWhileChangingParamsToArray), ArraySkipWhileChangingParamsToArray, ArraySkipWhileChangingParamsToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhile), EnumerableSkipWhile, EnumerableSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileReverse), EnumerableSkipWhileReverse, EnumerableSkipWhileReverseRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileTrue), EnumerableSkipWhileTrue, EnumerableSkipWhileTrueRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileFalse), EnumerableSkipWhileFalse, EnumerableSkipWhileFalseRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSelectSkipWhile), EnumerableSelectSkipWhile, EnumerableSelectSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableWhereSkipWhile), EnumerableWhereSkipWhile, EnumerableWhereSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileParam), EnumerableSkipWhileParam, EnumerableSkipWhileParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParam), EnumerableSkipWhileChangingParam, EnumerableSkipWhileChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParam2), EnumerableSkipWhileChangingParam2, EnumerableSkipWhileChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParams), EnumerableSkipWhileChangingParams, EnumerableSkipWhileChangingParamsRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileToArray), EnumerableSkipWhileToArray, EnumerableSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileReverseToArray), EnumerableSkipWhileReverseToArray, EnumerableSkipWhileReverseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileTrueToArray), EnumerableSkipWhileTrueToArray, EnumerableSkipWhileTrueToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileFalseToArray), EnumerableSkipWhileFalseToArray, EnumerableSkipWhileFalseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSelectSkipWhileToArray), EnumerableSelectSkipWhileToArray, EnumerableSelectSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableWhereSkipWhileToArray), EnumerableWhereSkipWhileToArray, EnumerableWhereSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileParamToArray), EnumerableSkipWhileParamToArray, EnumerableSkipWhileParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParamToArray), EnumerableSkipWhileChangingParamToArray, EnumerableSkipWhileChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParamToArray2), EnumerableSkipWhileChangingParamToArray2, EnumerableSkipWhileChangingParamToArray2Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipWhileChangingParamsToArray), EnumerableSkipWhileChangingParamsToArray, EnumerableSkipWhileChangingParamsToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhile), RangeSkipWhile, RangeSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileReverse), RangeSkipWhileReverse, RangeSkipWhileReverseRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileTrue), RangeSkipWhileTrue, RangeSkipWhileTrueRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileFalse), RangeSkipWhileFalse, RangeSkipWhileFalseRewritten);
        TestsExtensions.TestEquals(nameof(RangeSelectSkipWhile), RangeSelectSkipWhile, RangeSelectSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(RangeWhereSkipWhile), RangeWhereSkipWhile, RangeWhereSkipWhileRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileParam), RangeSkipWhileParam, RangeSkipWhileParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParam), RangeSkipWhileChangingParam, RangeSkipWhileChangingParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParam2), RangeSkipWhileChangingParam2, RangeSkipWhileChangingParam2Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParams), RangeSkipWhileChangingParams, RangeSkipWhileChangingParamsRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileToArray), RangeSkipWhileToArray, RangeSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileReverseToArray), RangeSkipWhileReverseToArray, RangeSkipWhileReverseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileTrueToArray), RangeSkipWhileTrueToArray, RangeSkipWhileTrueToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileFalseToArray), RangeSkipWhileFalseToArray, RangeSkipWhileFalseToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSelectSkipWhileToArray), RangeSelectSkipWhileToArray, RangeSelectSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeWhereSkipWhileToArray), RangeWhereSkipWhileToArray, RangeWhereSkipWhileToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileParamToArray), RangeSkipWhileParamToArray, RangeSkipWhileParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParamToArray), RangeSkipWhileChangingParamToArray, RangeSkipWhileChangingParamToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParamToArray2), RangeSkipWhileChangingParamToArray2, RangeSkipWhileChangingParamToArray2Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipWhileChangingParamsToArray), RangeSkipWhileChangingParamsToArray, RangeSkipWhileChangingParamsToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhile()
    {
        return ArrayItems.SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileRewritten()
    {
        return ArraySkipWhileRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileReverse()
    {
        return ArrayItems.SkipWhile(x => x > 50);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileReverseRewritten()
    {
        return ArraySkipWhileReverseRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileTrue()
    {
        return ArrayItems.SkipWhile(x => true);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileTrueRewritten()
    {
        return ArraySkipWhileTrueRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileFalse()
    {
        return ArrayItems.SkipWhile(x => false);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileFalseRewritten()
    {
        return ArraySkipWhileFalseRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipWhile()
    {
        return ArrayItems.Select(x => x + 20).SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipWhileRewritten()
    {
        return ArraySelectSkipWhileRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereSkipWhile()
    {
        return ArrayItems.Where(x => x > 20).SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> ArrayWhereSkipWhileRewritten()
    {
        return ArrayWhereSkipWhileRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileParam()
    {
        var a = 50;
        return ArrayItems.SkipWhile(x => x < a);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileParamRewritten()
    {
        var a = 50;
        return ArraySkipWhileParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileChangingParam()
    {
        var a = 50;
        return ArrayItems.SkipWhile(x => x < a++);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileChangingParamRewritten()
    {
        var a = 50;
        return ArraySkipWhileChangingParamRewritten_ProceduralLinq1(ArrayItems, x => x < a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileChangingParam2()
    {
        var a = 50;
        return ArrayItems.SkipWhile(x => x < a--);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileChangingParam2Rewritten()
    {
        var a = 50;
        return ArraySkipWhileChangingParam2Rewritten_ProceduralLinq1(ArrayItems, x => x < a--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileChangingParams()
    {
        var a = 50;
        var b = 50;
        return ArrayItems.SkipWhile(x => x < a++ - b--);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileChangingParamsRewritten()
    {
        var a = 50;
        var b = 50;
        return ArraySkipWhileChangingParamsRewritten_ProceduralLinq1(ArrayItems, x => x < a++ - b--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileChangingParamsIndexed()
    {
        var a = 50;
        var b = 50;
        return ArrayItems.SkipWhile((x, i) => x < a++ - b-- + i);
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileChangingParamsIndexedRewritten()
    {
        var a = 50;
        var b = 50;
        return ArrayItems.SkipWhile((x, i) => x < a++ - b-- + i);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileToArray()
    {
        return ArrayItems.SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileToArrayRewritten()
    {
        return ArraySkipWhileToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileReverseToArray()
    {
        return ArrayItems.SkipWhile(x => x > 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileReverseToArrayRewritten()
    {
        return ArraySkipWhileReverseToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileTrueToArray()
    {
        return ArrayItems.SkipWhile(x => true).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileTrueToArrayRewritten()
    {
        return ArraySkipWhileTrueToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileFalseToArray()
    {
        return ArrayItems.SkipWhile(x => false).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileFalseToArrayRewritten()
    {
        return ArraySkipWhileFalseToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipWhileToArray()
    {
        return ArrayItems.Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipWhileToArrayRewritten()
    {
        return ArraySelectSkipWhileToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereSkipWhileToArray()
    {
        return ArrayItems.Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereSkipWhileToArrayRewritten()
    {
        return ArrayWhereSkipWhileToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileParamToArray()
    {
        var a = 50;
        return ArrayItems.SkipWhile(x => x < a).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileParamToArrayRewritten()
    {
        var a = 50;
        return ArraySkipWhileParamToArrayRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileChangingParamToArray()
    {
        var a = 50;
        return ArrayItems.SkipWhile(x => x < a++).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileChangingParamToArrayRewritten()
    {
        var a = 50;
        return ArraySkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileChangingParamToArray2()
    {
        var a = 50;
        return ArrayItems.SkipWhile(x => x < a--).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileChangingParamToArray2Rewritten()
    {
        var a = 50;
        return ArraySkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipWhileChangingParamsToArray()
    {
        var a = 50;
        var b = 50;
        return ArrayItems.SkipWhile(x => x < a++ - b--).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipWhileChangingParamsToArrayRewritten()
    {
        var a = 50;
        var b = 50;
        return ArraySkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref a, ref b, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhile()
    {
        return EnumerableItems.SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileRewritten()
    {
        return EnumerableSkipWhileRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileReverse()
    {
        return EnumerableItems.SkipWhile(x => x > 50);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileReverseRewritten()
    {
        return EnumerableSkipWhileReverseRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileTrue()
    {
        return EnumerableItems.SkipWhile(x => true);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileTrueRewritten()
    {
        return EnumerableSkipWhileTrueRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileFalse()
    {
        return EnumerableItems.SkipWhile(x => false);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileFalseRewritten()
    {
        return EnumerableSkipWhileFalseRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSelectSkipWhile()
    {
        return EnumerableItems.Select(x => x + 20).SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> EnumerableSelectSkipWhileRewritten()
    {
        return EnumerableSelectSkipWhileRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableWhereSkipWhile()
    {
        return EnumerableItems.Where(x => x > 20).SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> EnumerableWhereSkipWhileRewritten()
    {
        return EnumerableWhereSkipWhileRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileParam()
    {
        var a = 50;
        return EnumerableItems.SkipWhile(x => x < a);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileParamRewritten()
    {
        var a = 50;
        return EnumerableSkipWhileParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileChangingParam()
    {
        var a = 50;
        return EnumerableItems.SkipWhile(x => x < a++);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileChangingParamRewritten()
    {
        var a = 50;
        return EnumerableSkipWhileChangingParamRewritten_ProceduralLinq1(EnumerableItems, x => x < a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileChangingParam2()
    {
        var a = 50;
        return EnumerableItems.SkipWhile(x => x < a--);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileChangingParam2Rewritten()
    {
        var a = 50;
        return EnumerableSkipWhileChangingParam2Rewritten_ProceduralLinq1(EnumerableItems, x => x < a--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileChangingParams()
    {
        var a = 50;
        var b = 50;
        return EnumerableItems.SkipWhile(x => x < a++ - b--);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileChangingParamsRewritten()
    {
        var a = 50;
        var b = 50;
        return EnumerableSkipWhileChangingParamsRewritten_ProceduralLinq1(EnumerableItems, x => x < a++ - b--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileToArray()
    {
        return EnumerableItems.SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileToArrayRewritten()
    {
        return EnumerableSkipWhileToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileReverseToArray()
    {
        return EnumerableItems.SkipWhile(x => x > 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileReverseToArrayRewritten()
    {
        return EnumerableSkipWhileReverseToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileTrueToArray()
    {
        return EnumerableItems.SkipWhile(x => true).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileTrueToArrayRewritten()
    {
        return EnumerableSkipWhileTrueToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileFalseToArray()
    {
        return EnumerableItems.SkipWhile(x => false).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileFalseToArrayRewritten()
    {
        return EnumerableSkipWhileFalseToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSelectSkipWhileToArray()
    {
        return EnumerableItems.Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSelectSkipWhileToArrayRewritten()
    {
        return EnumerableSelectSkipWhileToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableWhereSkipWhileToArray()
    {
        return EnumerableItems.Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableWhereSkipWhileToArrayRewritten()
    {
        return EnumerableWhereSkipWhileToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileParamToArray()
    {
        var a = 50;
        return EnumerableItems.SkipWhile(x => x < a).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileParamToArrayRewritten()
    {
        var a = 50;
        return EnumerableSkipWhileParamToArrayRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileChangingParamToArray()
    {
        var a = 50;
        return EnumerableItems.SkipWhile(x => x < a++).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileChangingParamToArrayRewritten()
    {
        var a = 50;
        return EnumerableSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileChangingParamToArray2()
    {
        var a = 50;
        return EnumerableItems.SkipWhile(x => x < a--).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileChangingParamToArray2Rewritten()
    {
        var a = 50;
        return EnumerableSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipWhileChangingParamsToArray()
    {
        var a = 50;
        var b = 50;
        return EnumerableItems.SkipWhile(x => x < a++ - b--).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipWhileChangingParamsToArrayRewritten()
    {
        var a = 50;
        var b = 50;
        return EnumerableSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref a, ref b, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhile()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileRewritten()
    {
        return RangeSkipWhileRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileReverse()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => x > 50);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileReverseRewritten()
    {
        return RangeSkipWhileReverseRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileTrue()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => true);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileTrueRewritten()
    {
        return RangeSkipWhileTrueRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileFalse()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => false);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileFalseRewritten()
    {
        return RangeSkipWhileFalseRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSelectSkipWhile()
    {
        return Enumerable.Range(0, 100).Select(x => x + 20).SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> RangeSelectSkipWhileRewritten()
    {
        return RangeSelectSkipWhileRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeWhereSkipWhile()
    {
        return Enumerable.Range(0, 100).Where(x => x > 20).SkipWhile(x => x < 50);
    } //EndMethod

    public IEnumerable<int> RangeWhereSkipWhileRewritten()
    {
        return RangeWhereSkipWhileRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileParamRewritten()
    {
        var a = 50;
        return RangeSkipWhileParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileChangingParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a++);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileChangingParamRewritten()
    {
        var a = 50;
        return RangeSkipWhileChangingParamRewritten_ProceduralLinq1(x => x < a++);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileChangingParam2()
    {
        var a = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a--);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileChangingParam2Rewritten()
    {
        var a = 50;
        return RangeSkipWhileChangingParam2Rewritten_ProceduralLinq1(x => x < a--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileChangingParams()
    {
        var a = 50;
        var b = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a++ - b--);
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileChangingParamsRewritten()
    {
        var a = 50;
        var b = 50;
        return RangeSkipWhileChangingParamsRewritten_ProceduralLinq1(x => x < a++ - b--);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileToArray()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileToArrayRewritten()
    {
        return RangeSkipWhileToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileReverseToArray()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => x > 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileReverseToArrayRewritten()
    {
        return RangeSkipWhileReverseToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileTrueToArray()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => true).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileTrueToArrayRewritten()
    {
        return RangeSkipWhileTrueToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileFalseToArray()
    {
        return Enumerable.Range(0, 100).SkipWhile(x => false).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileFalseToArrayRewritten()
    {
        return RangeSkipWhileFalseToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSelectSkipWhileToArray()
    {
        return Enumerable.Range(0, 100).Select(x => x + 20).SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSelectSkipWhileToArrayRewritten()
    {
        return RangeSelectSkipWhileToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeWhereSkipWhileToArray()
    {
        return Enumerable.Range(0, 100).Where(x => x > 20).SkipWhile(x => x < 50).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeWhereSkipWhileToArrayRewritten()
    {
        return RangeWhereSkipWhileToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileParamToArray()
    {
        var a = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileParamToArrayRewritten()
    {
        var a = 50;
        return RangeSkipWhileParamToArrayRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileChangingParamToArray()
    {
        var a = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a++).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileChangingParamToArrayRewritten()
    {
        var a = 50;
        return RangeSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileChangingParamToArray2()
    {
        var a = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a--).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileChangingParamToArray2Rewritten()
    {
        var a = 50;
        return RangeSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipWhileChangingParamsToArray()
    {
        var a = 50;
        var b = 50;
        return Enumerable.Range(0, 100).SkipWhile(x => x < a++ - b--).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipWhileChangingParamsToArrayRewritten()
    {
        var a = 50;
        var b = 50;
        return RangeSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref a, ref b);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2140;
        int v2141;
        bool v2142;
        v2142 = true;
        v2140 = (0);
        for (; v2140 < (ArrayItems.Length); v2140++)
        {
            v2141 = (ArrayItems[v2140]);
            if (v2142 && ((v2141) < 50))
                continue;
            v2142 = false;
            yield return (v2141);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileReverseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2143;
        int v2144;
        bool v2145;
        v2145 = true;
        v2143 = (0);
        for (; v2143 < (ArrayItems.Length); v2143++)
        {
            v2144 = (ArrayItems[v2143]);
            if (v2145 && ((v2144) > 50))
                continue;
            v2145 = false;
            yield return (v2144);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileTrueRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2146;
        int v2147;
        bool v2148;
        v2148 = true;
        v2146 = (0);
        for (; v2146 < (ArrayItems.Length); v2146++)
        {
            v2147 = (ArrayItems[v2146]);
            if (v2148 && (true))
                continue;
            v2148 = false;
            yield return (v2147);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2149;
        int v2150;
        bool v2151;
        v2151 = true;
        v2149 = (0);
        for (; v2149 < (ArrayItems.Length); v2149++)
        {
            v2150 = (ArrayItems[v2149]);
            if (v2151 && (false))
                continue;
            v2151 = false;
            yield return (v2150);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectSkipWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2152;
        int v2153;
        bool v2154;
        v2154 = true;
        v2152 = (0);
        for (; v2152 < (ArrayItems.Length); v2152++)
        {
            v2153 = (20 + ArrayItems[v2152]);
            if (v2154 && ((v2153) < 50))
                continue;
            v2154 = false;
            yield return (v2153);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSkipWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2155;
        int v2156;
        bool v2157;
        v2157 = true;
        v2155 = (0);
        for (; v2155 < (ArrayItems.Length); v2155++)
        {
            v2156 = (ArrayItems[v2155]);
            if (!(((v2156) > 20)))
                continue;
            v2156 = (v2156);
            if (v2157 && ((v2156) < 50))
                continue;
            v2157 = false;
            yield return (v2156);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2158;
        int v2159;
        bool v2160;
        v2160 = true;
        v2158 = (0);
        for (; v2158 < (ArrayItems.Length); v2158++)
        {
            v2159 = (ArrayItems[v2158]);
            if (v2160 && ((v2159) < a))
                continue;
            v2160 = false;
            yield return (v2159);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2163)
    {
        int v2161;
        int v2162;
        bool v2164;
        v2164 = true;
        v2161 = (0);
        for (; v2161 < (ArrayItems.Length); v2161++)
        {
            v2162 = (ArrayItems[v2161]);
            if (v2164 && v2163((v2162)))
                continue;
            v2164 = false;
            yield return (v2162);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParam2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2167)
    {
        int v2165;
        int v2166;
        bool v2168;
        v2168 = true;
        v2165 = (0);
        for (; v2165 < (ArrayItems.Length); v2165++)
        {
            v2166 = (ArrayItems[v2165]);
            if (v2168 && v2167((v2166)))
                continue;
            v2168 = false;
            yield return (v2166);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParamsRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v2171)
    {
        int v2169;
        int v2170;
        bool v2172;
        v2172 = true;
        v2169 = (0);
        for (; v2169 < (ArrayItems.Length); v2169++)
        {
            v2170 = (ArrayItems[v2169]);
            if (v2172 && v2171((v2170)))
                continue;
            v2172 = false;
            yield return (v2170);
        }

        yield break;
    }

    int[] ArraySkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2173;
        int v2174;
        bool v2175;
        int v2176;
        int v2177;
        int v2178;
        int[] v2179;
        v2175 = true;
        v2176 = 0;
        v2177 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2177 -= (v2177 % 2);
        v2178 = 8;
        v2179 = new int[8];
        v2173 = (0);
        for (; v2173 < (ArrayItems.Length); v2173++)
        {
            v2174 = (ArrayItems[v2173]);
            if (v2175 && ((v2174) < 50))
                continue;
            v2175 = false;
            if (v2176 >= v2178)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2179, ref v2177, out v2178);
            v2179[v2176] = (v2174);
            v2176++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2179, v2176);
    }

    int[] ArraySkipWhileReverseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2180;
        int v2181;
        bool v2182;
        int v2183;
        int v2184;
        int v2185;
        int[] v2186;
        v2182 = true;
        v2183 = 0;
        v2184 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2184 -= (v2184 % 2);
        v2185 = 8;
        v2186 = new int[8];
        v2180 = (0);
        for (; v2180 < (ArrayItems.Length); v2180++)
        {
            v2181 = (ArrayItems[v2180]);
            if (v2182 && ((v2181) > 50))
                continue;
            v2182 = false;
            if (v2183 >= v2185)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2186, ref v2184, out v2185);
            v2186[v2183] = (v2181);
            v2183++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2186, v2183);
    }

    int[] ArraySkipWhileTrueToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2187;
        int v2188;
        bool v2189;
        int v2190;
        int v2191;
        int v2192;
        int[] v2193;
        v2189 = true;
        v2190 = 0;
        v2191 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2191 -= (v2191 % 2);
        v2192 = 8;
        v2193 = new int[8];
        v2187 = (0);
        for (; v2187 < (ArrayItems.Length); v2187++)
        {
            v2188 = (ArrayItems[v2187]);
            if (v2189 && (true))
                continue;
            v2189 = false;
            if (v2190 >= v2192)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2193, ref v2191, out v2192);
            v2193[v2190] = (v2188);
            v2190++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2193, v2190);
    }

    int[] ArraySkipWhileFalseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2194;
        int v2195;
        bool v2196;
        int v2197;
        int v2198;
        int v2199;
        int[] v2200;
        v2196 = true;
        v2197 = 0;
        v2198 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2198 -= (v2198 % 2);
        v2199 = 8;
        v2200 = new int[8];
        v2194 = (0);
        for (; v2194 < (ArrayItems.Length); v2194++)
        {
            v2195 = (ArrayItems[v2194]);
            if (v2196 && (false))
                continue;
            v2196 = false;
            if (v2197 >= v2199)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2200, ref v2198, out v2199);
            v2200[v2197] = (v2195);
            v2197++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2200, v2197);
    }

    int[] ArraySelectSkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2201;
        int v2202;
        bool v2203;
        int v2204;
        int v2205;
        int v2206;
        int[] v2207;
        v2203 = true;
        v2204 = 0;
        v2205 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2205 -= (v2205 % 2);
        v2206 = 8;
        v2207 = new int[8];
        v2201 = (0);
        for (; v2201 < (ArrayItems.Length); v2201++)
        {
            v2202 = (20 + ArrayItems[v2201]);
            if (v2203 && ((v2202) < 50))
                continue;
            v2203 = false;
            if (v2204 >= v2206)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2207, ref v2205, out v2206);
            v2207[v2204] = (v2202);
            v2204++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2207, v2204);
    }

    int[] ArrayWhereSkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v2208;
        int v2209;
        bool v2210;
        int v2211;
        int v2212;
        int v2213;
        int[] v2214;
        v2210 = true;
        v2211 = 0;
        v2212 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2212 -= (v2212 % 2);
        v2213 = 8;
        v2214 = new int[8];
        v2208 = (0);
        for (; v2208 < (ArrayItems.Length); v2208++)
        {
            v2209 = (ArrayItems[v2208]);
            if (!(((v2209) > 20)))
                continue;
            v2209 = (v2209);
            if (v2210 && ((v2209) < 50))
                continue;
            v2210 = false;
            if (v2211 >= v2213)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2214, ref v2212, out v2213);
            v2214[v2211] = (v2209);
            v2211++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2214, v2211);
    }

    int[] ArraySkipWhileParamToArrayRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2215;
        int v2216;
        bool v2217;
        int v2218;
        int v2219;
        int v2220;
        int[] v2221;
        v2217 = true;
        v2218 = 0;
        v2219 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2219 -= (v2219 % 2);
        v2220 = 8;
        v2221 = new int[8];
        v2215 = (0);
        for (; v2215 < (ArrayItems.Length); v2215++)
        {
            v2216 = (ArrayItems[v2215]);
            if (v2217 && ((v2216) < a))
                continue;
            v2217 = false;
            if (v2218 >= v2220)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2221, ref v2219, out v2220);
            v2221[v2218] = (v2216);
            v2218++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2221, v2218);
    }

    int[] ArraySkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2222;
        int v2223;
        bool v2224;
        int v2225;
        int v2226;
        int v2227;
        int[] v2228;
        v2224 = true;
        v2225 = 0;
        v2226 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2226 -= (v2226 % 2);
        v2227 = 8;
        v2228 = new int[8];
        v2222 = (0);
        for (; v2222 < (ArrayItems.Length); v2222++)
        {
            v2223 = (ArrayItems[v2222]);
            if (v2224 && ((v2223) < a++))
                continue;
            v2224 = false;
            if (v2225 >= v2227)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2228, ref v2226, out v2227);
            v2228[v2225] = (v2223);
            v2225++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2228, v2225);
    }

    int[] ArraySkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2229;
        int v2230;
        bool v2231;
        int v2232;
        int v2233;
        int v2234;
        int[] v2235;
        v2231 = true;
        v2232 = 0;
        v2233 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2233 -= (v2233 % 2);
        v2234 = 8;
        v2235 = new int[8];
        v2229 = (0);
        for (; v2229 < (ArrayItems.Length); v2229++)
        {
            v2230 = (ArrayItems[v2229]);
            if (v2231 && ((v2230) < a--))
                continue;
            v2231 = false;
            if (v2232 >= v2234)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2235, ref v2233, out v2234);
            v2235[v2232] = (v2230);
            v2232++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2235, v2232);
    }

    int[] ArraySkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, int[] ArrayItems)
    {
        int v2236;
        int v2237;
        bool v2238;
        int v2239;
        int v2240;
        int v2241;
        int[] v2242;
        v2238 = true;
        v2239 = 0;
        v2240 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2240 -= (v2240 % 2);
        v2241 = 8;
        v2242 = new int[8];
        v2236 = (0);
        for (; v2236 < (ArrayItems.Length); v2236++)
        {
            v2237 = (ArrayItems[v2236]);
            if (v2238 && ((v2237) < a++ - b--))
                continue;
            v2238 = false;
            if (v2239 >= v2241)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2242, ref v2240, out v2241);
            v2242[v2239] = (v2237);
            v2239++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2242, v2239);
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2243;
        int v2244;
        bool v2245;
        v2243 = EnumerableItems.GetEnumerator();
        v2245 = true;
        try
        {
            while (v2243.MoveNext())
            {
                v2244 = (v2243.Current);
                if (v2245 && ((v2244) < 50))
                    continue;
                v2245 = false;
                yield return (v2244);
            }
        }
        finally
        {
            v2243.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileReverseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2246;
        int v2247;
        bool v2248;
        v2246 = EnumerableItems.GetEnumerator();
        v2248 = true;
        try
        {
            while (v2246.MoveNext())
            {
                v2247 = (v2246.Current);
                if (v2248 && ((v2247) > 50))
                    continue;
                v2248 = false;
                yield return (v2247);
            }
        }
        finally
        {
            v2246.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileTrueRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2249;
        int v2250;
        bool v2251;
        v2249 = EnumerableItems.GetEnumerator();
        v2251 = true;
        try
        {
            while (v2249.MoveNext())
            {
                v2250 = (v2249.Current);
                if (v2251 && (true))
                    continue;
                v2251 = false;
                yield return (v2250);
            }
        }
        finally
        {
            v2249.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileFalseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2252;
        int v2253;
        bool v2254;
        v2252 = EnumerableItems.GetEnumerator();
        v2254 = true;
        try
        {
            while (v2252.MoveNext())
            {
                v2253 = (v2252.Current);
                if (v2254 && (false))
                    continue;
                v2254 = false;
                yield return (v2253);
            }
        }
        finally
        {
            v2252.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSelectSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2255;
        int v2256;
        bool v2257;
        v2255 = EnumerableItems.GetEnumerator();
        v2257 = true;
        try
        {
            while (v2255.MoveNext())
            {
                v2256 = (20 + v2255.Current);
                if (v2257 && ((v2256) < 50))
                    continue;
                v2257 = false;
                yield return (v2256);
            }
        }
        finally
        {
            v2255.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2258;
        int v2259;
        bool v2260;
        v2258 = EnumerableItems.GetEnumerator();
        v2260 = true;
        try
        {
            while (v2258.MoveNext())
            {
                v2259 = (v2258.Current);
                if (!(((v2259) > 20)))
                    continue;
                v2259 = (v2259);
                if (v2260 && ((v2259) < 50))
                    continue;
                v2260 = false;
                yield return (v2259);
            }
        }
        finally
        {
            v2258.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2261;
        int v2262;
        bool v2263;
        v2261 = EnumerableItems.GetEnumerator();
        v2263 = true;
        try
        {
            while (v2261.MoveNext())
            {
                v2262 = (v2261.Current);
                if (v2263 && ((v2262) < a))
                    continue;
                v2263 = false;
                yield return (v2262);
            }
        }
        finally
        {
            v2261.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParamRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2266)
    {
        IEnumerator<int> v2264;
        int v2265;
        bool v2267;
        v2264 = EnumerableItems.GetEnumerator();
        v2267 = true;
        try
        {
            while (v2264.MoveNext())
            {
                v2265 = (v2264.Current);
                if (v2267 && v2266((v2265)))
                    continue;
                v2267 = false;
                yield return (v2265);
            }
        }
        finally
        {
            v2264.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParam2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2270)
    {
        IEnumerator<int> v2268;
        int v2269;
        bool v2271;
        v2268 = EnumerableItems.GetEnumerator();
        v2271 = true;
        try
        {
            while (v2268.MoveNext())
            {
                v2269 = (v2268.Current);
                if (v2271 && v2270((v2269)))
                    continue;
                v2271 = false;
                yield return (v2269);
            }
        }
        finally
        {
            v2268.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParamsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2274)
    {
        IEnumerator<int> v2272;
        int v2273;
        bool v2275;
        v2272 = EnumerableItems.GetEnumerator();
        v2275 = true;
        try
        {
            while (v2272.MoveNext())
            {
                v2273 = (v2272.Current);
                if (v2275 && v2274((v2273)))
                    continue;
                v2275 = false;
                yield return (v2273);
            }
        }
        finally
        {
            v2272.Dispose();
        }

        yield break;
    }

    int[] EnumerableSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2276;
        int v2277;
        bool v2278;
        int v2279;
        int v2280;
        int[] v2281;
        v2276 = EnumerableItems.GetEnumerator();
        v2278 = true;
        v2279 = 0;
        v2280 = 8;
        v2281 = new int[8];
        try
        {
            while (v2276.MoveNext())
            {
                v2277 = (v2276.Current);
                if (v2278 && ((v2277) < 50))
                    continue;
                v2278 = false;
                if (v2279 >= v2280)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2281, ref v2280);
                v2281[v2279] = (v2277);
                v2279++;
            }
        }
        finally
        {
            v2276.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2281, v2279);
    }

    int[] EnumerableSkipWhileReverseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2282;
        int v2283;
        bool v2284;
        int v2285;
        int v2286;
        int[] v2287;
        v2282 = EnumerableItems.GetEnumerator();
        v2284 = true;
        v2285 = 0;
        v2286 = 8;
        v2287 = new int[8];
        try
        {
            while (v2282.MoveNext())
            {
                v2283 = (v2282.Current);
                if (v2284 && ((v2283) > 50))
                    continue;
                v2284 = false;
                if (v2285 >= v2286)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2287, ref v2286);
                v2287[v2285] = (v2283);
                v2285++;
            }
        }
        finally
        {
            v2282.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2287, v2285);
    }

    int[] EnumerableSkipWhileTrueToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2288;
        int v2289;
        bool v2290;
        int v2291;
        int v2292;
        int[] v2293;
        v2288 = EnumerableItems.GetEnumerator();
        v2290 = true;
        v2291 = 0;
        v2292 = 8;
        v2293 = new int[8];
        try
        {
            while (v2288.MoveNext())
            {
                v2289 = (v2288.Current);
                if (v2290 && (true))
                    continue;
                v2290 = false;
                if (v2291 >= v2292)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2293, ref v2292);
                v2293[v2291] = (v2289);
                v2291++;
            }
        }
        finally
        {
            v2288.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2293, v2291);
    }

    int[] EnumerableSkipWhileFalseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2294;
        int v2295;
        bool v2296;
        int v2297;
        int v2298;
        int[] v2299;
        v2294 = EnumerableItems.GetEnumerator();
        v2296 = true;
        v2297 = 0;
        v2298 = 8;
        v2299 = new int[8];
        try
        {
            while (v2294.MoveNext())
            {
                v2295 = (v2294.Current);
                if (v2296 && (false))
                    continue;
                v2296 = false;
                if (v2297 >= v2298)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2299, ref v2298);
                v2299[v2297] = (v2295);
                v2297++;
            }
        }
        finally
        {
            v2294.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2299, v2297);
    }

    int[] EnumerableSelectSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2300;
        int v2301;
        bool v2302;
        int v2303;
        int v2304;
        int[] v2305;
        v2300 = EnumerableItems.GetEnumerator();
        v2302 = true;
        v2303 = 0;
        v2304 = 8;
        v2305 = new int[8];
        try
        {
            while (v2300.MoveNext())
            {
                v2301 = (20 + v2300.Current);
                if (v2302 && ((v2301) < 50))
                    continue;
                v2302 = false;
                if (v2303 >= v2304)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2305, ref v2304);
                v2305[v2303] = (v2301);
                v2303++;
            }
        }
        finally
        {
            v2300.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2305, v2303);
    }

    int[] EnumerableWhereSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2306;
        int v2307;
        bool v2308;
        int v2309;
        int v2310;
        int[] v2311;
        v2306 = EnumerableItems.GetEnumerator();
        v2308 = true;
        v2309 = 0;
        v2310 = 8;
        v2311 = new int[8];
        try
        {
            while (v2306.MoveNext())
            {
                v2307 = (v2306.Current);
                if (!(((v2307) > 20)))
                    continue;
                v2307 = (v2307);
                if (v2308 && ((v2307) < 50))
                    continue;
                v2308 = false;
                if (v2309 >= v2310)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2311, ref v2310);
                v2311[v2309] = (v2307);
                v2309++;
            }
        }
        finally
        {
            v2306.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2311, v2309);
    }

    int[] EnumerableSkipWhileParamToArrayRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2312;
        int v2313;
        bool v2314;
        int v2315;
        int v2316;
        int[] v2317;
        v2312 = EnumerableItems.GetEnumerator();
        v2314 = true;
        v2315 = 0;
        v2316 = 8;
        v2317 = new int[8];
        try
        {
            while (v2312.MoveNext())
            {
                v2313 = (v2312.Current);
                if (v2314 && ((v2313) < a))
                    continue;
                v2314 = false;
                if (v2315 >= v2316)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2317, ref v2316);
                v2317[v2315] = (v2313);
                v2315++;
            }
        }
        finally
        {
            v2312.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2317, v2315);
    }

    int[] EnumerableSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2318;
        int v2319;
        bool v2320;
        int v2321;
        int v2322;
        int[] v2323;
        v2318 = EnumerableItems.GetEnumerator();
        v2320 = true;
        v2321 = 0;
        v2322 = 8;
        v2323 = new int[8];
        try
        {
            while (v2318.MoveNext())
            {
                v2319 = (v2318.Current);
                if (v2320 && ((v2319) < a++))
                    continue;
                v2320 = false;
                if (v2321 >= v2322)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2323, ref v2322);
                v2323[v2321] = (v2319);
                v2321++;
            }
        }
        finally
        {
            v2318.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2323, v2321);
    }

    int[] EnumerableSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2324;
        int v2325;
        bool v2326;
        int v2327;
        int v2328;
        int[] v2329;
        v2324 = EnumerableItems.GetEnumerator();
        v2326 = true;
        v2327 = 0;
        v2328 = 8;
        v2329 = new int[8];
        try
        {
            while (v2324.MoveNext())
            {
                v2325 = (v2324.Current);
                if (v2326 && ((v2325) < a--))
                    continue;
                v2326 = false;
                if (v2327 >= v2328)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2329, ref v2328);
                v2329[v2327] = (v2325);
                v2327++;
            }
        }
        finally
        {
            v2324.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2329, v2327);
    }

    int[] EnumerableSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2330;
        int v2331;
        bool v2332;
        int v2333;
        int v2334;
        int[] v2335;
        v2330 = EnumerableItems.GetEnumerator();
        v2332 = true;
        v2333 = 0;
        v2334 = 8;
        v2335 = new int[8];
        try
        {
            while (v2330.MoveNext())
            {
                v2331 = (v2330.Current);
                if (v2332 && ((v2331) < a++ - b--))
                    continue;
                v2332 = false;
                if (v2333 >= v2334)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2335, ref v2334);
                v2335[v2333] = (v2331);
                v2333++;
            }
        }
        finally
        {
            v2330.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2335, v2333);
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileRewritten_ProceduralLinq1()
    {
        int v2336;
        int v2337;
        bool v2338;
        v2338 = true;
        v2336 = (0);
        for (; v2336 < (100); v2336++)
        {
            v2337 = (v2336);
            if (v2338 && ((v2337) < 50))
                continue;
            v2338 = false;
            yield return (v2337);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileReverseRewritten_ProceduralLinq1()
    {
        int v2339;
        int v2340;
        bool v2341;
        v2341 = true;
        v2339 = (0);
        for (; v2339 < (100); v2339++)
        {
            v2340 = (v2339);
            if (v2341 && ((v2340) > 50))
                continue;
            v2341 = false;
            yield return (v2340);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileTrueRewritten_ProceduralLinq1()
    {
        int v2342;
        int v2343;
        bool v2344;
        v2344 = true;
        v2342 = (0);
        for (; v2342 < (100); v2342++)
        {
            v2343 = (v2342);
            if (v2344 && (true))
                continue;
            v2344 = false;
            yield return (v2343);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileFalseRewritten_ProceduralLinq1()
    {
        int v2345;
        int v2346;
        bool v2347;
        v2347 = true;
        v2345 = (0);
        for (; v2345 < (100); v2345++)
        {
            v2346 = (v2345);
            if (v2347 && (false))
                continue;
            v2347 = false;
            yield return (v2346);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSelectSkipWhileRewritten_ProceduralLinq1()
    {
        int v2348;
        int v2349;
        bool v2350;
        v2350 = true;
        v2348 = (0);
        for (; v2348 < (100); v2348++)
        {
            v2349 = (20 + v2348);
            if (v2350 && ((v2349) < 50))
                continue;
            v2350 = false;
            yield return (v2349);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereSkipWhileRewritten_ProceduralLinq1()
    {
        int v2351;
        int v2352;
        bool v2353;
        v2353 = true;
        v2351 = (0);
        for (; v2351 < (100); v2351++)
        {
            v2352 = (v2351);
            if (!(((v2352) > 20)))
                continue;
            v2352 = (v2352);
            if (v2353 && ((v2352) < 50))
                continue;
            v2353 = false;
            yield return (v2352);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileParamRewritten_ProceduralLinq1(int a)
    {
        int v2354;
        int v2355;
        bool v2356;
        v2356 = true;
        v2354 = (0);
        for (; v2354 < (100); v2354++)
        {
            v2355 = (v2354);
            if (v2356 && ((v2355) < a))
                continue;
            v2356 = false;
            yield return (v2355);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParamRewritten_ProceduralLinq1(System.Func<int, bool> v2359)
    {
        int v2357;
        int v2358;
        bool v2360;
        v2360 = true;
        v2357 = (0);
        for (; v2357 < (100); v2357++)
        {
            v2358 = (v2357);
            if (v2360 && v2359((v2358)))
                continue;
            v2360 = false;
            yield return (v2358);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParam2Rewritten_ProceduralLinq1(System.Func<int, bool> v2363)
    {
        int v2361;
        int v2362;
        bool v2364;
        v2364 = true;
        v2361 = (0);
        for (; v2361 < (100); v2361++)
        {
            v2362 = (v2361);
            if (v2364 && v2363((v2362)))
                continue;
            v2364 = false;
            yield return (v2362);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParamsRewritten_ProceduralLinq1(System.Func<int, bool> v2367)
    {
        int v2365;
        int v2366;
        bool v2368;
        v2368 = true;
        v2365 = (0);
        for (; v2365 < (100); v2365++)
        {
            v2366 = (v2365);
            if (v2368 && v2367((v2366)))
                continue;
            v2368 = false;
            yield return (v2366);
        }

        yield break;
    }

    int[] RangeSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2369;
        int v2370;
        bool v2371;
        int v2372;
        int v2373;
        int v2374;
        int[] v2375;
        v2371 = true;
        v2372 = 0;
        v2373 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2373 -= (v2373 % 2);
        v2374 = 8;
        v2375 = new int[8];
        v2369 = (0);
        for (; v2369 < (100); v2369++)
        {
            v2370 = (v2369);
            if (v2371 && ((v2370) < 50))
                continue;
            v2371 = false;
            if (v2372 >= v2374)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2375, ref v2373, out v2374);
            v2375[v2372] = (v2370);
            v2372++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2375, v2372);
    }

    int[] RangeSkipWhileReverseToArrayRewritten_ProceduralLinq1()
    {
        int v2376;
        int v2377;
        bool v2378;
        int v2379;
        int v2380;
        int v2381;
        int[] v2382;
        v2378 = true;
        v2379 = 0;
        v2380 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2380 -= (v2380 % 2);
        v2381 = 8;
        v2382 = new int[8];
        v2376 = (0);
        for (; v2376 < (100); v2376++)
        {
            v2377 = (v2376);
            if (v2378 && ((v2377) > 50))
                continue;
            v2378 = false;
            if (v2379 >= v2381)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2382, ref v2380, out v2381);
            v2382[v2379] = (v2377);
            v2379++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2382, v2379);
    }

    int[] RangeSkipWhileTrueToArrayRewritten_ProceduralLinq1()
    {
        int v2383;
        int v2384;
        bool v2385;
        int v2386;
        int v2387;
        int v2388;
        int[] v2389;
        v2385 = true;
        v2386 = 0;
        v2387 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2387 -= (v2387 % 2);
        v2388 = 8;
        v2389 = new int[8];
        v2383 = (0);
        for (; v2383 < (100); v2383++)
        {
            v2384 = (v2383);
            if (v2385 && (true))
                continue;
            v2385 = false;
            if (v2386 >= v2388)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2389, ref v2387, out v2388);
            v2389[v2386] = (v2384);
            v2386++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2389, v2386);
    }

    int[] RangeSkipWhileFalseToArrayRewritten_ProceduralLinq1()
    {
        int v2390;
        int v2391;
        bool v2392;
        int v2393;
        int v2394;
        int v2395;
        int[] v2396;
        v2392 = true;
        v2393 = 0;
        v2394 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2394 -= (v2394 % 2);
        v2395 = 8;
        v2396 = new int[8];
        v2390 = (0);
        for (; v2390 < (100); v2390++)
        {
            v2391 = (v2390);
            if (v2392 && (false))
                continue;
            v2392 = false;
            if (v2393 >= v2395)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2396, ref v2394, out v2395);
            v2396[v2393] = (v2391);
            v2393++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2396, v2393);
    }

    int[] RangeSelectSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2397;
        int v2398;
        bool v2399;
        int v2400;
        int v2401;
        int v2402;
        int[] v2403;
        v2399 = true;
        v2400 = 0;
        v2401 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2401 -= (v2401 % 2);
        v2402 = 8;
        v2403 = new int[8];
        v2397 = (0);
        for (; v2397 < (100); v2397++)
        {
            v2398 = (20 + v2397);
            if (v2399 && ((v2398) < 50))
                continue;
            v2399 = false;
            if (v2400 >= v2402)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2403, ref v2401, out v2402);
            v2403[v2400] = (v2398);
            v2400++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2403, v2400);
    }

    int[] RangeWhereSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2404;
        int v2405;
        bool v2406;
        int v2407;
        int v2408;
        int v2409;
        int[] v2410;
        v2406 = true;
        v2407 = 0;
        v2408 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2408 -= (v2408 % 2);
        v2409 = 8;
        v2410 = new int[8];
        v2404 = (0);
        for (; v2404 < (100); v2404++)
        {
            v2405 = (v2404);
            if (!(((v2405) > 20)))
                continue;
            v2405 = (v2405);
            if (v2406 && ((v2405) < 50))
                continue;
            v2406 = false;
            if (v2407 >= v2409)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2410, ref v2408, out v2409);
            v2410[v2407] = (v2405);
            v2407++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2410, v2407);
    }

    int[] RangeSkipWhileParamToArrayRewritten_ProceduralLinq1(int a)
    {
        int v2411;
        int v2412;
        bool v2413;
        int v2414;
        int v2415;
        int v2416;
        int[] v2417;
        v2413 = true;
        v2414 = 0;
        v2415 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2415 -= (v2415 % 2);
        v2416 = 8;
        v2417 = new int[8];
        v2411 = (0);
        for (; v2411 < (100); v2411++)
        {
            v2412 = (v2411);
            if (v2413 && ((v2412) < a))
                continue;
            v2413 = false;
            if (v2414 >= v2416)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2417, ref v2415, out v2416);
            v2417[v2414] = (v2412);
            v2414++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2417, v2414);
    }

    int[] RangeSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a)
    {
        int v2418;
        int v2419;
        bool v2420;
        int v2421;
        int v2422;
        int v2423;
        int[] v2424;
        v2420 = true;
        v2421 = 0;
        v2422 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2422 -= (v2422 % 2);
        v2423 = 8;
        v2424 = new int[8];
        v2418 = (0);
        for (; v2418 < (100); v2418++)
        {
            v2419 = (v2418);
            if (v2420 && ((v2419) < a++))
                continue;
            v2420 = false;
            if (v2421 >= v2423)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2424, ref v2422, out v2423);
            v2424[v2421] = (v2419);
            v2421++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2424, v2421);
    }

    int[] RangeSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a)
    {
        int v2425;
        int v2426;
        bool v2427;
        int v2428;
        int v2429;
        int v2430;
        int[] v2431;
        v2427 = true;
        v2428 = 0;
        v2429 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2429 -= (v2429 % 2);
        v2430 = 8;
        v2431 = new int[8];
        v2425 = (0);
        for (; v2425 < (100); v2425++)
        {
            v2426 = (v2425);
            if (v2427 && ((v2426) < a--))
                continue;
            v2427 = false;
            if (v2428 >= v2430)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2431, ref v2429, out v2430);
            v2431[v2428] = (v2426);
            v2428++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2431, v2428);
    }

    int[] RangeSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b)
    {
        int v2432;
        int v2433;
        bool v2434;
        int v2435;
        int v2436;
        int v2437;
        int[] v2438;
        v2434 = true;
        v2435 = 0;
        v2436 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2436 -= (v2436 % 2);
        v2437 = 8;
        v2438 = new int[8];
        v2432 = (0);
        for (; v2432 < (100); v2432++)
        {
            v2433 = (v2432);
            if (v2434 && ((v2433) < a++ - b--))
                continue;
            v2434 = false;
            if (v2435 >= v2437)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2438, ref v2436, out v2437);
            v2438[v2435] = (v2433);
            v2435++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2438, v2435);
    }
}}