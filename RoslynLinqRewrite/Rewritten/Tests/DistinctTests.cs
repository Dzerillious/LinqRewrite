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
        ArrayDistinct().TestEquals(nameof(ArrayDistinct), ArrayDistinctRewritten());
        ArrayDefaultComparerDistinct().TestEquals(nameof(ArrayDefaultComparerDistinct), ArrayDefaultComparerDistinctRewritten());
        ArrayStrangeComparerDistinct().TestEquals(nameof(ArrayStrangeComparerDistinct), ArrayStrangeComparerDistinctRewritten());
        ArrayRepeatDistinct().TestEquals(nameof(ArrayRepeatDistinct), ArrayRepeatDistinctRewritten());
        EnumerableDistinct().TestEquals(nameof(EnumerableDistinct), EnumerableDistinctRewritten());
        ArraySelectDistinct().TestEquals(nameof(ArraySelectDistinct), ArraySelectDistinctRewritten());
        RepeatArraySelectDistinct().TestEquals(nameof(RepeatArraySelectDistinct), RepeatArraySelectDistinctRewritten());
        ArrayWhereSelectDistinct().TestEquals(nameof(ArrayWhereSelectDistinct), ArrayWhereSelectDistinctRewritten());
        EnumerableDistinctToArray().TestEquals(nameof(EnumerableDistinctToArray), EnumerableDistinctToArrayRewritten());
        ArrayDistinctToArray().TestEquals(nameof(ArrayDistinctToArray), ArrayDistinctToArrayRewritten());
        ArrayDistinctToSimpleList().TestEquals(nameof(ArrayDistinctToSimpleList), ArrayDistinctToSimpleListRewritten());
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
        int v130;
        HashSet<int> v131;
        v131 = new HashSet<int>();
        v130 = 0;
        for (; v130 < ArrayItems.Length; v130++)
        {
            if (!v131.Add(ArrayItems[v130]))
                continue;
            yield return ArrayItems[v130];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayDefaultComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v132;
        HashSet<int> v133;
        v133 = new HashSet<int>(EqualityComparer<int>.Default);
        v132 = 0;
        for (; v132 < ArrayItems.Length; v132++)
        {
            if (!v133.Add(ArrayItems[v132]))
                continue;
            yield return ArrayItems[v132];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayStrangeComparerDistinctRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v134;
        HashSet<int> v135;
        v135 = new HashSet<int>(new IntStrangeComparer());
        v134 = 0;
        for (; v134 < ArrayItems.Length; v134++)
        {
            if (!v135.Add(ArrayItems[v134]))
                continue;
            yield return ArrayItems[v134];
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayRepeatDistinctRewritten_ProceduralLinq1(int[] RepeatArrayItems)
    {
        int v136;
        HashSet<int> v137;
        v137 = new HashSet<int>();
        v136 = 0;
        for (; v136 < RepeatArrayItems.Length; v136++)
        {
            if (!v137.Add(RepeatArrayItems[v136]))
                continue;
            yield return RepeatArrayItems[v136];
        }
    }

    System.Collections.Generic.IEnumerable<int> EnumerableDistinctRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v138;
        HashSet<int> v139;
        int v140;
        v139 = new HashSet<int>();
        v138 = EnumerableItems.GetEnumerator();
        try
        {
            while (v138.MoveNext())
            {
                v140 = v138.Current;
                if (!v139.Add(v140))
                    continue;
                yield return v140;
            }
        }
        finally
        {
            v138.Dispose();
        }
    }

    System.Collections.Generic.IEnumerable<int> ArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v142)
    {
        int v141;
        HashSet<int> v143;
        int v144;
        v143 = new HashSet<int>();
        v141 = 0;
        for (; v141 < ArrayItems.Length; v141++)
        {
            v144 = v142(ArrayItems[v141]);
            if (!v143.Add(v144))
                continue;
            yield return v144;
        }
    }

    System.Collections.Generic.IEnumerable<int> RepeatArraySelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, int> v146)
    {
        int v145;
        HashSet<int> v147;
        int v148;
        v147 = new HashSet<int>();
        v145 = 0;
        for (; v145 < ArrayItems.Length; v145++)
        {
            v148 = v146(ArrayItems[v145]);
            if (!v147.Add(v148))
                continue;
            yield return v148;
        }
    }

    System.Collections.Generic.IEnumerable<int> ArrayWhereSelectDistinctRewritten_ProceduralLinq1(int[] ArrayItems, System.Func<int, bool> v150, System.Func<int, int> v151)
    {
        int v149;
        HashSet<int> v152;
        int v153;
        v152 = new HashSet<int>();
        v149 = 0;
        for (; v149 < ArrayItems.Length; v149++)
        {
            if (!v150(ArrayItems[v149]))
                continue;
            v153 = v151(ArrayItems[v149]);
            if (!v152.Add(v153))
                continue;
            yield return v153;
        }
    }

    int[] EnumerableDistinctToArrayRewritten_ProceduralLinq1(System.Collections.Generic.IEnumerable<int> EnumerableItems)
    {
        IEnumerator<int> v154;
        HashSet<int> v155;
        int v156;
        int v157;
        int v158;
        int[] v159;
        v155 = new HashSet<int>();
        v157 = 0;
        v158 = 8;
        v159 = new int[8];
        v154 = EnumerableItems.GetEnumerator();
        try
        {
            while (v154.MoveNext())
            {
                v156 = v154.Current;
                if (!v155.Add(v156))
                    continue;
                if (v157 >= v158)
                    LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ref v159, ref v158);
                v159[v157] = v156;
                v157++;
            }
        }
        finally
        {
            v154.Dispose();
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v159, v157);
    }

    int[] ArrayDistinctToArrayRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v160;
        HashSet<int> v161;
        int v162;
        int v163;
        int v164;
        int v165;
        int[] v166;
        v161 = new HashSet<int>();
        v163 = 0;
        v164 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v164 -= (v164 % 2);
        v165 = 8;
        v166 = new int[8];
        v160 = 0;
        for (; v160 < ArrayItems.Length; v160++)
        {
            v162 = (ArrayItems[v160] % 10);
            if (!v161.Add(v162))
                continue;
            if (v163 >= v165)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v166, ref v164, out v165);
            v166[v163] = v162;
            v163++;
        }

        return LinqRewrite.Core.SimpleArrayExtensions.EnsureFullArray(v166, v163);
    }

    LinqRewrite.Core.SimpleList.SimpleList<int> ArrayDistinctToSimpleListRewritten_ProceduralLinq1(int[] ArrayItems)
    {
        int v167;
        HashSet<int> v168;
        int v169;
        int v170;
        int v171;
        int v172;
        int[] v173;
        SimpleList<int> v174;
        v168 = new HashSet<int>();
        v170 = 0;
        v171 = (LinqRewrite.Core.IntExtensions.Log2((uint)ArrayItems.Length) - 3);
        v171 -= (v171 % 2);
        v172 = 8;
        v173 = new int[8];
        v167 = 0;
        for (; v167 < ArrayItems.Length; v167++)
        {
            v169 = (ArrayItems[v167] % 10);
            if (!v168.Add(v169))
                continue;
            if (v170 >= v172)
                LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, ArrayItems.Length, ref v173, ref v171, out v172);
            v173[v170] = v169;
            v170++;
        }

        v174 = new SimpleList<int>();
        v174.Items = v173;
        v174.Count = v170;
        return v174;
    }
}}