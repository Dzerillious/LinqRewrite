

using System;
using System.Collections.Generic;
using LinqRewrite.Core.SimpleList;

namespace LinqRewrite.Core.SimpleLinq
{
    public static class SimpleListLinq
    {
        public static TResult[] SimpleSelect<TSource, TResult>(this SimpleList<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;

            var result = new TResult[sourceCount];
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                result[i] = selector(source[i]);
                result[i+1] = selector(source[i+1]);
                result[i+2] = selector(source[i+2]);
                result[i+3] = selector(source[i+3]);
            }
            for (; i < sourceCount; i++)
                result[i] = selector(source[i]);
            return result;
        }
        
        public static SimpleList<T> SimpleWhere<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            var result = new T[8];
            var length = 8;
            var count = 0;
            int log = IntExtensions.Log2((uint) sourceCount) - 3;
            log = log > 2 ? (log - (log % 2)) : 2;
            
            for (int i = 0; i < sourceCount; i++)
            {
                if (!predicate(source[i])) continue;
                if (count >= length)
                    EnlargeExtensions.LogEnlargeArray(2, sourceCount, ref result, ref log, out length);
                result[count] = source[i];
                count++;
            }
            var final = new SimpleList<T>();
            final.Items = result;
            final.Count = count;
            return final;
        }
        
        public static SimpleList<T> SimpleTakeWhile<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            var result = new T[8];
            var length = 8;
            var count = 0;
            int log = IntExtensions.Log2((uint) sourceCount) - 3;
            log = log > 2 ? (log - (log % 2)) : 2;
            
            for (int i = 0; i < sourceCount; i++)
            {
                if (!predicate(source[i])) break;
                if (count >= length)
                    EnlargeExtensions.LogEnlargeArray(2, sourceCount, ref result, ref log, out length);
                result[count] = source[i];
                count++;
            }
            var final = new SimpleList<T>();
            final.Items = result;
            final.Count = count;
            return final;
        }

        public static T[] SimpleSkip<T>(this SimpleList<T> source, int count)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            if (count <= 0) return source.ToArray();
            if (count >= source.Count) 
#if (NET40 || NET45)
            return SimpleList<T>.Empty;
#else
            return Array.Empty<T>();
#endif
            
            var result = new T[source.Count - count];
            for (var i = 0; i < result.Length; i++)
                result[i] = source[i + count];
            return result;
        }

        public static T[] SimpleTake<T>(this SimpleList<T> source, int count)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            if (count <= 0) 
#if (NET40 || NET45)
            return SimpleList<T>.Empty;
#else
            return Array.Empty<T>();
#endif
            if (count >= source.Count) return source.ToArray();
            
            var result = new T[count];
            for (var i = 0; i < count; i++)
                result[i] = source[i];
            return result;
        }

        public static T[] SimpleSkipTake<T>(this SimpleList<T> source, int skip, int take)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            if (skip <= 0) return SimpleTake(source, take);
            if (skip >= source.Count || take <= 0) 
#if (NET40 || NET45)
            return SimpleList<T>.Empty;
#else
            return Array.Empty<T>();
