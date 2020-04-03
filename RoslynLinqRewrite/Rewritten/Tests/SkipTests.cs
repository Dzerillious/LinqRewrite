using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class SkipTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    private bool Predicate(int value) => value > 50;
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArraySkip), ArraySkip, ArraySkipRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkip0), ArraySkip0, ArraySkip0Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipM1), ArraySkipM1, ArraySkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkip1000), ArraySkip1000, ArraySkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipParam), ArraySkipParam, ArraySkipParamRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip), EnumerableSkip, EnumerableSkipRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip0), EnumerableSkip0, EnumerableSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipM1), EnumerableSkipM1, EnumerableSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkip1000), EnumerableSkip1000, EnumerableSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipParam), EnumerableSkipParam, EnumerableSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip), RangeSkip, RangeSkipRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip0), RangeSkip0, RangeSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipM1), RangeSkipM1, RangeSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkip1000), RangeSkip1000, RangeSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipParam), RangeSkipParam, RangeSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip), RepeatSkip, RepeatSkipRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip0), RepeatSkip0, RepeatSkip0Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipM1), RepeatSkipM1, RepeatSkipM1Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkip1000), RepeatSkip1000, RepeatSkip1000Rewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipParam), RepeatSkipParam, RepeatSkipParamRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipToArray), ArraySelectSkipToArray, ArraySelectSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectSkipM1ToArray), ArraySelectSkipM1ToArray, ArraySelectSkipM1ToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSkipToArray), ArrayWhereSkipToArray, ArrayWhereSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereFalseSkipToArray), ArrayWhereFalseSkipToArray, ArrayWhereFalseSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArraySkipToArray), ArraySkipToArray, ArraySkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableSkipToArray), EnumerableSkipToArray, EnumerableSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RangeSkipToArray), RangeSkipToArray, RangeSkipToArrayRewritten);
        TestsExtensions.TestEquals(nameof(RepeatSkipToArray), RepeatSkipToArray, RepeatSkipToArrayRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArraySkip()
    {
        return ArrayItems.Skip(20);
    } //EndMethod

    public IEnumerable<int> ArraySkipRewritten()
    {
        return ArraySkipRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkip0()
    {
        return ArrayItems.Skip(0);
    } //EndMethod

    public IEnumerable<int> ArraySkip0Rewritten()
    {
        return ArraySkip0Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipM1()
    {
        return ArrayItems.Skip(-1);
    } //EndMethod

    public IEnumerable<int> ArraySkipM1Rewritten()
    {
        return ArraySkipM1Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkip1000()
    {
        return ArrayItems.Skip(1000);
    } //EndMethod

    public IEnumerable<int> ArraySkip1000Rewritten()
    {
        return ArraySkip1000Rewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipParam()
    {
        var a = 50;
        return ArrayItems.Skip(a);
    } //EndMethod

    public IEnumerable<int> ArraySkipParamRewritten()
    {
        var a = 50;
        return ArraySkipParamRewritten_ProceduralLinq1(a, ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip()
    {
        return EnumerableItems.Skip(20);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipRewritten()
    {
        return EnumerableSkipRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip0()
    {
        return EnumerableItems.Skip(0);
    } //EndMethod

    public IEnumerable<int> EnumerableSkip0Rewritten()
    {
        return EnumerableSkip0Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipM1()
    {
        return EnumerableItems.Skip(-1);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipM1Rewritten()
    {
        return EnumerableSkipM1Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkip1000()
    {
        return EnumerableItems.Skip(1000);
    } //EndMethod

    public IEnumerable<int> EnumerableSkip1000Rewritten()
    {
        return EnumerableSkip1000Rewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipParam()
    {
        var a = 50;
        return EnumerableItems.Skip(a);
    } //EndMethod

    public IEnumerable<int> EnumerableSkipParamRewritten()
    {
        var a = 50;
        return EnumerableSkipParamRewritten_ProceduralLinq1(a, EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip()
    {
        return Enumerable.Range(0, 100).Skip(20);
    } //EndMethod

    public IEnumerable<int> RangeSkipRewritten()
    {
        return RangeSkipRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip0()
    {
        return Enumerable.Range(0, 100).Skip(0);
    } //EndMethod

    public IEnumerable<int> RangeSkip0Rewritten()
    {
        return RangeSkip0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipM1()
    {
        return Enumerable.Range(0, 100).Skip(-1);
    } //EndMethod

    public IEnumerable<int> RangeSkipM1Rewritten()
    {
        return RangeSkipM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkip1000()
    {
        return Enumerable.Range(0, 100).Skip(1000);
    } //EndMethod

    public IEnumerable<int> RangeSkip1000Rewritten()
    {
        return RangeSkip1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipParam()
    {
        var a = 50;
        return Enumerable.Range(0, 100).Skip(a);
    } //EndMethod

    public IEnumerable<int> RangeSkipParamRewritten()
    {
        var a = 50;
        return RangeSkipParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip()
    {
        return Enumerable.Repeat(0, 100).Skip(20);
    } //EndMethod

    public IEnumerable<int> RepeatSkipRewritten()
    {
        return RepeatSkipRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip0()
    {
        return Enumerable.Repeat(0, 100).Skip(0);
    } //EndMethod

    public IEnumerable<int> RepeatSkip0Rewritten()
    {
        return RepeatSkip0Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipM1()
    {
        return Enumerable.Repeat(0, 100).Skip(-1);
    } //EndMethod

    public IEnumerable<int> RepeatSkipM1Rewritten()
    {
        return RepeatSkipM1Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkip1000()
    {
        return Enumerable.Repeat(0, 100).Skip(1000);
    } //EndMethod

    public IEnumerable<int> RepeatSkip1000Rewritten()
    {
        return RepeatSkip1000Rewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipParam()
    {
        var a = 50;
        return Enumerable.Repeat(0, 100).Skip(a);
    } //EndMethod

    public IEnumerable<int> RepeatSkipParamRewritten()
    {
        var a = 50;
        return RepeatSkipParamRewritten_ProceduralLinq1(a);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipToArray()
    {
        return ArrayItems.Select(x => x + 10).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipToArrayRewritten()
    {
        return ArraySelectSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectSkipM1ToArray()
    {
        return ArrayItems.Select(x => x + 10).Skip(-1).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySelectSkipM1ToArrayRewritten()
    {
        return ArraySelectSkipM1ToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereSkipToArray()
    {
        return ArrayItems.Where(x => x > 20).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereSkipToArrayRewritten()
    {
        return ArrayWhereSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereFalseSkipToArray()
    {
        return ArrayItems.Where(x => false).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayWhereFalseSkipToArrayRewritten()
    {
        return ArrayWhereFalseSkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySkipToArray()
    {
        return ArrayItems.Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> ArraySkipToArrayRewritten()
    {
        return ArraySkipToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableSkipToArray()
    {
        return EnumerableItems.Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableSkipToArrayRewritten()
    {
        return EnumerableSkipToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RangeSkipToArray()
    {
        return Enumerable.Range(0, 100).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RangeSkipToArrayRewritten()
    {
        return RangeSkipToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatSkipToArray()
    {
        return Enumerable.Repeat(0, 100).Skip(20).ToArray();
    } //EndMethod

    public IEnumerable<int> RepeatSkipToArrayRewritten()
    {
        return RepeatSkipToArrayRewritten_ProceduralLinq1();
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArraySkipRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1671;
        int v1672;
        v1672 = 20 < 0 ? 20 : 0;
        v1672 = 20;
        v1671 = (0 + v1672);
        for (; v1671 < ArrayItems.Length; v1671++)
            yield return ArrayItems[v1671];
    }

    System.Collections.Generic.IEnumerable<int> ArraySkip0Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1673;
        int v1674;
        v1674 = 0 < 0 ? 0 : 0;
        v1674 = 0;
        v1673 = (0 + v1674);
        for (; v1673 < ArrayItems.Length; v1673++)
            yield return ArrayItems[v1673];
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipM1Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1675;
        v1675 = 0;
        for (; v1675 < ArrayItems.Length; v1675++)
            yield return ArrayItems[v1675];
    }

    System.Collections.Generic.IEnumerable<int> ArraySkip1000Rewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1676;
        int v1677;
        v1677 = 1000 < 0 ? 1000 : 0;
        v1677 = 1000;
        v1676 = (0 + v1677);
        for (; v1676 < ArrayItems.Length; v1676++)
            yield return ArrayItems[v1676];
    }

    System.Collections.Generic.IEnumerable<int> ArraySkipParamRewritten_ProceduralLinq1(int a, int[] ArrayItems)
    {
        int v1678;
        int v1679;
        v1679 = a < 0 ? a : 0;
        v1679 = a;
        v1678 = (0 + v1679);
        for (; v1678 < ArrayItems.Length; v1678++)
            yield return ArrayItems[v1678];
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1680;
        int v1681;
        v1680 = EnumerableItems.GetEnumerator();
        v1681 = 0;
        try
        {
            while (v1680.MoveNext())
            {
                if (v1681 < 20)
                {
                    v1681++;
                    continue;
                }

                yield return v1680.Current;
                v1681++;
            }
        }
        finally
        {
            v1680.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkip0Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1682;
        int v1683;
        v1682 = EnumerableItems.GetEnumerator();
        v1683 = 0;
        try
        {
            while (v1682.MoveNext())
            {
                if (v1683 < 0)
                {
                    v1683++;
                    continue;
                }

                yield return v1682.Current;
                v1683++;
            }
        }
        finally
        {
            v1682.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipM1Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1684;
        v1684 = EnumerableItems.GetEnumerator();
        try
        {
            while (v1684.MoveNext())
                yield return v1684.Current;
        }
        finally
        {
            v1684.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkip1000Rewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1685;
        int v1686;
        v1685 = EnumerableItems.GetEnumerator();
        v1686 = 0;
        try
        {
            while (v1685.MoveNext())
            {
                if (v1686 < 1000)
                {
                    v1686++;
                    continue;
                }

                yield return v1685.Current;
                v1686++;
            }
        }
        finally
        {
            v1685.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableSkipParamRewritten_ProceduralLinq1(int a, System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1687;
        int v1688;
        v1687 = EnumerableItems.GetEnumerator();
        v1688 = 0;
        try
        {
            while (v1687.MoveNext())
            {
                if (v1688 < a)
                {
                    v1688++;
                    continue;
                }

                yield return v1687.Current;
                v1688++;
            }
        }
        finally
        {
            v1687.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipRewritten_ProceduralLinq1()
    {
        int v1689;
        int v1690;
        v1690 = 20 < 0 ? 20 : 0;
        v1690 = 20;
        v1689 = (0 + v1690);
        for (; v1689 < 100; v1689++)
            yield return (v1689 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeSkip0Rewritten_ProceduralLinq1()
    {
        int v1691;
        int v1692;
        v1692 = 0 < 0 ? 0 : 0;
        v1692 = 0;
        v1691 = (0 + v1692);
        for (; v1691 < 100; v1691++)
            yield return (v1691 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipM1Rewritten_ProceduralLinq1()
    {
        int v1693;
        v1693 = 0;
        for (; v1693 < 100; v1693++)
            yield return (v1693 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeSkip1000Rewritten_ProceduralLinq1()
    {
        int v1694;
        int v1695;
        v1695 = 1000 < 0 ? 1000 : 0;
        v1695 = 1000;
        v1694 = (0 + v1695);
        for (; v1694 < 100; v1694++)
            yield return (v1694 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RangeSkipParamRewritten_ProceduralLinq1(int a)
    {
        int v1696;
        int v1697;
        v1697 = a < 0 ? a : 0;
        v1697 = a;
        v1696 = (0 + v1697);
        for (; v1696 < 100; v1696++)
            yield return (v1696 + 0);
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipRewritten_ProceduralLinq1()
    {
        int v1698;
        int v1699;
        v1699 = 20 < 0 ? 20 : 0;
        v1699 = 20;
        v1698 = (0 + v1699);
        for (; v1698 < 100; v1698++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkip0Rewritten_ProceduralLinq1()
    {
        int v1700;
        int v1701;
        v1701 = 0 < 0 ? 0 : 0;
        v1701 = 0;
        v1700 = (0 + v1701);
        for (; v1700 < 100; v1700++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipM1Rewritten_ProceduralLinq1()
    {
        int v1702;
        v1702 = 0;
        for (; v1702 < 100; v1702++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkip1000Rewritten_ProceduralLinq1()
    {
        int v1703;
        int v1704;
        v1704 = 1000 < 0 ? 1000 : 0;
        v1704 = 1000;
        v1703 = (0 + v1704);
        for (; v1703 < 100; v1703++)
            yield return 0;
    }

    System.Collections.Generic.IEnumerable<int> RepeatSkipParamRewritten_ProceduralLinq1(int a)
    {
        int v1705;
        int v1706;
        v1706 = a < 0 ? a : 0;
        v1706 = a;
        v1705 = (0 + v1706);
        for (; v1705 < 100; v1705++)
            yield return 0;
    }

    int[] ArraySelectSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1707;
        int v1708;
        v1708 = 20 < 0 ? 20 : 0;
        int[] v1709;
        int v1710;
        v1708 = 20;
        v1709 = new int[(ArrayItems.Length - v1708)];
        v1710 = 0;
        v1707 = (0 + v1708);
        for (; v1707 < ArrayItems.Length; v1707++)
        {
            v1709[v1710] = (ArrayItems[v1707] + 10);
            v1710++;
        }

        return v1709;
    }

    int[] ArraySelectSkipM1ToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1711;
        int[] v1712;
        v1712 = new int[ArrayItems.Length];
        v1711 = 0;
        for (; v1711 < ArrayItems.Length; v1711++)
            v1712[v1711] = (ArrayItems[v1711] + 10);
        return v1712;
    }

    int[] ArrayWhereSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1713;
        int v1714;
        int v1715;
        int v1716;
        int v1717;
        int[] v1718;
        v1714 = 0;
        v1715 = 0;
        v1716 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1716 -= (v1716 % 2);
        v1717 = 8;
        v1718 = new int[8];
        v1713 = 0;
        for (; v1713 < ArrayItems.Length; v1713++)
        {
            if (!((ArrayItems[v1713] > 20)))
                continue;
            if (v1714 < 20)
            {
                v1714++;
                continue;
            }

            if (v1715 >= v1717)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1718, ref v1716, out v1717);
            v1718[v1715] = ArrayItems[v1713];
            v1714++;
            v1715++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1718, v1715);
    }

    int[] ArrayWhereFalseSkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1719;
        int v1720;
        int v1721;
        int v1722;
        int v1723;
        int[] v1724;
        v1720 = 0;
        v1721 = 0;
        v1722 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v1722 -= (v1722 % 2);
        v1723 = 8;
        v1724 = new int[8];
        v1719 = 0;
        for (; v1719 < ArrayItems.Length; v1719++)
        {
            if (!((false)))
                continue;
            if (v1720 < 20)
            {
                v1720++;
                continue;
            }

            if (v1721 >= v1723)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v1724, ref v1722, out v1723);
            v1724[v1721] = ArrayItems[v1719];
            v1720++;
            v1721++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1724, v1721);
    }

    int[] ArraySkipToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v1725;
        int v1726;
        v1726 = 20 < 0 ? 20 : 0;
        int[] v1727;
        v1726 = 20;
        v1727 = new int[(ArrayItems.Length - v1726)];
        System.Array.Copy(ArrayItems, (0 + v1726), v1727, 0, (ArrayItems.Length - (0 + v1726)));
        return v1727;
    }

    int[] EnumerableSkipToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v1728;
        int v1729;
        int v1730;
        int v1731;
        int[] v1732;
        v1728 = EnumerableItems.GetEnumerator();
        v1729 = 0;
        v1730 = 0;
        v1731 = 8;
        v1732 = new int[8];
        try
        {
            while (v1728.MoveNext())
            {
                if (v1729 < 20)
                {
                    v1729++;
                    continue;
                }

                if (v1730 >= v1731)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v1732, ref v1731);
                v1732[v1730] = v1728.Current;
                v1729++;
                v1730++;
            }
        }
        finally
        {
            v1728.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v1732, v1730);
    }

    int[] RangeSkipToArrayRewritten_ProceduralLinq1()
    {
        int v1733;
        int v1734;
        v1734 = 20 < 0 ? 20 : 0;
        int[] v1735;
        int v1736;
        v1734 = 20;
        v1735 = new int[(100 - v1734)];
        v1736 = 0;
        v1733 = (0 + v1734);
        for (; v1733 < 100; v1733++)
        {
            v1735[v1736] = (v1733 + 0);
            v1736++;
        }

        return v1735;
    }

    int[] RepeatSkipToArrayRewritten_ProceduralLinq1()
    {
        int v1737;
        int v1738;
        v1738 = 20 < 0 ? 20 : 0;
        int[] v1739;
        int v1740;
        v1738 = 20;
        v1739 = new int[(100 - v1738)];
        v1740 = 0;
        v1737 = (0 + v1738);
        for (; v1737 < 100; v1737++)
        {
            v1739[v1740] = 0;
            v1740++;
        }

        return v1739;
    }
}}