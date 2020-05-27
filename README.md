# LinqRewrite

Improved version of roslyn-linq-rewrite (https://github.com/antiufo/roslyn-linq-rewrite). This tool rewrites LINQ queries in C# code using plain procedural code, minimizing allocations and dynamic dispatch, inlining lambdas, optimizing simple math expressions and using known information for optimization. It has two run modes. First to compile rewritten code into .dll or .exe, second to rewrite the code and save it into a specified folder. For proper behavior install NuGet package LinqRewrite.Core into project which you are rewriting.

For basic queries which can be rewritten to simple expression (ArraySource.Select(x => x + 5).Last()) was speedup 50000x,
for aggregations and simple changes of iteration was speedup several times and for queries over IEnumerable and with too
few provided information was speedup up to 30% of System.Linq. There is no runtime overhead of LINQ rewriting.

Repository of rewriting program https://github.com/Dzerillious/LinqRewrite. LinqRewrite works as ConsoleApplication, there is no UI created for rewriting of code.

# Install and use

LinqRewrite is published as .NET Core application and can be used on Linux, Windows or macOS device. For running of LinqRewrite you must install .NET Core runtime which compiles and runs the application for you. You can download .NET Core runtime from https://dotnet.microsoft.com/download, or in Visual Studio Installer. Also you must install msbuild (part of Visual Studio or Build Tools for Visual Studio from https://visualstudio.microsoft.com/downloads/?q=build+tools) with all parts needed for compilation of your not rewriten project. For all projects which will be rewritten by LinqRewriter must be referenced NuGet named LinqRewrite.Core. Only other thing for setup you must download RoslynLinq rewrite release for your architecture (x86 or x64) and run it from command line.

For use of LinqRewrite you must create code, that will be rewritten
. You can rewrite C# script, file, project or solution. Rewriting of script or file is just for testing, because it cannot reference any NuGet or library which are needed for compilation of the file. Also when the code cannot be compiled with reference of most basic libraries, compilation error of the first face is thrown. When you create C# project or solution, for each project you must reference NuGet LinqRewrite.Core (it may be transitive reference). For running of LinqRewrite you must specify as argument path of compiled solution or project and destination where to write rewritten files. When rewriting the code, compilation is used for getting analysis of code and after rewrite, all rewritten files and files which are part of the project or solution are added into destination folder. When you want to do not rewrite some method, struct or class, you must add NoRewrite attribute before it.

Example usage 

```bash
dotnet LinqRewrite.dll                        # Prints help
dotnet LinqRewrite.dll --help                 # Prints help

dotnet LinqRewrite.dll <path-to-csproj> <path-to-rewrite>    # Rewrites project and saves files into specified directory
dotnet LinqRewrite.dll <path-to-sln> <path-to-rewrite>       # Rewrites solution and saves files into specified directory
dotnet LinqRewrite.dll <path-to-cs> <path-to-rewrite>        # Rewrites cs file and saves files into specified directory
dotnet LinqRewrite.dll <path-to-csx> <path-to-rewrite>       # Rewrites csx file and saves files into specified directory
```

## Example projects

With release of LinqRewrite there are also included two example projects. The first one is BenchmarksLibrary (with set of benchmarks for LinqRewrite) and the second one is TestsLibrary.

For building and executing TestsLibrary you must run the following commands:
```bash
cd LinqRewriteDir		# Full path to LinqRewrite
dotnet ./LinqRewrite.dll TestsDirectory/TestsLibrary.csproj directory # Where TestsDirectory is path to directory where is TestsLibrary.csproj located and directory is destination directory
cd directory
dotnet run
```

When you are in Release directory of source you can insert following:
```bash
dotnet ./LinqRewrite.dll ../../../../Tests/TestsLibrary/TestsLibrary.csproj directory
cd directory
dotnet run
```

For building and executing BenchmarksLibrary you must run the following commands:
```bash
cd LinqRewriteDir		# Full path to LinqRewrite
dotnet ./LinqRewrite.dll BenchmarksDirectory/BenchmarksLibrary.csproj directory # Where BenchmarksDirectoryis path to directory where is BenchmarksLibrary.csproj located and directory is destination directory
cd directory
dotnet run
```

When you are in Release directory of source you can insert following:
```bash
dotnet ./LinqRewrite.dll ../../../../Tests/BenchmarksLibrary/BenchmarksLibrary.csproj directory
cd directory
dotnet run
```

# Rewriting of code

LinqRewrite rewrites LINQ queries into procedural code. It creates method with code equivalent to LINQ query and then it replaces LINQ query with call of the method. It reduces allocations, increases performance and implements a lot of optimization for example math optimization. You can see source and rewritten code in example below.

Example input code
```csharp
public int Method1()
{
    var arr = new[] { 1, 2, 3, 4 };
    var q = 2;
    return arr.Where(x => x > q).Select(x => x + 3).Sum();
}
```
**Allocations**: input array, array enumerator, closure for `q`, `Where` delegate, `Select` delegate, `Where` enumerator, `Select` enumerator. 

Decompiled output code
```csharp
public int Method1()
{
    int[] arr = new[] { 1, 2, 3, 4 };
    int q = 2;
    return this.Method1_ProceduralLinq1f8fb1c9fae84db893c40020de93beee(arr, q);
}
private int Method1_ProceduralLinq1f8fb1c9fae84db893c40020de93beee(int[] arr, int q)
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

In roslyn-linq-rewrite are used high end methods and it lowers performance when creating a collection of unknown size. In LinqRewrite was created new collection based on Array with possibility to enlarge or reduce size of the collection. It is named SimpleList<T> and you can get its inner array to iterate through it with same speed as with array. Also there was developed new enlarging algorithm for reducing of allocations and increasing of speed (when is known the size of source data). Below are shown not rewritten method, method rewritten by roslyn-linq-rewrite and method rewritten by LinqRewrite.

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
    var res = Method1_ProceduralLinq1(arr, q);
}

System.Collections.Generic.List<T> Method1_ProceduralLinq1(int[] arr, int q)
{
    if (arr == null)
        throw new System.InvalidOperationException("Invalid null object");
    System.Collections.Generic.List<T> result = new System.Collections.Generic.List<T>();
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
    var res = Method1_ProceduralLinq1f8fb1c9fae84db893c40020de93beee(arr, q);
}

LinqRewrite.Core.SimpleList.SimpleList<int> Method1_ProceduralLinq1f8fb1c9fae84db893c40020de93beee(int[] arr, int q)
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

    LinqRewrite.Core.SimpleList<int> result = new LinqRewrite.Core.SimpleList<int>();
    result.Items = currentArray;
    result.Count = current;
    return result;
}
```
**New rewrite way based on array enlarging. There is more code generated, but there are fewer allocations of a new array, and a lot less bounds checks

Also there were added a lot of optimizations as lambda inlining, math simplifier, algoritm choosing according to input, expression simplifier or runtime controls disabling.

## Not rewritten
If you need to exclude a specific method, class or struct, apply a `[NoRewrite]` attribute before that method, class or struct and LinqRewriter will left it intact.
```csharp
[NoRewrite]
public void Method1()
{
    var arr = new[] { 1, 2, 3, 4 };
    var q = 2;
    var res = arr.Where(x => x > q).Select(x => x + 3).ToList();
}
```

## Further optimization

If you ensure conditions of operators you can use Unchecked() operator or UncheckedLinq attribute to disable runtime controls. Runtime controls disabling increases performance, because with provided valid data without valid checks you can create simpler algorithms. You can disable checks with Unchecked operator or UncheckedLinq attribute before method or class.

You can use grouped enumeration. In grouped enumeration are data enumerated by groups and then will be over small group of data calculated some aggregation (for example you can calculate sum of three consecutive numbers in source like source[x]+source[x+1]+source[x+2], which reduces iterations count and increases speed of simple expression). After aggregation of groups you must aggregate also the remaining elements. In code bellow is calculated sum by groups of 10.

```csharp
[Unchecked]
public int ArrayGroupedSum(int[] source)
{
    var sum = ExtendedLinq.Range(0, source.Length / 10, 10)
        .Sum(x => source.Skip(x).Take(10).Sum());
    return sum + source.Skip(source.Length / 10 * 10).Sum();
}
```

Also you can use SIMD operations (single instruction multiple data). From .NET Framework 4.6.2 and .NET Core provides support of Vector operation. When you are calculating sum, source is divided into vectors (n numbers). Size of vector depends on architecture (for example 128 bit vector). When summing int values as vector, there are taken 4 values as vector, another 4 values are added to them with increased speed. After vector summation you must sum the result vector itself and also the remaining elements, but for large amount of data it is quite effective. Example of vector summation is shown bellow. 

```csharp
[Unchecked]
public int ArraySIMDSum(int[] source)
{
    var simdLength = Vector<int>.Count;
    var vectorSum = ExtendedLinq.Range(0, source.Length / simdLength, simdLength)
        .Aggregate(Vector<int>.Zero, (x, y) => Vector.Add(x, new Vector<int>(source, y)));
        
    return Enumerable.Range(0, simdLength).Sum(i => vectorSum[i])
        + source.Skip(source.Length / simdLength * simdLength).Sum();
}
```

# Implementation

LinqRewrite starts with parser of argumets which runs one of two different modes of program. When there is lesser number of arguments than 2, there are no arguments, or there is argument -h or --help, there will be displayed help of LinqRewrite. If there are more or equal to two arguments, first argument will be processed as name of file (can be also project or solution) and LinqRewrite will rewrite the code and copy all relevant files to path specified in the second argument.

When rewriting the given code is compiled with Roslyn compiler and LinqRewrite gets the SyntaxTree and SemanticModel for rewriting (all done in CompilationService). Then CompilationService calls LinqRewriter which goes through the whole SyntaxTree of project and check if invocations should be rewritten. If it should be rewritten, it saves some data about calling of that method and calls InvocationRewriter. InvocationRewriter tries has two parts. In both parts it creates RewriteDesign by which it will create rewritten code. In the first part it calls RewriteRules and determines if the query can be rewritten as simple Expression, if it can, the invocation expression will be replaced by expression created according to RewriteDesign. If it fails the second part is done when it calls RewriteRules again and fills RewriteDesing to create method. Then according to RewriteDesing method will be added to current type and query will be replaced by invocation of that method. RewriteRules are rules for each operator of LINQ how it changes RewriteDesing. RewriteDesing is design of code creation for rewriting of query.

## Supported LINQ methods

There are not supported operators `DefaultIfEmpty`, `OrderBy`, `OrderByDescending`, `ThenBy`, `ThenbyDescending` and `ToLookup`.

# Comparsion

I created simple comparsion of LINQ implementations to LinqRewrite (more detailed comparsion is in czech thesis by Daniel Šerý .NET LINQ OPTIMIZATION for university Vysoké učení technické v Brně). In this simple comparsion is LinqFaster compared to most common LINQ implementations.

Compared to System.Linq:
* Uses external program for rewriting
* No allocations for iterators and reduces closures
* New algorithm for array enlarging
* Using more information for optimization
* Some assertions calculated when rewriting
* More constants calculated when rewriting
* Do not implement all operators
* No support for F#

Compared to LinqOptimizer:
* Code is optimized at build time (as opposed to run time), so no 30us overhead
* Uses existing LINQ syntax, no need for `AsQueryExpr()` or `Compile()`
* No allocations for `Expression<>` trees and enumerator boxing
* Parallel LINQ is not supported (i.e. left intact)
* Using a lot more information for optimization (for example different collection enumeration for different sources)
* Math optimization (without optimization of division because of different int and double division)
* New algorithm for array enlarging
* More supported operators
* No support for F#

Compared to roslyn-linq-rewrite:
* More supported operators (roslyn-linq-rewrite could rewrite only simple operators)
* Math optimization (without optimization of division because of different int and double division)
* Using a lot more information for optimization (for example different collection enumeration for different sources)
* Using more low end code (using arrays for enlarging, not List<T>)
* New algorithm for array enlarging
* Working on new project types
* Simple expressions rewrite

Compared to LinqFaster:
* Rewriting of chained operators
* When chaining operators, fewer allocations in rewritten
* Parallel LINQ is not supported (i.e. left intact)
* Inlines lambda methods and reduces closures
* Does not allocate any arrays in Source.Select(x => x + 3).Sum()
* Uses enlarging for filling array of unknown size
* LinqFaster works only on arrays
* LinqFaster implements parallel and SIMD operations
* LinqFaster not lazily evaluated
* LinqFaster different operator names than System.Linq

# Future plans
* Implement missing operators
* Improve math optimization
* Implement better support for grouping and SIMD operations
* Paralel linq
* Implement algoritm choosing
