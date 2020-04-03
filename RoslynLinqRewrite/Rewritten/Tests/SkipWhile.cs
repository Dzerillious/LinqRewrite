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
        int v1741;
        bool v1742;
        v1742 = true;
        v1741 = 0;
        for (; v1741 < ArrayItems.Length; v1741++)
        {
            if (v1742 && (ArrayItems[v1741] < 50))
                continue;
            v1742 = false;
            yield return ArrayItems[v1741];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileReverseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1743;
        bool v1744;
        v1744 = true;
        v1743 = 0;
        for (; v1743 < ArrayItems.Length; v1743++)
        {
            if (v1744 && (ArrayItems[v1743] > 50))
                continue;
            v1744 = false;
            yield return ArrayItems[v1743];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileTrueRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1745;
        bool v1746;
        v1746 = true;
        v1745 = 0;
        for (; v1745 < ArrayItems.Length; v1745++)
        {
            if (v1746 && (true))
                continue;
            v1746 = false;
            yield return ArrayItems[v1745];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileFalseRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1747;
        bool v1748;
        v1748 = true;
        v1747 = 0;
        for (; v1747 < ArrayItems.Length; v1747++)
        {
            if (v1748 && (false))
                continue;
            v1748 = false;
            yield return ArrayItems[v1747];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectSkipWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1749;
        int v1750;
        bool v1751;
        v1751 = true;
        v1749 = 0;
        for (; v1749 < ArrayItems.Length; v1749++)
        {
            v1750 = (ArrayItems[v1749] + 20);
            if (v1751 && (v1750 < 50))
                continue;
            v1751 = false;
            yield return v1750;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSkipWhileRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1752;
        bool v1753;
        v1753 = true;
        v1752 = 0;
        for (; v1752 < ArrayItems.Length; v1752++)
        {
            if (!((ArrayItems[v1752] > 20)))
                continue;
            if (v1753 && (ArrayItems[v1752] < 50))
                continue;
            v1753 = false;
            yield return ArrayItems[v1752];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1754;
        bool v1755;
        v1755 = true;
        v1754 = 0;
        for (; v1754 < ArrayItems.Length; v1754++)
        {
            if (v1755 && (ArrayItems[v1754] < a))
                continue;
            v1755 = false;
            yield return ArrayItems[v1754];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParamRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1757)
    {
        int v1756;
        bool v1758;
        v1758 = true;
        v1756 = 0;
        for (; v1756 < ArrayItems.Length; v1756++)
        {
            if (v1758 && v1757(ArrayItems[v1756]))
                continue;
            v1758 = false;
            yield return ArrayItems[v1756];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParam2Rewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1760)
    {
        int v1759;
        bool v1761;
        v1761 = true;
        v1759 = 0;
        for (; v1759 < ArrayItems.Length; v1759++)
        {
            if (v1761 && v1760(ArrayItems[v1759]))
                continue;
            v1761 = false;
            yield return ArrayItems[v1759];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipWhileChangingParamsRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v1763)
    {
        int v1762;
        bool v1764;
        v1764 = true;
        v1762 = 0;
        for (; v1762 < ArrayItems.Length; v1762++)
        {
            if (v1764 && v1763(ArrayItems[v1762]))
                continue;
            v1764 = false;
            yield return ArrayItems[v1762];
        }
    }

    int[] ArraySkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1765;
        bool v1766;
        int v1767;
        int v1768;
        int v1769;
        int[] v1770;
        v1766 = true;
        v1767 = 0;
        v1768 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1768 -= (v1768 % 2);
        v1769 = 8;
        v1770 = new int[8];
        v1765 = 0;
        for (; v1765 < ArrayItems.Length; v1765++)
        {
            if (v1766 && (ArrayItems[v1765] < 50))
                continue;
            v1766 = false;
            if (v1767 >= v1769)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1770, ref v1768, out v1769);
            v1770[v1767] = ArrayItems[v1765];
            v1767++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1770, v1767);
    }

    int[] ArraySkipWhileReverseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1771;
        bool v1772;
        int v1773;
        int v1774;
        int v1775;
        int[] v1776;
        v1772 = true;
        v1773 = 0;
        v1774 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1774 -= (v1774 % 2);
        v1775 = 8;
        v1776 = new int[8];
        v1771 = 0;
        for (; v1771 < ArrayItems.Length; v1771++)
        {
            if (v1772 && (ArrayItems[v1771] > 50))
                continue;
            v1772 = false;
            if (v1773 >= v1775)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1776, ref v1774, out v1775);
            v1776[v1773] = ArrayItems[v1771];
            v1773++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1776, v1773);
    }

    int[] ArraySkipWhileTrueToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1777;
        bool v1778;
        int v1779;
        int v1780;
        int v1781;
        int[] v1782;
        v1778 = true;
        v1779 = 0;
        v1780 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1780 -= (v1780 % 2);
        v1781 = 8;
        v1782 = new int[8];
        v1777 = 0;
        for (; v1777 < ArrayItems.Length; v1777++)
        {
            if (v1778 && (true))
                continue;
            v1778 = false;
            if (v1779 >= v1781)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1782, ref v1780, out v1781);
            v1782[v1779] = ArrayItems[v1777];
            v1779++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1782, v1779);
    }

    int[] ArraySkipWhileFalseToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1783;
        bool v1784;
        int v1785;
        int v1786;
        int v1787;
        int[] v1788;
        v1784 = true;
        v1785 = 0;
        v1786 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1786 -= (v1786 % 2);
        v1787 = 8;
        v1788 = new int[8];
        v1783 = 0;
        for (; v1783 < ArrayItems.Length; v1783++)
        {
            if (v1784 && (false))
                continue;
            v1784 = false;
            if (v1785 >= v1787)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1788, ref v1786, out v1787);
            v1788[v1785] = ArrayItems[v1783];
            v1785++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1788, v1785);
    }

    int[] ArraySelectSkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1789;
        int v1790;
        bool v1791;
        int v1792;
        int v1793;
        int v1794;
        int[] v1795;
        v1791 = true;
        v1792 = 0;
        v1793 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1793 -= (v1793 % 2);
        v1794 = 8;
        v1795 = new int[8];
        v1789 = 0;
        for (; v1789 < ArrayItems.Length; v1789++)
        {
            v1790 = (ArrayItems[v1789] + 20);
            if (v1791 && (v1790 < 50))
                continue;
            v1791 = false;
            if (v1792 >= v1794)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1795, ref v1793, out v1794);
            v1795[v1792] = v1790;
            v1792++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1795, v1792);
    }

    int[] ArrayWhereSkipWhileToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1796;
        bool v1797;
        int v1798;
        int v1799;
        int v1800;
        int[] v1801;
        v1797 = true;
        v1798 = 0;
        v1799 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1799 -= (v1799 % 2);
        v1800 = 8;
        v1801 = new int[8];
        v1796 = 0;
        for (; v1796 < ArrayItems.Length; v1796++)
        {
            if (!((ArrayItems[v1796] > 20)))
                continue;
            if (v1797 && (ArrayItems[v1796] < 50))
                continue;
            v1797 = false;
            if (v1798 >= v1800)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1801, ref v1799, out v1800);
            v1801[v1798] = ArrayItems[v1796];
            v1798++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1801, v1798);
    }

    int[] ArraySkipWhileParamToArrayRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1802;
        bool v1803;
        int v1804;
        int v1805;
        int v1806;
        int[] v1807;
        v1803 = true;
        v1804 = 0;
        v1805 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1805 -= (v1805 % 2);
        v1806 = 8;
        v1807 = new int[8];
        v1802 = 0;
        for (; v1802 < ArrayItems.Length; v1802++)
        {
            if (v1803 && (ArrayItems[v1802] < a))
                continue;
            v1803 = false;
            if (v1804 >= v1806)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1807, ref v1805, out v1806);
            v1807[v1804] = ArrayItems[v1802];
            v1804++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1807, v1804);
    }

    int[] ArraySkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1808;
        bool v1809;
        int v1810;
        int v1811;
        int v1812;
        int[] v1813;
        v1809 = true;
        v1810 = 0;
        v1811 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1811 -= (v1811 % 2);
        v1812 = 8;
        v1813 = new int[8];
        v1808 = 0;
        for (; v1808 < ArrayItems.Length; v1808++)
        {
            if (v1809 && (ArrayItems[v1808] < a++))
                continue;
            v1809 = false;
            if (v1810 >= v1812)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1813, ref v1811, out v1812);
            v1813[v1810] = ArrayItems[v1808];
            v1810++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1813, v1810);
    }

    int[] ArraySkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, int[] ArrayItems)
    {
        int v1814;
        bool v1815;
        int v1816;
        int v1817;
        int v1818;
        int[] v1819;
        v1815 = true;
        v1816 = 0;
        v1817 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1817 -= (v1817 % 2);
        v1818 = 8;
        v1819 = new int[8];
        v1814 = 0;
        for (; v1814 < ArrayItems.Length; v1814++)
        {
            if (v1815 && (ArrayItems[v1814] < a--))
                continue;
            v1815 = false;
            if (v1816 >= v1818)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1819, ref v1817, out v1818);
            v1819[v1816] = ArrayItems[v1814];
            v1816++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1819, v1816);
    }

    int[] ArraySkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, int[] ArrayItems)
    {
        int v1820;
        bool v1821;
        int v1822;
        int v1823;
        int v1824;
        int[] v1825;
        v1821 = true;
        v1822 = 0;
        v1823 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1823 -= (v1823 % 2);
        v1824 = 8;
        v1825 = new int[8];
        v1820 = 0;
        for (; v1820 < ArrayItems.Length; v1820++)
        {
            if (v1821 && (ArrayItems[v1820] < a++ - b--))
                continue;
            v1821 = false;
            if (v1822 >= v1824)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1825, ref v1823, out v1824);
            v1825[v1822] = ArrayItems[v1820];
            v1822++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1825, v1822);
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1826;
        int v1827;
        bool v1828;
        v1826 = EnumerableItems.GetEnumerator();
        v1828 = true;
        try
        {
            while (v1826.MoveNext())
            {
                v1827 = v1826.Current;
                if (v1828 && (v1827 < 50))
                    continue;
                v1828 = false;
                yield return v1827;
            }
        }
        finally
        {
            v1826.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileReverseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1829;
        int v1830;
        bool v1831;
        v1829 = EnumerableItems.GetEnumerator();
        v1831 = true;
        try
        {
            while (v1829.MoveNext())
            {
                v1830 = v1829.Current;
                if (v1831 && (v1830 > 50))
                    continue;
                v1831 = false;
                yield return v1830;
            }
        }
        finally
        {
            v1829.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileTrueRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1832;
        int v1833;
        bool v1834;
        v1832 = EnumerableItems.GetEnumerator();
        v1834 = true;
        try
        {
            while (v1832.MoveNext())
            {
                v1833 = v1832.Current;
                if (v1834 && (true))
                    continue;
                v1834 = false;
                yield return v1833;
            }
        }
        finally
        {
            v1832.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileFalseRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1835;
        int v1836;
        bool v1837;
        v1835 = EnumerableItems.GetEnumerator();
        v1837 = true;
        try
        {
            while (v1835.MoveNext())
            {
                v1836 = v1835.Current;
                if (v1837 && (false))
                    continue;
                v1837 = false;
                yield return v1836;
            }
        }
        finally
        {
            v1835.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSelectSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1838;
        int v1839;
        bool v1840;
        v1838 = EnumerableItems.GetEnumerator();
        v1840 = true;
        try
        {
            while (v1838.MoveNext())
            {
                v1839 = (v1838.Current + 20);
                if (v1840 && (v1839 < 50))
                    continue;
                v1840 = false;
                yield return v1839;
            }
        }
        finally
        {
            v1838.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableWhereSkipWhileRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1841;
        int v1842;
        bool v1843;
        v1841 = EnumerableItems.GetEnumerator();
        v1843 = true;
        try
        {
            while (v1841.MoveNext())
            {
                v1842 = v1841.Current;
                if (!((v1842 > 20)))
                    continue;
                if (v1843 && (v1842 < 50))
                    continue;
                v1843 = false;
                yield return v1842;
            }
        }
        finally
        {
            v1841.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1844;
        int v1845;
        bool v1846;
        v1844 = EnumerableItems.GetEnumerator();
        v1846 = true;
        try
        {
            while (v1844.MoveNext())
            {
                v1845 = v1844.Current;
                if (v1846 && (v1845 < a))
                    continue;
                v1846 = false;
                yield return v1845;
            }
        }
        finally
        {
            v1844.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParamRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v1849)
    {
        IEnumerator<int> v1847;
        int v1848;
        bool v1850;
        v1847 = EnumerableItems.GetEnumerator();
        v1850 = true;
        try
        {
            while (v1847.MoveNext())
            {
                v1848 = v1847.Current;
                if (v1850 && v1849(v1848))
                    continue;
                v1850 = false;
                yield return v1848;
            }
        }
        finally
        {
            v1847.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParam2Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v1853)
    {
        IEnumerator<int> v1851;
        int v1852;
        bool v1854;
        v1851 = EnumerableItems.GetEnumerator();
        v1854 = true;
        try
        {
            while (v1851.MoveNext())
            {
                v1852 = v1851.Current;
                if (v1854 && v1853(v1852))
                    continue;
                v1854 = false;
                yield return v1852;
            }
        }
        finally
        {
            v1851.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipWhileChangingParamsRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems, System.Func<int, bool> v1857)
    {
        IEnumerator<int> v1855;
        int v1856;
        bool v1858;
        v1855 = EnumerableItems.GetEnumerator();
        v1858 = true;
        try
        {
            while (v1855.MoveNext())
            {
                v1856 = v1855.Current;
                if (v1858 && v1857(v1856))
                    continue;
                v1858 = false;
                yield return v1856;
            }
        }
        finally
        {
            v1855.Dispose();
        }
    }

    int[] EnumerableSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1859;
        int v1860;
        bool v1861;
        int v1862;
        int v1863;
        int[] v1864;
        v1859 = EnumerableItems.GetEnumerator();
        v1861 = true;
        v1862 = 0;
        v1863 = 8;
        v1864 = new int[8];
        try
        {
            while (v1859.MoveNext())
            {
                v1860 = v1859.Current;
                if (v1861 && (v1860 < 50))
                    continue;
                v1861 = false;
                if (v1862 >= v1863)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1864, ref v1863);
                v1864[v1862] = v1860;
                v1862++;
            }
        }
        finally
        {
            v1859.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1864, v1862);
    }

    int[] EnumerableSkipWhileReverseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1865;
        int v1866;
        bool v1867;
        int v1868;
        int v1869;
        int[] v1870;
        v1865 = EnumerableItems.GetEnumerator();
        v1867 = true;
        v1868 = 0;
        v1869 = 8;
        v1870 = new int[8];
        try
        {
            while (v1865.MoveNext())
            {
                v1866 = v1865.Current;
                if (v1867 && (v1866 > 50))
                    continue;
                v1867 = false;
                if (v1868 >= v1869)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1870, ref v1869);
                v1870[v1868] = v1866;
                v1868++;
            }
        }
        finally
        {
            v1865.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1870, v1868);
    }

    int[] EnumerableSkipWhileTrueToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1871;
        int v1872;
        bool v1873;
        int v1874;
        int v1875;
        int[] v1876;
        v1871 = EnumerableItems.GetEnumerator();
        v1873 = true;
        v1874 = 0;
        v1875 = 8;
        v1876 = new int[8];
        try
        {
            while (v1871.MoveNext())
            {
                v1872 = v1871.Current;
                if (v1873 && (true))
                    continue;
                v1873 = false;
                if (v1874 >= v1875)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1876, ref v1875);
                v1876[v1874] = v1872;
                v1874++;
            }
        }
        finally
        {
            v1871.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1876, v1874);
    }

    int[] EnumerableSkipWhileFalseToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1877;
        int v1878;
        bool v1879;
        int v1880;
        int v1881;
        int[] v1882;
        v1877 = EnumerableItems.GetEnumerator();
        v1879 = true;
        v1880 = 0;
        v1881 = 8;
        v1882 = new int[8];
        try
        {
            while (v1877.MoveNext())
            {
                v1878 = v1877.Current;
                if (v1879 && (false))
                    continue;
                v1879 = false;
                if (v1880 >= v1881)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1882, ref v1881);
                v1882[v1880] = v1878;
                v1880++;
            }
        }
        finally
        {
            v1877.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1882, v1880);
    }

    int[] EnumerableSelectSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1883;
        int v1884;
        bool v1885;
        int v1886;
        int v1887;
        int[] v1888;
        v1883 = EnumerableItems.GetEnumerator();
        v1885 = true;
        v1886 = 0;
        v1887 = 8;
        v1888 = new int[8];
        try
        {
            while (v1883.MoveNext())
            {
                v1884 = (v1883.Current + 20);
                if (v1885 && (v1884 < 50))
                    continue;
                v1885 = false;
                if (v1886 >= v1887)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1888, ref v1887);
                v1888[v1886] = v1884;
                v1886++;
            }
        }
        finally
        {
            v1883.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1888, v1886);
    }

    int[] EnumerableWhereSkipWhileToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1889;
        int v1890;
        bool v1891;
        int v1892;
        int v1893;
        int[] v1894;
        v1889 = EnumerableItems.GetEnumerator();
        v1891 = true;
        v1892 = 0;
        v1893 = 8;
        v1894 = new int[8];
        try
        {
            while (v1889.MoveNext())
            {
                v1890 = v1889.Current;
                if (!((v1890 > 20)))
                    continue;
                if (v1891 && (v1890 < 50))
                    continue;
                v1891 = false;
                if (v1892 >= v1893)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1894, ref v1893);
                v1894[v1892] = v1890;
                v1892++;
            }
        }
        finally
        {
            v1889.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1894, v1892);
    }

    int[] EnumerableSkipWhileParamToArrayRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1895;
        int v1896;
        bool v1897;
        int v1898;
        int v1899;
        int[] v1900;
        v1895 = EnumerableItems.GetEnumerator();
        v1897 = true;
        v1898 = 0;
        v1899 = 8;
        v1900 = new int[8];
        try
        {
            while (v1895.MoveNext())
            {
                v1896 = v1895.Current;
                if (v1897 && (v1896 < a))
                    continue;
                v1897 = false;
                if (v1898 >= v1899)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1900, ref v1899);
                v1900[v1898] = v1896;
                v1898++;
            }
        }
        finally
        {
            v1895.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1900, v1898);
    }

    int[] EnumerableSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1901;
        int v1902;
        bool v1903;
        int v1904;
        int v1905;
        int[] v1906;
        v1901 = EnumerableItems.GetEnumerator();
        v1903 = true;
        v1904 = 0;
        v1905 = 8;
        v1906 = new int[8];
        try
        {
            while (v1901.MoveNext())
            {
                v1902 = v1901.Current;
                if (v1903 && (v1902 < a++))
                    continue;
                v1903 = false;
                if (v1904 >= v1905)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1906, ref v1905);
                v1906[v1904] = v1902;
                v1904++;
            }
        }
        finally
        {
            v1901.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1906, v1904);
    }

    int[] EnumerableSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1907;
        int v1908;
        bool v1909;
        int v1910;
        int v1911;
        int[] v1912;
        v1907 = EnumerableItems.GetEnumerator();
        v1909 = true;
        v1910 = 0;
        v1911 = 8;
        v1912 = new int[8];
        try
        {
            while (v1907.MoveNext())
            {
                v1908 = v1907.Current;
                if (v1909 && (v1908 < a--))
                    continue;
                v1909 = false;
                if (v1910 >= v1911)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1912, ref v1911);
                v1912[v1910] = v1908;
                v1910++;
            }
        }
        finally
        {
            v1907.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1912, v1910);
    }

    int[] EnumerableSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1913;
        int v1914;
        bool v1915;
        int v1916;
        int v1917;
        int[] v1918;
        v1913 = EnumerableItems.GetEnumerator();
        v1915 = true;
        v1916 = 0;
        v1917 = 8;
        v1918 = new int[8];
        try
        {
            while (v1913.MoveNext())
            {
                v1914 = v1913.Current;
                if (v1915 && (v1914 < a++ - b--))
                    continue;
                v1915 = false;
                if (v1916 >= v1917)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1918, ref v1917);
                v1918[v1916] = v1914;
                v1916++;
            }
        }
        finally
        {
            v1913.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1918, v1916);
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileRewritten_ProceduralLinq1()
    {
        int v1919;
        int v1920;
        bool v1921;
        v1921 = true;
        v1919 = 0;
        for (; v1919 < 100; v1919++)
        {
            v1920 = (v1919 + 0);
            if (v1921 && (v1920 < 50))
                continue;
            v1921 = false;
            yield return v1920;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileReverseRewritten_ProceduralLinq1()
    {
        int v1922;
        int v1923;
        bool v1924;
        v1924 = true;
        v1922 = 0;
        for (; v1922 < 100; v1922++)
        {
            v1923 = (v1922 + 0);
            if (v1924 && (v1923 > 50))
                continue;
            v1924 = false;
            yield return v1923;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileTrueRewritten_ProceduralLinq1()
    {
        int v1925;
        int v1926;
        bool v1927;
        v1927 = true;
        v1925 = 0;
        for (; v1925 < 100; v1925++)
        {
            v1926 = (v1925 + 0);
            if (v1927 && (true))
                continue;
            v1927 = false;
            yield return v1926;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileFalseRewritten_ProceduralLinq1()
    {
        int v1928;
        int v1929;
        bool v1930;
        v1930 = true;
        v1928 = 0;
        for (; v1928 < 100; v1928++)
        {
            v1929 = (v1928 + 0);
            if (v1930 && (false))
                continue;
            v1930 = false;
            yield return v1929;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSelectSkipWhileRewritten_ProceduralLinq1()
    {
        int v1931;
        int v1932;
        bool v1933;
        v1933 = true;
        v1931 = 0;
        for (; v1931 < 100; v1931++)
        {
            v1932 = ((v1931 + 0) + 20);
            if (v1933 && (v1932 < 50))
                continue;
            v1933 = false;
            yield return v1932;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeWhereSkipWhileRewritten_ProceduralLinq1()
    {
        int v1934;
        int v1935;
        bool v1936;
        v1936 = true;
        v1934 = 0;
        for (; v1934 < 100; v1934++)
        {
            v1935 = (v1934 + 0);
            if (!((v1935 > 20)))
                continue;
            if (v1936 && (v1935 < 50))
                continue;
            v1936 = false;
            yield return v1935;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileParamRewritten_ProceduralLinq1(int a)
    {
        int v1937;
        int v1938;
        bool v1939;
        v1939 = true;
        v1937 = 0;
        for (; v1937 < 100; v1937++)
        {
            v1938 = (v1937 + 0);
            if (v1939 && (v1938 < a))
                continue;
            v1939 = false;
            yield return v1938;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParamRewritten_ProceduralLinq1(System.Func<int, bool> v1942)
    {
        int v1940;
        int v1941;
        bool v1943;
        v1943 = true;
        v1940 = 0;
        for (; v1940 < 100; v1940++)
        {
            v1941 = (v1940 + 0);
            if (v1943 && v1942(v1941))
                continue;
            v1943 = false;
            yield return v1941;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParam2Rewritten_ProceduralLinq1(System.Func<int, bool> v1946)
    {
        int v1944;
        int v1945;
        bool v1947;
        v1947 = true;
        v1944 = 0;
        for (; v1944 < 100; v1944++)
        {
            v1945 = (v1944 + 0);
            if (v1947 && v1946(v1945))
                continue;
            v1947 = false;
            yield return v1945;
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipWhileChangingParamsRewritten_ProceduralLinq1(System.Func<int, bool> v1950)
    {
        int v1948;
        int v1949;
        bool v1951;
        v1951 = true;
        v1948 = 0;
        for (; v1948 < 100; v1948++)
        {
            v1949 = (v1948 + 0);
            if (v1951 && v1950(v1949))
                continue;
            v1951 = false;
            yield return v1949;
        }
    }

    int[] RangeSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v1952;
        int v1953;
        bool v1954;
        int v1955;
        int v1956;
        int v1957;
        int[] v1958;
        v1954 = true;
        v1955 = 0;
        v1956 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v1956 -= (v1956 % 2);
        v1957 = 8;
        v1958 = new int[8];
        v1952 = 0;
        for (; v1952 < 100; v1952++)
        {
            v1953 = (v1952 + 0);
            if (v1954 && (v1953 < 50))
                continue;
            v1954 = false;
            if (v1955 >= v1957)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v1958, ref v1956, out v1957);
            v1958[v1955] = v1953;
            v1955++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1958, v1955);
    }

    int[] RangeSkipWhileReverseToArrayRewritten_ProceduralLinq1()
    {
        int v1959;
        int v1960;
        bool v1961;
        int v1962;
        int v1963;
        int v1964;
        int[] v1965;
        v1961 = true;
        v1962 = 0;
        v1963 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v1963 -= (v1963 % 2);
        v1964 = 8;
        v1965 = new int[8];
        v1959 = 0;
        for (; v1959 < 100; v1959++)
        {
            v1960 = (v1959 + 0);
            if (v1961 && (v1960 > 50))
                continue;
            v1961 = false;
            if (v1962 >= v1964)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v1965, ref v1963, out v1964);
            v1965[v1962] = v1960;
            v1962++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1965, v1962);
    }

    int[] RangeSkipWhileTrueToArrayRewritten_ProceduralLinq1()
    {
        int v1966;
        int v1967;
        bool v1968;
        int v1969;
        int v1970;
        int v1971;
        int[] v1972;
        v1968 = true;
        v1969 = 0;
        v1970 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v1970 -= (v1970 % 2);
        v1971 = 8;
        v1972 = new int[8];
        v1966 = 0;
        for (; v1966 < 100; v1966++)
        {
            v1967 = (v1966 + 0);
            if (v1968 && (true))
                continue;
            v1968 = false;
            if (v1969 >= v1971)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v1972, ref v1970, out v1971);
            v1972[v1969] = v1967;
            v1969++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1972, v1969);
    }

    int[] RangeSkipWhileFalseToArrayRewritten_ProceduralLinq1()
    {
        int v1973;
        int v1974;
        bool v1975;
        int v1976;
        int v1977;
        int v1978;
        int[] v1979;
        v1975 = true;
        v1976 = 0;
        v1977 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v1977 -= (v1977 % 2);
        v1978 = 8;
        v1979 = new int[8];
        v1973 = 0;
        for (; v1973 < 100; v1973++)
        {
            v1974 = (v1973 + 0);
            if (v1975 && (false))
                continue;
            v1975 = false;
            if (v1976 >= v1978)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v1979, ref v1977, out v1978);
            v1979[v1976] = v1974;
            v1976++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1979, v1976);
    }

    int[] RangeSelectSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v1980;
        int v1981;
        bool v1982;
        int v1983;
        int v1984;
        int v1985;
        int[] v1986;
        v1982 = true;
        v1983 = 0;
        v1984 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v1984 -= (v1984 % 2);
        v1985 = 8;
        v1986 = new int[8];
        v1980 = 0;
        for (; v1980 < 100; v1980++)
        {
            v1981 = ((v1980 + 0) + 20);
            if (v1982 && (v1981 < 50))
                continue;
            v1982 = false;
            if (v1983 >= v1985)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v1986, ref v1984, out v1985);
            v1986[v1983] = v1981;
            v1983++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1986, v1983);
    }

    int[] RangeWhereSkipWhileToArrayRewritten_ProceduralLinq1()
    {
        int v1987;
        int v1988;
        bool v1989;
        int v1990;
        int v1991;
        int v1992;
        int[] v1993;
        v1989 = true;
        v1990 = 0;
        v1991 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v1991 -= (v1991 % 2);
        v1992 = 8;
        v1993 = new int[8];
        v1987 = 0;
        for (; v1987 < 100; v1987++)
        {
            v1988 = (v1987 + 0);
            if (!((v1988 > 20)))
                continue;
            if (v1989 && (v1988 < 50))
                continue;
            v1989 = false;
            if (v1990 >= v1992)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v1993, ref v1991, out v1992);
            v1993[v1990] = v1988;
            v1990++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1993, v1990);
    }

    int[] RangeSkipWhileParamToArrayRewritten_ProceduralLinq1(int a)
    {
        int v1994;
        int v1995;
        bool v1996;
        int v1997;
        int v1998;
        int v1999;
        int[] v2000;
        v1996 = true;
        v1997 = 0;
        v1998 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v1998 -= (v1998 % 2);
        v1999 = 8;
        v2000 = new int[8];
        v1994 = 0;
        for (; v1994 < 100; v1994++)
        {
            v1995 = (v1994 + 0);
            if (v1996 && (v1995 < a))
                continue;
            v1996 = false;
            if (v1997 >= v1999)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2000, ref v1998, out v1999);
            v2000[v1997] = v1995;
            v1997++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2000, v1997);
    }

    int[] RangeSkipWhileChangingParamToArrayRewritten_ProceduralLinq1(ref int a)
    {
        int v2001;
        int v2002;
        bool v2003;
        int v2004;
        int v2005;
        int v2006;
        int[] v2007;
        v2003 = true;
        v2004 = 0;
        v2005 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2005 -= (v2005 % 2);
        v2006 = 8;
        v2007 = new int[8];
        v2001 = 0;
        for (; v2001 < 100; v2001++)
        {
            v2002 = (v2001 + 0);
            if (v2003 && (v2002 < a++))
                continue;
            v2003 = false;
            if (v2004 >= v2006)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2007, ref v2005, out v2006);
            v2007[v2004] = v2002;
            v2004++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2007, v2004);
    }

    int[] RangeSkipWhileChangingParamToArray2Rewritten_ProceduralLinq1(ref int a)
    {
        int v2008;
        int v2009;
        bool v2010;
        int v2011;
        int v2012;
        int v2013;
        int[] v2014;
        v2010 = true;
        v2011 = 0;
        v2012 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2012 -= (v2012 % 2);
        v2013 = 8;
        v2014 = new int[8];
        v2008 = 0;
        for (; v2008 < 100; v2008++)
        {
            v2009 = (v2008 + 0);
            if (v2010 && (v2009 < a--))
                continue;
            v2010 = false;
            if (v2011 >= v2013)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2014, ref v2012, out v2013);
            v2014[v2011] = v2009;
            v2011++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2014, v2011);
    }

    int[] RangeSkipWhileChangingParamsToArrayRewritten_ProceduralLinq1(ref int a, ref int b)
    {
        int v2015;
        int v2016;
        bool v2017;
        int v2018;
        int v2019;
        int v2020;
        int[] v2021;
        v2017 = true;
        v2018 = 0;
        v2019 = (LinqRewrite.Core.IntExtensions.Log2((uint)100) - 3);
        v2019 -= (v2019 % 2);
        v2020 = 8;
        v2021 = new int[8];
        v2015 = 0;
        for (; v2015 < 100; v2015++)
        {
            v2016 = (v2015 + 0);
            if (v2017 && (v2016 < a++ - b--))
                continue;
            v2017 = false;
            if (v2018 >= v2020)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, 100, ref v2021, ref v2019, out v2020);
            v2021[v2018] = v2016;
            v2018++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v2021, v2018);
    }
}}