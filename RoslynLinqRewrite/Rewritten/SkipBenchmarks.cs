// using System.Collections.Generic;
// using System.Linq;
// using BenchmarkDotNet.Attributes;
// using LinqRewrite.Core;
// using LinqRewrite.Core.SimpleList;
//
// namespace BenchmarkLibrary
// {
//     public class SkipBenchmarks
//     {
//         public int[] ArraySource;
//         public IEnumerable<int> EnumerableSource;
//
//         [GlobalSetup]
//         public void GlobalSetup()
//         {
//             ArraySource = Enumerable.Range(0, 1000).ToArray();
//             EnumerableSource = Enumerable.Range(0, 1000);
//         }
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArrayUnchecked()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).Take(0).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayUncheckedRewritten()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).Take(0).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArray()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).Take(0).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayRewritten()
//         {
//             var res = ArraySource.Select(x => x + 2).Skip(900).Take(0).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArrayUnchecked1()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Take(1).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayUncheckedRewritten1()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).Take(1).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArray1()
//         {
//             var res = ArraySource.Select(x => x + 2).Skip(900).Take(1).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayRewritten1()
//         {
//             var res = ArraySource.Select(x => x + 2).Skip(900).Take(1).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArrayUnchecked10()
//         {
//             var res = ArraySource.Skip(900).Unchecked().Take(10).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayUncheckedRewritten10()
//         {
//             var res = ArraySource.Skip(900).Unchecked().Take(10).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArray10()
//         {
//             var res = ArraySource.Skip(900).Take(10).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayRewritten10()
//         {
//             var res = ArraySource.Skip(900).Take(10).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArrayUnchecked20()
//         {
//             var res = ArraySource.Skip(900).Unchecked().Take(20).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayUncheckedRewritten20()
//         {
//             var res = ArraySource.Skip(900).Unchecked().Take(20).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArray20()
//         {
//             var res = ArraySource.Select(x => x + 2).Skip(900).Take(20).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayRewritten20()
//         {
//             var res = ArraySource.Select(x => x + 2).Skip(900).Take(20).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArrayUnchecked100()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).Take(100).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayUncheckedRewritten100()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).Take(100).ToArray();
//         } //EndMethod
//
//
//         [NoRewrite, Benchmark]
//         public void SkipTakeToArray100()
//         {
//             var res = ArraySource.Unchecked().Skip(900).Take(100).ToArray();
//         } //EndMethod
//
//         [Benchmark]
//         public void SkipTakeToArrayRewritten100()
//         {
//             var res = ArraySource.Unchecked().Select(x => x + 2).Skip(900).Take(100).ToArray();
//         } //EndMethod
//
//     }
// }
//
