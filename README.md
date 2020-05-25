# LinqRewrite
Improved version of roslyn-linq-rewrite (https://github.com/antiufo/roslyn-linq-rewrite). 
This tool rewrites LINQ queries in C# code using plain procedural code, minimizing allocations and dynamic dispatch, 
inlining lambdas, optimizing simple math expressions and using known information for optimization. 
It has two run modes. First to compile rewritten code into .dll or .exe, second to rewrite the code and save it into a specified folder. 
For proper behavior install NuGet package LinqRewrite.Core into project which you are rewriting.

# Use
```bash
roslyn-linq-rewrite --help

roslyn-linq-rewrite <path-to-csproj>
roslyn-linq-rewrite <path-to-sln>
roslyn-linq-rewrite <path-to-cs>
roslyn-linq-rewrite <path-to-csx>

roslyn-linq-rewrite <path-to-csproj> --rewriteDst=""Folder where to rewrite""
roslyn-linq-rewrite <path-to-sln> --rewriteDst=""Folder where to rewrite""
roslyn-linq-rewrite <path-to-cs> --rewriteDst=""Folder where to rewrite""
roslyn-linq-rewrite <path-to-csx> --rewriteDst=""Folder where to rewrite""
```


## Example input code
```csharp
public int Method1()
{
    var arr = new[] { 1, 2, 3, 4 };
    var q = 2;
    return arr.Where(x => x > q).Select(x => x + 3).Sum();
}
```
**Allocations**: input array, array enumerator, closure for `q`, `Where` delegate, `Select` delegate, `Where` enumerator, `Select` enumerator. 
## Decompiled output code
```csharp
public int Method1()
{
    int[] arr = new[] { 1, 2, 3, 4 };
    int q = 2;
    return this.Method1_ProceduralLinq1(arr, q);
}
private int Method1_ProceduralLinq1(int[] arr, int q)
{
    if (arr == null) throw new ArgumentNullException();

    int sum = 0;
    int indexer = 0;
    for (; indexer < arr.Length; indexer++)
    {
        if (!(arr[i] > q))
            continue;
        sum += arr[i] + 3;
    }
    return sum;
}
```
**Allocations**: input array.

## Rewriting of not known result size

In roslyn-linq-rewrite are used high end methods and it lowers performance. 
In LinqRewrite was created new collection Array based but allows enlarging and
reducing size of collection to provide best performance. Also there was developed
new enlarging algorithm for reducing of allocations and increasing of speed.

```csharp
public void Method1()
{
    var arr = new[] { 1, 2, 3, 4 };
    var q = 2;
    var res = arr.Where(x => x > q).Select(x => x + 3).ToList();
}
```

```csharp
public void Method1()
{
    var arr = new[] { 1, 2, 3, 4 };
    var q = 2;
    var res = arr.Where(x => x > q).Select(x => x + 3).ToList();
}

LinqRewrite.Core.SimpleList.SimpleList<int> Method1_ProceduralLinq1(int[] arr, int q)
{
    if (arr == null)
        throw new System.InvalidOperationException("Invalid null object");
    List<int> result = new List<int>();
    indexer = 0;
    for (; indexer < arr.Length; indexer += 1)
    {
        if (!(arr[indexer] > q))
            continue;
        result.Add(3 + arr[indexer]);
    }
    return result;
}
```

**Old rewrite way

```csharp
public void Method1()
{
    var arr = new[]{1, 2, 3, 4};
    var q = 2;
    var res = Method1_ProceduralLinq1(arr, q);
}

LinqRewrite.Core.SimpleList.SimpleList<int> Method1_ProceduralLinq1(int[] arr, int q)
{
    if (arr == null)
        throw new System.InvalidOperationException("Invalid null object");
    int current = 0;
    int log = LinqRewrite.Core.IntExtensions.Log2((uint)arr.Length) - 3;
    log -= log % 2;
    int currentLength = 8;
    int[] currentArray = new int[8];
    indexer = 0;
    for (; indexer < arr.Length; indexer += 1)
    {
        if (!(arr[indexer] > q))
            continue;
        if (current >= currentLength)
            LinqRewrite.Core.EnlargeExtensions.LogEnlargeArray(2, arr.Length, ref currentArray, ref log, out currentLength);
        currentArray[current] = 3 + arr[indexer];
        current++;
    }

    SimpleList<int> result = new SimpleList<int>();
    result.Items = currentArray;
    result.Count = current;
    return result;
}
```
**New rewrite way based on array enlarging

Also there were added a lot of optimizations as lambda inlining, math simplifier, 
algoritm choosing according to input, expression simplifier or assertion disabling.

*Note: in this example, the optimizing compiler has generated code using arrays, because the type was known at compile time. When this is not the case, the generated code will instead use iteration method according to collection type.*
*Non-optimizable call chains and `IQueryable<>` are left intact.*
# Supported LINQ methods
* All except of `DefaultIfEmpty`, 
* `OrderBy`, `OrderByDescending`, `ThenBy`, `ThenbyDescending`
* `ToLookup`

# Additional
* If you need to exclude a specific method, class or struct, apply a `[NoRewrite]` attribute to that method, class or struct
```csharp
[NoRewrite]
public void Method1()
{
    var arr = new[] { 1, 2, 3, 4 };
    var q = 2;
    var res = arr.Where(x => x > q).Select(x => x + 3).ToList();
}
```
* If you want to further optimize if you ensure conditions of operators you can use Unchecked()
* for example for sum of groups
```csharp
public double ArrayAverageRewritten2()
{
    var sum = ExtendedLinq.Range(0, Items.Length / 10, 10).Sum(x => Items.Unchecked().Skip(x).Take(10).Sum());
    sum += Items.Unchecked().Skip(Items.Length - Items.Length % 10).Take(Items.Length % 10).Sum();
    return sum;
}
```

* would be rewritten as

```csharp
public double ArrayAverageRewritten2()
{
    var sum = ArrayAverageRewritten2_ProceduralLinq1();
    sum += ArrayAverageRewritten2_ProceduralLinq2(Items);
    return sum;
}

int ArrayAverageRewritten2_ProceduralLinq1()
{
    if (0 > Items.Length / 10)
        throw new System.InvalidOperationException("Index out of range");
    int max = Items.Length / 10 * 10;
    int sum = 0;
    int i = 0;
    for (; i < max; i += 10)
        sum += Items[i] + Items[1 + i] + Items[2 + i] + Items[3 + i] + Items[4 + i] + Items[5 + i] + Items[6 + i] + Items[7 + i] + Items[8 + i] + Items[9 + i];
    return sum;
}

int ArrayAverageRewritten2_ProceduralLinq2(int[] Items)
{
    if (Items == null)
        throw new System.InvalidOperationException("Invalid null object");
    int max = (Items.Length % 10);
    int sum = 0;
    int indexer = Items.Length - Items.Length % 10;
    for (; indexer < max; indexer += 1)
        sum += (Items[indexer]);
    return sum;
}
```

* Which is more performant then Items.Sum()

# Comparison to System.Linq
* Uses external program for rewriting
* No allocations for iterators and reduces closures
* New algorithm for array enlarging
* Using more information for optimization
* Some assertions calculated when rewriting
* More constants calculated when rewriting
* Do not implement all operators
* No support for F#
* Only method LINQ

# Comparison to LinqOptimizer
* Code is optimized at build time (as opposed to run time), so no 30us overhead
* Uses existing LINQ syntax, no need for `AsQueryExpr().Run()`
* No allocations for `Expression<>` trees and enumerator boxing
* Parallel LINQ is not supported (i.e. left intact)
* Using a lot more information for optimization (for example different collection enumeration for different sources)
* More operators
* No support for F#

# Comparsion to old roslyn-linq-rewrite
* More operators (Old could rewrite only simple operators)
* Math optimization (Without optimization of division because of different int and double division)
* Using a lot more information for optimization (for example different collection enumeration for different sources)
* Using more low end code (Using arrays for enlarging, not List<T>)
* Working on new project types
* Simple expressions rewrite
* Better enlarging algorithm
* Created over 145000 of tests

# Comparsion to LinqFaster
* Rewriting of chained operators
* When chaining operators, fewer allocations in rewritten
* LinqFaster only on arrays
* LinqFaster implements parallel and SIMD operations
* LinqFaster not lazily evaluated
* LinqFaster must change from System.Linq
* LinqRewriter inlines lambda methods and reduces closures
* LinqRewriter does not allocate any arrays in Source.Select(x => x + 3).Sum()
* LinqRewriter uses enlarging for filling array of unknown size

