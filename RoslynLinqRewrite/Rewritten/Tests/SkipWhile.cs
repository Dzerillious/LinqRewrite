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
        int v1941;
        bool v1942;
        v1942 = true;
        v1941 = (0);
        for (; v1941 < (ArrayItems.Length); v1941 += 1)
        {
            if (v1942 && (((ArrayItems[v1941])) < 50))
                continue;
            v1942 = false;
            yield return ((ArrayItems[v1941]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileReverseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1943;
        bool v1944;
        v1944 = true;
        v1943 = (0);
        for (; v1943 < (ArrayItems.Length); v1943 += 1)
        {
            if (v1944 && (((ArrayItems[v1943])) > 50))
                continue;
            v1944 = false;
            yield return ((ArrayItems[v1943]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileTrueRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1945;
        bool v1946;
        v1946 = true;
        v1945 = (0);
        for (; v1945 < (ArrayItems.Length); v1945 += 1)
        {
            if (v1946 && (true))
                continue;
            v1946 = false;
            yield return ((ArrayItems[v1945]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1947;
        bool v1948;
        v1948 = true;
        v1947 = (0);
        for (; v1947 < (ArrayItems.Length); v1947 += 1)
        {
            if (v1948 && (false))
                continue;
            v1948 = false;
            yield return ((ArrayItems[v1947]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectSkipWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1949;
        int v1950;
        bool v1951;
        v1951 = true;
        v1949 = (0);
        for (; v1949 < (ArrayItems.Length); v1949 += 1)
        {
            v1950 = (20 + ArrayItems[v1949]);
            if (v1951 && ((v1950) < 50))
                continue;
            v1951 = false;
            yield return (v1950);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSkipWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1952;
        bool v1953;
        v1953 = true;
        v1952 = (0);
        for (; v1952 < (ArrayItems.Length); v1952 += 1)
        {
            if (!((((ArrayItems[v1952])) > 20)))
                continue;
            if (v1953 && ((((ArrayItems[v1952]))) < 50))
                continue;
            v1953 = false;
            yield return (((ArrayItems[v1952])));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1954;
        bool v1955;
        v1955 = true;
        v1954 = (0);
        for (; v1954 < (ArrayItems.Length); v1954 += 1)
        {
            if (v1955 && (((ArrayItems[v1954])) < a))
                continue;
            v1955 = false;
            yield return ((ArrayItems[v1954]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1957)
    {
        int v1956;
        bool v1958;
        v1958 = true;
        v1956 = (0);
        for (; v1956 < (ArrayItems.Length); v1956 += 1)
        {
            if (v1958 && v1957(((ArrayItems[v1956]))))
                continue;
            v1958 = false;
            yield return ((ArrayItems[v1956]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParam2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1960)
    {
        int v1959;
        bool v1961;
        v1961 = true;
        v1959 = (0);
        for (; v1959 < (ArrayItems.Length); v1959 += 1)
        {
            if (v1961 && v1960(((ArrayItems[v1959]))))
                continue;
            v1961 = false;
            yield return ((ArrayItems[v1959]));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParamsRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1963)
    {
        int v1962;
        bool v1964;
        v1964 = true;
        v1962 = (0);
        for (; v1962 < (ArrayItems.Length); v1962 += 1)
        {
            if (v1964 && v1963(((ArrayItems[v1962]))))
                continue;
            v1964 = false;
            yield return ((ArrayItems[v1962]));
        }

        yield break;
    }

    int[] ArraySkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1965;
        bool v1966;
        int v1967;
        int v1968;
        int v1969;
        int[] v1970;
        v1966 = true;
        v1967 = 0;
        v1968 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1968 -= (v1968 % 2);
        v1969 = 8;
        v1970 = new int[8];
        v1965 = (0);
        for (; v1965 < (ArrayItems.Length); v1965 += 1)
        {
            if (v1966 && (((ArrayItems[v1965])) < 50))
                continue;
            v1966 = false;
            if (v1967 >= v1969)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1970, ref v1968, out v1969);
            v1970[v1967] = ((ArrayItems[v1965]));
            v1967++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1970, v1967);
    }

    int[] ArraySkipWhileReverseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1971;
        bool v1972;
        int v1973;
        int v1974;
        int v1975;
        int[] v1976;
        v1972 = true;
        v1973 = 0;
        v1974 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1974 -= (v1974 % 2);
        v1975 = 8;
        v1976 = new int[8];
        v1971 = (0);
        for (; v1971 < (ArrayItems.Length); v1971 += 1)
        {
            if (v1972 && (((ArrayItems[v1971])) > 50))
                continue;
            v1972 = false;
            if (v1973 >= v1975)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1976, ref v1974, out v1975);
            v1976[v1973] = ((ArrayItems[v1971]));
            v1973++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1976, v1973);
    }

    int[] ArraySkipWhileTrueToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1977;
        bool v1978;
        int v1979;
        int v1980;
        int v1981;
        int[] v1982;
        v1978 = true;
        v1979 = 0;
        v1980 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1980 -= (v1980 % 2);
        v1981 = 8;
        v1982 = new int[8];
        v1977 = (0);
        for (; v1977 < (ArrayItems.Length); v1977 += 1)
        {
            if (v1978 && (true))
                continue;
            v1978 = false;
            if (v1979 >= v1981)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1982, ref v1980, out v1981);
            v1982[v1979] = ((ArrayItems[v1977]));
            v1979++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1982, v1979);
    }

    int[] ArraySkipWhileFalseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1983;
        bool v1984;
        int v1985;
        int v1986;
        int v1987;
        int[] v1988;
        v1984 = true;
        v1985 = 0;
        v1986 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1986 -= (v1986 % 2);
        v1987 = 8;
        v1988 = new int[8];
        v1983 = (0);
        for (; v1983 < (ArrayItems.Length); v1983 += 1)
        {
            if (v1984 && (false))
                continue;
            v1984 = false;
            if (v1985 >= v1987)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1988, ref v1986, out v1987);
            v1988[v1985] = ((ArrayItems[v1983]));
            v1985++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1988, v1985);
    }

    int[] ArraySelectSkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1989;
        int v1990;
        bool v1991;
        int v1992;
        int v1993;
        int v1994;
        int[] v1995;
        v1991 = true;
        v1992 = 0;
        v1993 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1993 -= (v1993 % 2);
        v1994 = 8;
        v1995 = new int[8];
        v1989 = (0);
        for (; v1989 < (ArrayItems.Length); v1989 += 1)
        {
            v1990 = (20 + ArrayItems[v1989]);
            if (v1991 && ((v1990) < 50))
                continue;
            v1991 = false;
            if (v1992 >= v1994)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v1995, ref v1993, out v1994);
            v1995[v1992] = (v1990);
            v1992++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1995, v1992);
    }

    int[] ArrayWhereSkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1996;
        bool v1997;
        int v1998;
        int v1999;
        int v2000;
        int[] v2001;
        v1997 = true;
        v1998 = 0;
        v1999 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v1999 -= (v1999 % 2);
        v2000 = 8;
        v2001 = new int[8];
        v1996 = (0);
        for (; v1996 < (ArrayItems.Length); v1996 += 1)
        {
            if (!((((ArrayItems[v1996])) > 20)))
                continue;
            if (v1997 && ((((ArrayItems[v1996]))) < 50))
                continue;
            v1997 = false;
            if (v1998 >= v2000)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2001, ref v1999, out v2000);
            v2001[v1998] = (((ArrayItems[v1996])));
            v1998++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2001, v1998);
    }

    int[] ArraySkipWhileParamToArrayRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v2002;
        bool v2003;
        int v2004;
        int v2005;
        int v2006;
        int[] v2007;
        v2003 = true;
        v2004 = 0;
        v2005 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2005 -= (v2005 % 2);
        v2006 = 8;
        v2007 = new int[8];
        v2002 = (0);
        for (; v2002 < (ArrayItems.Length); v2002 += 1)
        {
            if (v2003 && (((ArrayItems[v2002])) < a))
                continue;
            v2003 = false;
            if (v2004 >= v2006)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2007, ref v2005, out v2006);
            v2007[v2004] = ((ArrayItems[v2002]));
            v2004++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2007, v2004);
    }

    int[] ArraySkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2008;
        bool v2009;
        int v2010;
        int v2011;
        int v2012;
        int[] v2013;
        v2009 = true;
        v2010 = 0;
        v2011 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2011 -= (v2011 % 2);
        v2012 = 8;
        v2013 = new int[8];
        v2008 = (0);
        for (; v2008 < (ArrayItems.Length); v2008 += 1)
        {
            if (v2009 && (((ArrayItems[v2008])) < a++))
                continue;
            v2009 = false;
            if (v2010 >= v2012)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2013, ref v2011, out v2012);
            v2013[v2010] = ((ArrayItems[v2008]));
            v2010++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2013, v2010);
    }

    int[] ArraySkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v2014;
        bool v2015;
        int v2016;
        int v2017;
        int v2018;
        int[] v2019;
        v2015 = true;
        v2016 = 0;
        v2017 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2017 -= (v2017 % 2);
        v2018 = 8;
        v2019 = new int[8];
        v2014 = (0);
        for (; v2014 < (ArrayItems.Length); v2014 += 1)
        {
            if (v2015 && (((ArrayItems[v2014])) < a--))
                continue;
            v2015 = false;
            if (v2016 >= v2018)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2019, ref v2017, out v2018);
            v2019[v2016] = ((ArrayItems[v2014]));
            v2016++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2019, v2016);
    }

    int[] ArraySkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, int[] ArrayItems)
    {
        int v2020;
        bool v2021;
        int v2022;
        int v2023;
        int v2024;
        int[] v2025;
        v2021 = true;
        v2022 = 0;
        v2023 = (LinqRewrite.Core.IntExtensions.Log2((uint)((ArrayItems.Length))) - 3);
        v2023 -= (v2023 % 2);
        v2024 = 8;
        v2025 = new int[8];
        v2020 = (0);
        for (; v2020 < (ArrayItems.Length); v2020 += 1)
        {
            if (v2021 && (((ArrayItems[v2020])) < a++ - b--))
                continue;
            v2021 = false;
            if (v2022 >= v2024)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (ArrayItems.Length), ref v2025, ref v2023, out v2024);
            v2025[v2022] = ((ArrayItems[v2020]));
            v2022++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2025, v2022);
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2026;
        int v2027;
        bool v2028;
        v2026 = EnumerableItems.GetEnumerator();
        v2028 = true;
        try
        {
            while (v2026.MoveNext())
            {
                v2027 = (v2026.Current);
                if (v2028 && ((v2027) < 50))
                    continue;
                v2028 = false;
                yield return (v2027);
            }
        }
        finally
        {
            v2026.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileReverseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2029;
        int v2030;
        bool v2031;
        v2029 = EnumerableItems.GetEnumerator();
        v2031 = true;
        try
        {
            while (v2029.MoveNext())
            {
                v2030 = (v2029.Current);
                if (v2031 && ((v2030) > 50))
                    continue;
                v2031 = false;
                yield return (v2030);
            }
        }
        finally
        {
            v2029.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileTrueRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2032;
        int v2033;
        bool v2034;
        v2032 = EnumerableItems.GetEnumerator();
        v2034 = true;
        try
        {
            while (v2032.MoveNext())
            {
                v2033 = (v2032.Current);
                if (v2034 && (true))
                    continue;
                v2034 = false;
                yield return (v2033);
            }
        }
        finally
        {
            v2032.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileFalseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2035;
        int v2036;
        bool v2037;
        v2035 = EnumerableItems.GetEnumerator();
        v2037 = true;
        try
        {
            while (v2035.MoveNext())
            {
                v2036 = (v2035.Current);
                if (v2037 && (false))
                    continue;
                v2037 = false;
                yield return (v2036);
            }
        }
        finally
        {
            v2035.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSelectSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2038;
        int v2039;
        bool v2040;
        v2038 = EnumerableItems.GetEnumerator();
        v2040 = true;
        try
        {
            while (v2038.MoveNext())
            {
                v2039 = (20 + v2038.Current);
                if (v2040 && ((v2039) < 50))
                    continue;
                v2040 = false;
                yield return (v2039);
            }
        }
        finally
        {
            v2038.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2041;
        int v2042;
        bool v2043;
        v2041 = EnumerableItems.GetEnumerator();
        v2043 = true;
        try
        {
            while (v2041.MoveNext())
            {
                v2042 = (v2041.Current);
                if (!(((v2042) > 20)))
                    continue;
                if (v2043 && (((v2042)) < 50))
                    continue;
                v2043 = false;
                yield return ((v2042));
            }
        }
        finally
        {
            v2041.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2044;
        int v2045;
        bool v2046;
        v2044 = EnumerableItems.GetEnumerator();
        v2046 = true;
        try
        {
            while (v2044.MoveNext())
            {
                v2045 = (v2044.Current);
                if (v2046 && ((v2045) < a))
                    continue;
                v2046 = false;
                yield return (v2045);
            }
        }
        finally
        {
            v2044.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParamRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2049)
    {
        IEnumerator<int> v2047;
        int v2048;
        bool v2050;
        v2047 = EnumerableItems.GetEnumerator();
        v2050 = true;
        try
        {
            while (v2047.MoveNext())
            {
                v2048 = (v2047.Current);
                if (v2050 && v2049((v2048)))
                    continue;
                v2050 = false;
                yield return (v2048);
            }
        }
        finally
        {
            v2047.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParam2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2053)
    {
        IEnumerator<int> v2051;
        int v2052;
        bool v2054;
        v2051 = EnumerableItems.GetEnumerator();
        v2054 = true;
        try
        {
            while (v2051.MoveNext())
            {
                v2052 = (v2051.Current);
                if (v2054 && v2053((v2052)))
                    continue;
                v2054 = false;
                yield return (v2052);
            }
        }
        finally
        {
            v2051.Dispose();
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParamsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v2057)
    {
        IEnumerator<int> v2055;
        int v2056;
        bool v2058;
        v2055 = EnumerableItems.GetEnumerator();
        v2058 = true;
        try
        {
            while (v2055.MoveNext())
            {
                v2056 = (v2055.Current);
                if (v2058 && v2057((v2056)))
                    continue;
                v2058 = false;
                yield return (v2056);
            }
        }
        finally
        {
            v2055.Dispose();
        }

        yield break;
    }

    int[] EnumerableSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2059;
        int v2060;
        bool v2061;
        int v2062;
        int v2063;
        int[] v2064;
        v2059 = EnumerableItems.GetEnumerator();
        v2061 = true;
        v2062 = 0;
        v2063 = 8;
        v2064 = new int[8];
        try
        {
            while (v2059.MoveNext())
            {
                v2060 = (v2059.Current);
                if (v2061 && ((v2060) < 50))
                    continue;
                v2061 = false;
                if (v2062 >= v2063)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2064, ref v2063);
                v2064[v2062] = (v2060);
                v2062++;
            }
        }
        finally
        {
            v2059.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2064, v2062);
    }

    int[] EnumerableSkipWhileReverseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2065;
        int v2066;
        bool v2067;
        int v2068;
        int v2069;
        int[] v2070;
        v2065 = EnumerableItems.GetEnumerator();
        v2067 = true;
        v2068 = 0;
        v2069 = 8;
        v2070 = new int[8];
        try
        {
            while (v2065.MoveNext())
            {
                v2066 = (v2065.Current);
                if (v2067 && ((v2066) > 50))
                    continue;
                v2067 = false;
                if (v2068 >= v2069)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2070, ref v2069);
                v2070[v2068] = (v2066);
                v2068++;
            }
        }
        finally
        {
            v2065.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2070, v2068);
    }

    int[] EnumerableSkipWhileTrueToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2071;
        int v2072;
        bool v2073;
        int v2074;
        int v2075;
        int[] v2076;
        v2071 = EnumerableItems.GetEnumerator();
        v2073 = true;
        v2074 = 0;
        v2075 = 8;
        v2076 = new int[8];
        try
        {
            while (v2071.MoveNext())
            {
                v2072 = (v2071.Current);
                if (v2073 && (true))
                    continue;
                v2073 = false;
                if (v2074 >= v2075)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2076, ref v2075);
                v2076[v2074] = (v2072);
                v2074++;
            }
        }
        finally
        {
            v2071.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2076, v2074);
    }

    int[] EnumerableSkipWhileFalseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2077;
        int v2078;
        bool v2079;
        int v2080;
        int v2081;
        int[] v2082;
        v2077 = EnumerableItems.GetEnumerator();
        v2079 = true;
        v2080 = 0;
        v2081 = 8;
        v2082 = new int[8];
        try
        {
            while (v2077.MoveNext())
            {
                v2078 = (v2077.Current);
                if (v2079 && (false))
                    continue;
                v2079 = false;
                if (v2080 >= v2081)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2082, ref v2081);
                v2082[v2080] = (v2078);
                v2080++;
            }
        }
        finally
        {
            v2077.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2082, v2080);
    }

    int[] EnumerableSelectSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2083;
        int v2084;
        bool v2085;
        int v2086;
        int v2087;
        int[] v2088;
        v2083 = EnumerableItems.GetEnumerator();
        v2085 = true;
        v2086 = 0;
        v2087 = 8;
        v2088 = new int[8];
        try
        {
            while (v2083.MoveNext())
            {
                v2084 = (20 + v2083.Current);
                if (v2085 && ((v2084) < 50))
                    continue;
                v2085 = false;
                if (v2086 >= v2087)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2088, ref v2087);
                v2088[v2086] = (v2084);
                v2086++;
            }
        }
        finally
        {
            v2083.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2088, v2086);
    }

    int[] EnumerableWhereSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2089;
        int v2090;
        bool v2091;
        int v2092;
        int v2093;
        int[] v2094;
        v2089 = EnumerableItems.GetEnumerator();
        v2091 = true;
        v2092 = 0;
        v2093 = 8;
        v2094 = new int[8];
        try
        {
            while (v2089.MoveNext())
            {
                v2090 = (v2089.Current);
                if (!(((v2090) > 20)))
                    continue;
                if (v2091 && (((v2090)) < 50))
                    continue;
                v2091 = false;
                if (v2092 >= v2093)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2094, ref v2093);
                v2094[v2092] = ((v2090));
                v2092++;
            }
        }
        finally
        {
            v2089.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2094, v2092);
    }

    int[] EnumerableSkipWhileParamToArrayRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2095;
        int v2096;
        bool v2097;
        int v2098;
        int v2099;
        int[] v2100;
        v2095 = EnumerableItems.GetEnumerator();
        v2097 = true;
        v2098 = 0;
        v2099 = 8;
        v2100 = new int[8];
        try
        {
            while (v2095.MoveNext())
            {
                v2096 = (v2095.Current);
                if (v2097 && ((v2096) < a))
                    continue;
                v2097 = false;
                if (v2098 >= v2099)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2100, ref v2099);
                v2100[v2098] = (v2096);
                v2098++;
            }
        }
        finally
        {
            v2095.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2100, v2098);
    }

    int[] EnumerableSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2101;
        int v2102;
        bool v2103;
        int v2104;
        int v2105;
        int[] v2106;
        v2101 = EnumerableItems.GetEnumerator();
        v2103 = true;
        v2104 = 0;
        v2105 = 8;
        v2106 = new int[8];
        try
        {
            while (v2101.MoveNext())
            {
                v2102 = (v2101.Current);
                if (v2103 && ((v2102) < a++))
                    continue;
                v2103 = false;
                if (v2104 >= v2105)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2106, ref v2105);
                v2106[v2104] = (v2102);
                v2104++;
            }
        }
        finally
        {
            v2101.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2106, v2104);
    }

    int[] EnumerableSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2107;
        int v2108;
        bool v2109;
        int v2110;
        int v2111;
        int[] v2112;
        v2107 = EnumerableItems.GetEnumerator();
        v2109 = true;
        v2110 = 0;
        v2111 = 8;
        v2112 = new int[8];
        try
        {
            while (v2107.MoveNext())
            {
                v2108 = (v2107.Current);
                if (v2109 && ((v2108) < a--))
                    continue;
                v2109 = false;
                if (v2110 >= v2111)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2112, ref v2111);
                v2112[v2110] = (v2108);
                v2110++;
            }
        }
        finally
        {
            v2107.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2112, v2110);
    }

    int[] EnumerableSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v2113;
        int v2114;
        bool v2115;
        int v2116;
        int v2117;
        int[] v2118;
        v2113 = EnumerableItems.GetEnumerator();
        v2115 = true;
        v2116 = 0;
        v2117 = 8;
        v2118 = new int[8];
        try
        {
            while (v2113.MoveNext())
            {
                v2114 = (v2113.Current);
                if (v2115 && ((v2114) < a++ - b--))
                    continue;
                v2115 = false;
                if (v2116 >= v2117)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v2118, ref v2117);
                v2118[v2116] = (v2114);
                v2116++;
            }
        }
        finally
        {
            v2113.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2118, v2116);
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileRewritten_ProceduralLinq1()
    {
        int v2119;
        bool v2120;
        v2120 = true;
        v2119 = (0);
        for (; v2119 < (100); v2119 += (1))
        {
            if (v2120 && (((v2119)) < 50))
                continue;
            v2120 = false;
            yield return ((v2119));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileReverseRewritten_ProceduralLinq1()
    {
        int v2121;
        bool v2122;
        v2122 = true;
        v2121 = (0);
        for (; v2121 < (100); v2121 += (1))
        {
            if (v2122 && (((v2121)) > 50))
                continue;
            v2122 = false;
            yield return ((v2121));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileTrueRewritten_ProceduralLinq1()
    {
        int v2123;
        bool v2124;
        v2124 = true;
        v2123 = (0);
        for (; v2123 < (100); v2123 += (1))
        {
            if (v2124 && (true))
                continue;
            v2124 = false;
            yield return ((v2123));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileFalseRewritten_ProceduralLinq1()
    {
        int v2125;
        bool v2126;
        v2126 = true;
        v2125 = (0);
        for (; v2125 < (100); v2125 += (1))
        {
            if (v2126 && (false))
                continue;
            v2126 = false;
            yield return ((v2125));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSelectSkipWhileRewritten_ProceduralLinq1()
    {
        int v2127;
        int v2128;
        bool v2129;
        v2129 = true;
        v2127 = (0);
        for (; v2127 < (100); v2127 += (1))
        {
            v2128 = (20 + v2127);
            if (v2129 && ((v2128) < 50))
                continue;
            v2129 = false;
            yield return (v2128);
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereSkipWhileRewritten_ProceduralLinq1()
    {
        int v2130;
        bool v2131;
        v2131 = true;
        v2130 = (0);
        for (; v2130 < (100); v2130 += (1))
        {
            if (!((((v2130)) > 20)))
                continue;
            if (v2131 && ((((v2130))) < 50))
                continue;
            v2131 = false;
            yield return (((v2130)));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileParamRewritten_ProceduralLinq1(int a)
    {
        int v2132;
        bool v2133;
        v2133 = true;
        v2132 = (0);
        for (; v2132 < (100); v2132 += (1))
        {
            if (v2133 && (((v2132)) < a))
                continue;
            v2133 = false;
            yield return ((v2132));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParamRewritten_ProceduralLinq1(System.Func<int, bool> v2135)
    {
        int v2134;
        bool v2136;
        v2136 = true;
        v2134 = (0);
        for (; v2134 < (100); v2134 += (1))
        {
            if (v2136 && v2135(((v2134))))
                continue;
            v2136 = false;
            yield return ((v2134));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParam2Rewritten_ProceduralLinq1(System.Func<int, bool> v2138)
    {
        int v2137;
        bool v2139;
        v2139 = true;
        v2137 = (0);
        for (; v2137 < (100); v2137 += (1))
        {
            if (v2139 && v2138(((v2137))))
                continue;
            v2139 = false;
            yield return ((v2137));
        }

        yield break;
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParamsRewritten_ProceduralLinq1(System.Func<int, bool> v2141)
    {
        int v2140;
        bool v2142;
        v2142 = true;
        v2140 = (0);
        for (; v2140 < (100); v2140 += (1))
        {
            if (v2142 && v2141(((v2140))))
                continue;
            v2142 = false;
            yield return ((v2140));
        }

        yield break;
    }

    int[] RangeSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2143;
        bool v2144;
        int v2145;
        int v2146;
        int v2147;
        int[] v2148;
        v2144 = true;
        v2145 = 0;
        v2146 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2146 -= (v2146 % 2);
        v2147 = 8;
        v2148 = new int[8];
        v2143 = (0);
        for (; v2143 < (100); v2143 += (1))
        {
            if (v2144 && (((v2143)) < 50))
                continue;
            v2144 = false;
            if (v2145 >= v2147)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2148, ref v2146, out v2147);
            v2148[v2145] = ((v2143));
            v2145++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2148, v2145);
    }

    int[] RangeSkipWhileReverseToArrayRewritten_ProceduralLinq1()
    {
        int v2149;
        bool v2150;
        int v2151;
        int v2152;
        int v2153;
        int[] v2154;
        v2150 = true;
        v2151 = 0;
        v2152 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2152 -= (v2152 % 2);
        v2153 = 8;
        v2154 = new int[8];
        v2149 = (0);
        for (; v2149 < (100); v2149 += (1))
        {
            if (v2150 && (((v2149)) > 50))
                continue;
            v2150 = false;
            if (v2151 >= v2153)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2154, ref v2152, out v2153);
            v2154[v2151] = ((v2149));
            v2151++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2154, v2151);
    }

    int[] RangeSkipWhileTrueToArrayRewritten_ProceduralLinq1()
    {
        int v2155;
        bool v2156;
        int v2157;
        int v2158;
        int v2159;
        int[] v2160;
        v2156 = true;
        v2157 = 0;
        v2158 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2158 -= (v2158 % 2);
        v2159 = 8;
        v2160 = new int[8];
        v2155 = (0);
        for (; v2155 < (100); v2155 += (1))
        {
            if (v2156 && (true))
                continue;
            v2156 = false;
            if (v2157 >= v2159)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2160, ref v2158, out v2159);
            v2160[v2157] = ((v2155));
            v2157++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2160, v2157);
    }

    int[] RangeSkipWhileFalseToArrayRewritten_ProceduralLinq1()
    {
        int v2161;
        bool v2162;
        int v2163;
        int v2164;
        int v2165;
        int[] v2166;
        v2162 = true;
        v2163 = 0;
        v2164 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2164 -= (v2164 % 2);
        v2165 = 8;
        v2166 = new int[8];
        v2161 = (0);
        for (; v2161 < (100); v2161 += (1))
        {
            if (v2162 && (false))
                continue;
            v2162 = false;
            if (v2163 >= v2165)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2166, ref v2164, out v2165);
            v2166[v2163] = ((v2161));
            v2163++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2166, v2163);
    }

    int[] RangeSelectSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2167;
        int v2168;
        bool v2169;
        int v2170;
        int v2171;
        int v2172;
        int[] v2173;
        v2169 = true;
        v2170 = 0;
        v2171 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2171 -= (v2171 % 2);
        v2172 = 8;
        v2173 = new int[8];
        v2167 = (0);
        for (; v2167 < (100); v2167 += (1))
        {
            v2168 = (20 + v2167);
            if (v2169 && ((v2168) < 50))
                continue;
            v2169 = false;
            if (v2170 >= v2172)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2173, ref v2171, out v2172);
            v2173[v2170] = (v2168);
            v2170++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2173, v2170);
    }

    int[] RangeWhereSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v2174;
        bool v2175;
        int v2176;
        int v2177;
        int v2178;
        int[] v2179;
        v2175 = true;
        v2176 = 0;
        v2177 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2177 -= (v2177 % 2);
        v2178 = 8;
        v2179 = new int[8];
        v2174 = (0);
        for (; v2174 < (100); v2174 += (1))
        {
            if (!((((v2174)) > 20)))
                continue;
            if (v2175 && ((((v2174))) < 50))
                continue;
            v2175 = false;
            if (v2176 >= v2178)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2179, ref v2177, out v2178);
            v2179[v2176] = (((v2174)));
            v2176++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2179, v2176);
    }

    int[] RangeSkipWhileParamToArrayRewritten_ProceduralLinq1(int a)
    {
        int v2180;
        bool v2181;
        int v2182;
        int v2183;
        int v2184;
        int[] v2185;
        v2181 = true;
        v2182 = 0;
        v2183 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2183 -= (v2183 % 2);
        v2184 = 8;
        v2185 = new int[8];
        v2180 = (0);
        for (; v2180 < (100); v2180 += (1))
        {
            if (v2181 && (((v2180)) < a))
                continue;
            v2181 = false;
            if (v2182 >= v2184)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2185, ref v2183, out v2184);
            v2185[v2182] = ((v2180));
            v2182++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2185, v2182);
    }

    int[] RangeSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a)
    {
        int v2186;
        bool v2187;
        int v2188;
        int v2189;
        int v2190;
        int[] v2191;
        v2187 = true;
        v2188 = 0;
        v2189 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2189 -= (v2189 % 2);
        v2190 = 8;
        v2191 = new int[8];
        v2186 = (0);
        for (; v2186 < (100); v2186 += (1))
        {
            if (v2187 && (((v2186)) < a++))
                continue;
            v2187 = false;
            if (v2188 >= v2190)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2191, ref v2189, out v2190);
            v2191[v2188] = ((v2186));
            v2188++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2191, v2188);
    }

    int[] RangeSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a)
    {
        int v2192;
        bool v2193;
        int v2194;
        int v2195;
        int v2196;
        int[] v2197;
        v2193 = true;
        v2194 = 0;
        v2195 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2195 -= (v2195 % 2);
        v2196 = 8;
        v2197 = new int[8];
        v2192 = (0);
        for (; v2192 < (100); v2192 += (1))
        {
            if (v2193 && (((v2192)) < a--))
                continue;
            v2193 = false;
            if (v2194 >= v2196)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2197, ref v2195, out v2196);
            v2197[v2194] = ((v2192));
            v2194++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2197, v2194);
    }

    int[] RangeSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b)
    {
        int v2198;
        bool v2199;
        int v2200;
        int v2201;
        int v2202;
        int[] v2203;
        v2199 = true;
        v2200 = 0;
        v2201 = (LinqRewrite.Core.IntExtensions.Log2((uint)((100))) - 3);
        v2201 -= (v2201 % 2);
        v2202 = 8;
        v2203 = new int[8];
        v2198 = (0);
        for (; v2198 < (100); v2198 += (1))
        {
            if (v2199 && (((v2198)) < a++ - b--))
                continue;
            v2199 = false;
            if (v2200 >= v2202)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, (100), ref v2203, ref v2201, out v2202);
            v2203[v2200] = ((v2198));
            v2200++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2203, v2200);
    }
}}