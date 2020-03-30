using System.Collections.Generic;
using System.Linq;
using LinqRewrite.Core;
using LinqRewrite.Core.SimpleList;
using NUnit.Framework;

namespace TestsLibrary.Tests
{
public class DistinctTests
{
    [Datapoints]
    private int[] ArrayItems = Enumerable.Range(0, 100).ToArray();
    [Datapoints]
    private int[] RepeatArrayItems = Enumerable.Repeat(0, 100).ToArray();
    [Datapoints]
    private IEnumerable<int> EnumerableItems = Enumerable.Range(0, 100);
    public void RunTests()
    {
        TestsExtensions.TestEquals(nameof(ArrayDistinct), ArrayDistinct, ArrayDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDefaultComparerDistinct), ArrayDefaultComparerDistinct, ArrayDefaultComparerDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayStrangeComparerDistinct), ArrayStrangeComparerDistinct, ArrayStrangeComparerDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayRepeatDistinct), ArrayRepeatDistinct, ArrayRepeatDistinctRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableDistinct), EnumerableDistinct, EnumerableDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArraySelectDistinct), ArraySelectDistinct, ArraySelectDistinctRewritten);
        TestsExtensions.TestEquals(nameof(RepeatArraySelectDistinct), RepeatArraySelectDistinct, RepeatArraySelectDistinctRewritten);
        TestsExtensions.TestEquals(nameof(ArrayWhereSelectDistinct), ArrayWhereSelectDistinct, ArrayWhereSelectDistinctRewritten);
        TestsExtensions.TestEquals(nameof(EnumerableDistinctToArray), EnumerableDistinctToArray, EnumerableDistinctToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctToArray), ArrayDistinctToArray, ArrayDistinctToArrayRewritten);
        TestsExtensions.TestEquals(nameof(ArrayDistinctToSimpleList), ArrayDistinctToSimpleList, ArrayDistinctToSimpleListRewritten);
    }

    [NoRewrite]
    public IEnumerable<int> ArrayDistinct()
    {
        return ArrayItems.Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctRewritten()
    {
        return ArrayDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDefaultComparerDistinct()
    {
        return ArrayItems.Distinct(EqualityComparer<int>.Default);
    } //EndMethod

    public IEnumerable<int> ArrayDefaultComparerDistinctRewritten()
    {
        return ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayStrangeComparerDistinct()
    {
        return ArrayItems.Distinct(new IntStrangeComparer());
    } //EndMethod

    public IEnumerable<int> ArrayStrangeComparerDistinctRewritten()
    {
        return ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayRepeatDistinct()
    {
        return RepeatArrayItems.Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayRepeatDistinctRewritten()
    {
        return ArrayRepeatDistinctRewritten_ProceduralLinq1(RepeatArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableDistinct()
    {
        return EnumerableItems.Distinct();
    } //EndMethod

    public IEnumerable<int> EnumerableDistinctRewritten()
    {
        return EnumerableDistinctRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArraySelectDistinct()
    {
        return ArrayItems.Select(x => x % 2).Distinct();
    } //EndMethod

    public IEnumerable<int> ArraySelectDistinctRewritten()
    {
        return ArraySelectDistinctRewritten_ProceduralLinq1(ArrayItems, x => x % 2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> RepeatArraySelectDistinct()
    {
        var a = 0;
        return ArrayItems.Select(x => x + a++ % 2).Distinct();
    } //EndMethod

    public IEnumerable<int> RepeatArraySelectDistinctRewritten()
    {
        var a = 0;
        return RepeatArraySelectDistinctRewritten_ProceduralLinq1(ArrayItems, x => x + a++ % 2);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayWhereSelectDistinct()
    {
        return ArrayItems.Where(x => x > 50).Select(x => x % 10).Distinct();
    } //EndMethod

    public IEnumerable<int> ArrayWhereSelectDistinctRewritten()
    {
        return ArrayWhereSelectDistinctRewritten_ProceduralLinq1(ArrayItems, x => x > 50, x => x % 10);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> EnumerableDistinctToArray()
    {
        return EnumerableItems.Distinct().ToArray();
    } //EndMethod

    public IEnumerable<int> EnumerableDistinctToArrayRewritten()
    {
        return EnumerableDistinctToArrayRewritten_ProceduralLinq1(EnumerableItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctToArray()
    {
        return ArrayItems.Select(x => x % 10).Distinct().ToArray();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctToArrayRewritten()
    {
        return ArrayDistinctToArrayRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    [NoRewrite]
    public IEnumerable<int> ArrayDistinctToSimpleList()
    {
        return ArrayItems.Select(x => x % 10).Distinct().ToSimpleList();
    } //EndMethod

    public IEnumerable<int> ArrayDistinctToSimpleListRewritten()
    {
        return ArrayDistinctToSimpleListRewritten_ProceduralLinq1(ArrayItems);
    } //EndMethod

    System.Collections.Generic.IEnumerable<int> ArrayDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v166;
        HashSet<int> v167;
        v167 = new HashSet<int>();
        v166 = 0;
        for (; v166 < ArrayItems.Length; v166++)
        {
            if (!v167.Add(ArrayItems[v166]))
                continue;
            yield return ArrayItems[v166];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v168;
        HashSet<int> v169;
        v169 = new HashSet<int>(EqualityComparer<int>.Default);
        v168 = 0;
        for (; v168 < ArrayItems.Length; v168++)
        {
            if (!v169.Add(ArrayItems[v168]))
                continue;
            yield return ArrayItems[v168];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v170;
        HashSet<int> v171;
        v171 = new HashSet<int>(new IntStrangeComparer());
        v170 = 0;
        for (; v170 < ArrayItems.Length; v170++)
        {
            if (!v171.Add(ArrayItems[v170]))
                continue;
            yield return ArrayItems[v170];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayRepeatDistinctRewritten_ProceduralLinq1(int[] RepeatArrayItems)
    {
        int v172;
        HashSet<int> v173;
        v173 = new HashSet<int>();
        v172 = 0;
        for (; v172 < RepeatArrayItems.Length; v172++)
        {
            if (!v173.Add(RepeatArrayItems[v172]))
                continue;
            yield return RepeatArrayItems[v172];
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableDistinctRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v174;
        HashSet<int> v175;
        int v176;
        v175 = new HashSet<int>();
        v174 = EnumerableItems.GetEnumerator();
        try
        {
            while (v174.MoveNext())
            {
                v176 = v174.Current;
                if (!v175.Add(v176))
                    continue;
                yield return v176;
            }
        }
        finally
        {
            v174.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v178)
    {
        int v177;
        HashSet<int> v179;
        int v180;
        v179 = new HashSet<int>();
        v177 = 0;
        for (; v177 < ArrayItems.Length; v177++)
        {
            v180 = v178(ArrayItems[v177]);
            if (!v179.Add(v180))
                continue;
            yield return v180;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v182)
    {
        int v181;
        HashSet<int> v183;
        int v184;
        v183 = new HashSet<int>();
        v181 = 0;
        for (; v181 < ArrayItems.Length; v181++)
        {
            v184 = v182(ArrayItems[v181]);
            if (!v183.Add(v184))
                continue;
            yield return v184;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v186, System.Func<int, int> v187)
    {
        int v185;
        HashSet<int> v188;
        int v189;
        v188 = new HashSet<int>();
        v185 = 0;
        for (; v185 < ArrayItems.Length; v185++)
        {
            if (!v186(ArrayItems[v185]))
                continue;
            v189 = v187(ArrayItems[v185]);
            if (!v188.Add(v189))
                continue;
            yield return v189;
        }
    }

    int[] EnumerableDistinctToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v190;
        HashSet<int> v191;
        int v192;
        int v193;
        int v194;
        int[] v195;
        v191 = new HashSet<int>();
        v193 = 0;
        v194 = 8;
        v195 = new int[8];
        v190 = EnumerableItems.GetEnumerator();
        try
        {
            while (v190.MoveNext())
            {
                v192 = v190.Current;
                if (!v191.Add(v192))
                    continue;
                if (v193 >= v194)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v195, ref v194);
                v195[v193] = v192;
                v193++;
            }
        }
        finally
        {
            v190.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v195, v193);
    }

    int[] ArrayDistinctToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v196;
        HashSet<int> v197;
        int v198;
        int v199;
        int v200;
        int v201;
        int[] v202;
        v197 = new HashSet<int>();
        v199 = 0;
        v200 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v200 -= (v200 % 2);
        v201 = 8;
        v202 = new int[8];
        v196 = 0;
        for (; v196 < ArrayItems.Length; v196++)
        {
            v198 = (ArrayItems[v196] % 10);
            if (!v197.Add(v198))
                continue;
            if (v199 >= v201)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v202, ref v200, out v201);
            v202[v199] = v198;
            v199++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v202, v199);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayDistinctToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v203;
        HashSet<int> v204;
        int v205;
        int v206;
        int v207;
        int v208;
        int[] v209;
        SimpleList<int> v210;
        v204 = new HashSet<int>();
        v206 = 0;
        v207 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v207 -= (v207 % 2);
        v208 = 8;
        v209 = new int[8];
        v203 = 0;
        for (; v203 < ArrayItems.Length; v203++)
        {
            v205 = (ArrayItems[v203] % 10);
            if (!v204.Add(v205))
                continue;
            if (v206 >= v208)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v209, ref v207, out v208);
            v209[v206] = v205;
            v206++;
        }

        v210 = new SimpleList<int>();
        v210.Items = v209;
        v210.Count = v206;
        return v210;
    }
}}