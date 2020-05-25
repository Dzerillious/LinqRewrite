using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SelectManyTests
{
    [Datapoints]
    private int[] NullItems = null;
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private static int[] StaticArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private List<int> ListItems = Enumerable.Range(0, 100).ToList();
    [Datapoints]
    private SimpleList<int> SimpleListItems = Enumerable.Range(0, 100).ToSimpleList();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public IEnumerable<int> ManySelector(int x) => Enumerable.Range(x, 100);
    
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(NullSelectMany), NullSelectMany, NullSelectManyRewritten);
        TestsExtensions.TestEquals(nameof(NullableSelectMany), NullableSelectMany, NullableSelectManyRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyArray), SelectManyArray, SelectManyArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyList), SelectManyList, SelectManyListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManySimpleList), SelectManySimpleList, SelectManySimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyEnumerable), SelectManyEnumerable, SelectManyEnumerableRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyArrayToArray), SelectManyArrayToArray, SelectManyArrayToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyListToArray), SelectManyListToArray, SelectManyListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyEnumerableToArray), SelectManyEnumerableToArray, SelectManyEnumerableToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectManySimpleListToArray), SelectManySimpleListToArray, SelectManySimpleListToArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyArrayToSimpleList), SelectManyArrayToSimpleList, SelectManyArrayToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyListToSimpleList), SelectManyListToSimpleList, SelectManyListToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyEnumerableToSimpleList), SelectManyEnumerableToSimpleList, SelectManyEnumerableToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManySimpleListToSimpleList), SelectManySimpleListToSimpleList, SelectManySimpleListToSimpleListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyArrayToList), SelectManyArrayToList, SelectManyArrayToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyListToList), SelectManyListToList, SelectManyListToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyEnumerableToList), SelectManyEnumerableToList, SelectManyEnumerableToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManySimpleListToList), SelectManySimpleListToList, SelectManySimpleListToListRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyStaticArray), SelectManyStaticArray, SelectManyStaticArrayRewritten);
        TestsExtensions.TestEquals(nameof(SelectManyMethodManySelector), SelectManyMethodManySelector, SelectManyMethodManySelectorRewritten);
        TestsExtensions.TestEquals(nameof(StaticSelectMany), StaticSelectMany, StaticSelectManyRewritten);
        TestsExtensions.TestEquals(nameof(StaticClassSelectMany), StaticClassSelectMany, StaticClassSelectManyRewritten);
        TestsExtensions.TestEquals(nameof(MultipleSelectMany), MultipleSelectMany, MultipleSelectManyRewritten);
        TestsExtensions.TestEquals(nameof(StaticSelectMany), StaticSelectMany, StaticSelectManyRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> NullSelectMany()
    {
        return NullItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> NullSelectManyRewritten()
    {
        return NullItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> NullableSelectMany()
    {
        return NullItems?.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> NullableSelectManyRewritten()
    {
        return NullItems?.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyArray()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> SelectManyArrayRewritten()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyList()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> SelectManyListRewritten()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManySimpleList()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> SelectManySimpleListRewritten()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyEnumerable()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> SelectManyEnumerableRewritten()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyArrayToArray()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectManyArrayToArrayRewritten()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyListToArray()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectManyListToArrayRewritten()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyEnumerableToArray()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectManyEnumerableToArrayRewritten()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManySimpleListToArray()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    public IEnumerable<int> SelectManySimpleListToArrayRewritten()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100)).ToArray();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyArrayToSimpleList()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectManyArrayToSimpleListRewritten()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyListToSimpleList()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectManyListToSimpleListRewritten()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyEnumerableToSimpleList()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectManyEnumerableToSimpleListRewritten()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManySimpleListToSimpleList()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    public IEnumerable<int> SelectManySimpleListToSimpleListRewritten()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100)).ToSimpleList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyArrayToList()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    public IEnumerable<int> SelectManyArrayToListRewritten()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyListToList()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    public IEnumerable<int> SelectManyListToListRewritten()
    {
        return ListItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyEnumerableToList()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    public IEnumerable<int> SelectManyEnumerableToListRewritten()
    {
        return EnumerableItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManySimpleListToList()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    public IEnumerable<int> SelectManySimpleListToListRewritten()
    {
        return SimpleListItems.SelectMany(x => Enumerable.Range(x, 100)).ToList();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyStaticArray()
    {
        return StaticArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> SelectManyStaticArrayRewritten()
    {
        return StaticArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> SelectManyMethodManySelector()
    {
        return ArrayItems.SelectMany(ManySelector);
    } //EndMethod

    public IEnumerable<int> SelectManyMethodManySelectorRewritten()
    {
        return ArrayItems.SelectMany(ManySelector);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayConcatArraySelectMany()
    {
        return ArrayItems.Concat(ArrayItems).SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> ArrayConcatArraySelectManyRewritten()
    {
        return ArrayItems.Concat(ArrayItems).SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public static IEnumerable<int> StaticSelectMany()
    {
        return StaticArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public static IEnumerable<int> StaticSelectManyRewritten()
    {
        return StaticArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    [NoRewrite]
    public static IEnumerable<int> StaticClassSelectMany()
    {
        return StaticSelectManyTests.StaticSelectMany();
    } //EndMethod

    public static IEnumerable<int> StaticClassSelectManyRewritten()
    {
        return StaticSelectManyTests.StaticSelectManyRewritten();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> MultipleSelectMany()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public IEnumerable<int> MultipleSelectManyRewritten()
    {
        return ArrayItems.SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100)).SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod
}

public static class StaticSelectManyTests
{
    [Datapoints]
    private static int[] StaticArrayItems = Enumerable.Range(0, 100).ToArray();
    [NoRewrite]
    public static IEnumerable<int> StaticSelectMany()
    {
        return StaticArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod

    public static IEnumerable<int> StaticSelectManyRewritten()
    {
        return StaticArrayItems.SelectMany(x => Enumerable.Range(x, 100));
    } //EndMethod
}}