#endif
            if (skip + take >= source.Count) take = source.Count - skip;
            
            var result = new T[take];
            for (var i = 0; i < take; i++)
                result[i] = source[i + skip];
            return result;
        }

        public static SimpleList<T> SimpleSkipWhile<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            var result = new T[8];
            var length = 8;
            var count = 0;
            int log = IntExtensions.Log2((uint) sourceCount) - 3;
            log = log > 2 ? (log - (log % 2)) : 2;
            var i = 0;
            
            for (; i < sourceCount; i++)
                if (!predicate(source[i])) break;
            for (; i < sourceCount; i++)
            {
                if (count >= length)
                    EnlargeExtensions.LogEnlargeArray(2, sourceCount, ref result, ref log, out length);
                result[count] = source[i];
                count++;
            }
            var final = new SimpleList<T>();
            final.Items = result;
            final.Count = count;
            return final;
        }
        
        public static int SimpleSum(this SimpleList<int> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += source[i];
                sum += source[i+1];
                sum += source[i+2];
                sum += source[i+3];
            }
            for (; i < sourceCount; i++)
                sum += source[i];
            return sum;
        }
        
        public static double SimpleSum(this SimpleList<double> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            double sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += source[i];
                sum += source[i+1];
                sum += source[i+2];
                sum += source[i+3];
            }
            for (; i < sourceCount; i++)
                sum += source[i];
            return sum;
        }
        
        public static decimal SimpleSum(this SimpleList<decimal> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            decimal sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += source[i];
                sum += source[i+1];
                sum += source[i+2];
                sum += source[i+3];
            }
            for (; i < sourceCount; i++)
                sum += source[i];
            return sum;
        }
        
        public static int SimpleSum<T>(this SimpleList<T> source, Func<T, int> selector)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += selector(source[i]);
                sum += selector(source[i+1]);
                sum += selector(source[i+2]);
                sum += selector(source[i+3]);
            }
            for (; i < sourceCount; i++)
                sum += selector(source[i]);
            return sum;
        }
        
        public static double SimpleSum<T>(this SimpleList<T> source, Func<T, double> selector)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            double sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += selector(source[i]);
                sum += selector(source[i+1]);
                sum += selector(source[i+2]);
                sum += selector(source[i+3]);
            }
            for (; i < sourceCount; i++)
                sum += selector(source[i]);
            return sum;
        }
        
        public static decimal SimpleSum<T>(this SimpleList<T> source, Func<T, decimal> selector)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            decimal sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += selector(source[i]);
                sum += selector(source[i+1]);
                sum += selector(source[i+2]);
                sum += selector(source[i+3]);
            }
            for (; i < sourceCount; i++)
                sum += selector(source[i]);
            return sum;
        }
        
        public static T SimpleAggregate<T>(this SimpleList<T> source, Func<T, T, T> aggregation)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            T aggregate = default;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                aggregate = aggregation(aggregate, source[i]);
                aggregate = aggregation(aggregate, source[i+1]);
                aggregate = aggregation(aggregate, source[i+2]);
                aggregate = aggregation(aggregate, source[i+3]);
            }
            for (; i < sourceCount; i++)
                aggregate = aggregation(aggregate, source[i]);
            return aggregate;
        }
        
        public static T SimpleAggregate<T>(this SimpleList<T> source, T seed, Func<T, T, T> aggregation)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            T aggregate = seed;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                aggregate = aggregation(aggregate, source[i]);
                aggregate = aggregation(aggregate, source[i+1]);
                aggregate = aggregation(aggregate, source[i+2]);
                aggregate = aggregation(aggregate, source[i+3]);
            }
            for (; i < sourceCount; i++)
                aggregate = aggregation(aggregate, source[i]);
            return aggregate;
        }
        
        public static int SimpleCount<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int count = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (predicate(source[i])) count++;
                if (predicate(source[i+1])) count++;
                if (predicate(source[i+2])) count++;
                if (predicate(source[i+3])) count++;
            }
            for (; i < sourceCount; i++)
                if (predicate(source[i])) count++;
            return count;
        }
        
        public static long SimpleLongCount<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            long count = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (predicate(source[i])) count++;
                if (predicate(source[i+1])) count++;
                if (predicate(source[i+2])) count++;
                if (predicate(source[i+3])) count++;
            }
            for (; i < sourceCount; i++)
                if (predicate(source[i])) count++;
            return count;
        }
        
        public static bool SimpleAll<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (!predicate(source[i])) return false;
                if (!predicate(source[i+1])) return false;
                if (!predicate(source[i+2])) return false;
                if (!predicate(source[i+3])) return false;
            }
            for (; i < sourceCount; i++)
                if (!predicate(source[i])) return false;
            return true;
        }

        public static bool SimpleAny<T>(this SimpleList<T> source)
            => source.Count > 0;
        
        public static bool SimpleAny<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (predicate(source[i])) return true;
                if (predicate(source[i+1])) return true;
                if (predicate(source[i+2])) return true;
                if (predicate(source[i+3])) return true;
            }
            for (; i < sourceCount; i++)
                if (predicate(source[i])) return true;
            return false;
        }
        
        public static double SimpleAverage(this SimpleList<int> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            int sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += source[i];
                sum += source[i+1];
                sum += source[i+2];
                sum += source[i+3];
            }
            for (; i < sourceCount; i++)
                sum += source[i];
            return (double)sum / sourceCount;
        }
        
        public static double SimpleAverage(this SimpleList<double> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            double sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += source[i];
                sum += source[i+1];
                sum += source[i+2];
                sum += source[i+3];
            }
            for (; i < sourceCount; i++)
                sum += source[i];
            return sum / sourceCount;
        }
        
        public static decimal SimpleAverage(this SimpleList<decimal> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            decimal sum = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                sum += source[i];
                sum += source[i+1];
                sum += source[i+2];
                sum += source[i+3];
            }
            for (; i < sourceCount; i++)
                sum += source[i];
            return sum / sourceCount;
        }
        
        public static T[] SimpleConcat<T>(this SimpleList<T> source1, SimpleList<T> source2)
        {
            if (source1 == null || source2 == null) throw new InvalidOperationException("Invalid null object");

            var result = new T[source1.Count + source2.Count];
            Array.Copy(source1.Items, 0, result, 0, source1.Count);
            Array.Copy(source2.Items, source1.Count, result, 0, source2.Count);
            return result;
        }
        
        public static bool SimpleContains<T>(this SimpleList<T> source, T element)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i].Equals(element)) return true;
                if (source[i+1].Equals(element)) return true;
                if (source[i+2].Equals(element)) return true;
                if (source[i+3].Equals(element)) return true;
            }
            for (; i < sourceCount; i++)
                if (source[i].Equals(element)) return true;
            return false;
        }
        
        public static int SimpleIndexOf<T>(this SimpleList<T> source, T element)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i].Equals(element)) return i;
                if (source[i+1].Equals(element)) return i;
                if (source[i+2].Equals(element)) return i;
                if (source[i+3].Equals(element)) return i;
            }
            for (; i < sourceCount; i++)
                if (source[i].Equals(element)) return i;
            return -1;
        }
        
        public static int SimpleIndexOf<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (predicate(source[i])) return i;
                if (predicate(source[i+1])) return i;
                if (predicate(source[i+2])) return i;
                if (predicate(source[i+3])) return i;
            }
            for (; i < sourceCount; i++)
                if (predicate(source[i])) return i;
            return -1;
        }

        public static T First<T>(this SimpleList<T> source) => source[0];
        public static T First<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (predicate(source[i])) return source[i];
                if (predicate(source[i+1])) return source[i+1];
                if (predicate(source[i+2])) return source[i+2];
                if (predicate(source[i+3])) return source[i+3];
            }
            for (; i < sourceCount; i++)
                if (predicate(source[i])) return source[i];
            throw new IndexOutOfRangeException("No matching element");
        }
        
        public static T FirstOrDefault<T>(this SimpleList<T> source) => source.Count > 0 ? source[0] : default;
        public static T FirstOrDefault<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (predicate(source[i])) return source[i];
                if (predicate(source[i+1])) return source[i+1];
                if (predicate(source[i+2])) return source[i+2];
                if (predicate(source[i+3])) return source[i+3];
            }
            for (; i < sourceCount; i++)
                if (predicate(source[i])) return source[i];
            return default;
        }
        
        public static T Last<T>(this SimpleList<T> source) => source[source.Count - 1];
        public static T Last<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = sourceCount - 1;
            for (; i - 3 >= 0; i -= 4)
            {
                if (predicate(source[i])) return source[i];
                if (predicate(source[i-1])) return source[i-1];
                if (predicate(source[i-2])) return source[i-2];
                if (predicate(source[i-3])) return source[i-3];
            }
            for (; i >= 0; i--)
                if (predicate(source[i])) return source[i];
            throw new IndexOutOfRangeException("No matching element");
        }
        
        public static T LastOrDefault<T>(this SimpleList<T> source) => source.Count > 0 ? source[source.Count - 1] : default;
        public static T LastOrDefault<T>(this SimpleList<T> source, Func<T, bool> predicate)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            
            int i = sourceCount - 1;
            for (; i - 3 >= 0; i -= 4)
            {
                if (predicate(source[i])) return source[i];
                if (predicate(source[i-1])) return source[i-1];
                if (predicate(source[i-2])) return source[i-2];
                if (predicate(source[i-3])) return source[i-3];
            }
            for (; i >= 0; i--)
                if (predicate(source[i])) return source[i];
            return default;
        }
        
        public static int SimpleMax(this SimpleList<int> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            int i = 0;
            int max = int.MinValue;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i] > max) max = source[i];
                if (source[i+1] > max) max = source[i+1];
                if (source[i+2] > max) max = source[i+2];
                if (source[i+3] > max) max = source[i+3];
            }
            for (; i < sourceCount; i++)
                if (source[i] > max) max = source[i];
            return max;
        }
        
        public static double SimpleMax(this SimpleList<double> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            int i = 0;
            double max = double.MinValue;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i] > max) max = source[i];
                if (source[i+1] > max) max = source[i+1];
                if (source[i+2] > max) max = source[i+2];
                if (source[i+3] > max) max = source[i+3];
            }
            for (; i < sourceCount; i++)
                if (source[i] > max) max = source[i];
            return max;
        }
        
        public static decimal SimpleMax(this SimpleList<decimal> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            int i = 0;
            decimal max = decimal.MinValue;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i] > max) max = source[i];
                if (source[i+1] > max) max = source[i+1];
                if (source[i+2] > max) max = source[i+2];
                if (source[i+3] > max) max = source[i+3];
            }
            for (; i < sourceCount; i++)
                if (source[i] > max) max = source[i];
            return max;
        }
        
        public static int SimpleMin(this SimpleList<int> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            int i = 0;
            int min = int.MaxValue;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i] < min) min = source[i];
                if (source[i+1] < min) min = source[i+1];
                if (source[i+2] < min) min = source[i+2];
                if (source[i+3] < min) min = source[i+3];
            }
            for (; i < sourceCount; i++)
                if (source[i] < min) min = source[i];
            return min;
        }
        
        public static double SimpleMin(this SimpleList<double> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            int i = 0;
            double min = int.MaxValue;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i] < min) min = source[i];
                if (source[i+1] < min) min = source[i+1];
                if (source[i+2] < min) min = source[i+2];
                if (source[i+3] < min) min = source[i+3];
            }
            for (; i < sourceCount; i++)
                if (source[i] < min) min = source[i];
            return min;
        }
        
        public static decimal SimpleMin(this SimpleList<decimal> source)
        {
            if (source == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source.Count;
            if (sourceCount <= 0) throw new InvalidOperationException("Invalid empty source");
            
            int i = 0;
            decimal min = int.MaxValue;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (source[i] < min) min = source[i];
                if (source[i+1] < min) min = source[i+1];
                if (source[i+2] < min) min = source[i+2];
                if (source[i+3] < min) min = source[i+3];
            }
            for (; i < sourceCount; i++)
                if (source[i] < min) min = source[i];
            return min;
        }
        
        public static bool SimpleSequenceEquals<T>(this SimpleList<T> source1, SimpleList<T> source2)
        {
            if (source1 == null || source2 == null) throw new InvalidOperationException("Invalid null object");
            var sourceCount = source1.Count;
            if (sourceCount != source2.Count) return false;
            
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                if (!source1[i].Equals(source2[i])) return false;
                if (!source1[i+1].Equals(source2[i+1])) return false;
                if (!source1[i+2].Equals(source2[i+2])) return false;
                if (!source1[i+3].Equals(source2[i+3])) return false;
            }
            for (; i < sourceCount; i++)
                if (!source1[i].Equals(source2[i])) return false;
            return true;
        }
        
        public static TResult[] SimpleSelectMany<TSource, TResult>(this IList<TSource> source, Func<TSource, SimpleList<TResult>> selector)
        {
            if (source == null || selector == null) throw new InvalidOperationException("Invalid null object");
            int sourceCount = source.Count;
            var tmpResult = new SimpleList<TResult>[sourceCount];
            int resultCount = 0;
            int i = 0;
            for (; i + 3 < sourceCount; i += 4)
            {
                tmpResult[i] = selector(source[i]);
                tmpResult[i+1] = selector(source[i+1]);
                tmpResult[i+2] = selector(source[i+2]);
                tmpResult[i+3] = selector(source[i+3]);
                resultCount += tmpResult[i].Count + tmpResult[i+1].Count + tmpResult[i+2].Count + tmpResult[i+3].Count;
            }

            for (; i < sourceCount; i++)
            {
                tmpResult[i] = selector(source[i]);
                resultCount += tmpResult[i].Count;
            }
            var result = new TResult[resultCount];
            var copyIndex = 0;
            for (var j = 0; j < tmpResult.Length; j++)
            {
                Array.Copy(tmpResult[j].Items, 0, result, copyIndex, tmpResult[j].Count);
                copyIndex += tmpResult[j].Count;
            }
            return result;
        }

        public static bool IsNullOrEmpty<T>(this SimpleList<T> source)
            => source == null || source.Count == 0;
    }
}