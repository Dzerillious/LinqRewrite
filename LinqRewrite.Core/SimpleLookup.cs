﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LinqRewrite.Core
{
  /// <summary>Represents a collection of keys each mapped to one or more values.</summary>
  /// <typeparam name="TKey">The type of the keys in the <see cref="T:System.Linq.SimpleLookup`2" />.</typeparam>
  /// <typeparam name="TElement">The type of the elements of each <see cref="T:System.Collections.Generic.IEnumerable`1" /> value in the <see cref="T:System.Linq.SimpleLookup`2" />.</typeparam>
  public class SimpleLookup<TKey, TElement> : IEnumerable<IGrouping<TKey, TElement>>, IEnumerable, ILookup<TKey, TElement>
  {
    private readonly IEqualityComparer<TKey> _comparer;
    private Grouping[] _groupings;
    private Grouping _lastGrouping;
    private int _count;

    public static SimpleLookup<TKey, TElement> Create<TSource>(
      IEnumerable<TSource> source,
      Func<TSource, TKey> keySelector,
      Func<TSource, TElement> elementSelector,
      IEqualityComparer<TKey> comparer)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (keySelector == null)
        throw new ArgumentNullException(nameof (keySelector));
      if (elementSelector == null)
        throw new ArgumentNullException(nameof (elementSelector));
      var lookup = new SimpleLookup<TKey, TElement>(comparer);
      foreach (var source1 in source)
        lookup.GetGrouping(keySelector(source1), true).Add(elementSelector(source1));
      return lookup;
    }

    public static SimpleLookup<TKey, TElement> CreateForJoin(
      IEnumerable<TElement> source,
      Func<TElement, TKey> keySelector,
      IEqualityComparer<TKey> comparer)
    {
      var lookup = new SimpleLookup<TKey, TElement>(comparer);
      foreach (var element in source)
      {
        var key = keySelector(element);
        if (key != null)
          lookup.GetGrouping(key, true).Add(element);
      }
      return lookup;
    }

    public SimpleLookup(IEqualityComparer<TKey> comparer)
    {
      if (comparer == null)
        comparer = EqualityComparer<TKey>.Default;
      _comparer = comparer;
      _groupings = new Grouping[7];
    }

    /// <summary>Gets the number of key/value collection pairs in the <see cref="T:System.Linq.SimpleLookup`2" />.</summary>
    /// <returns>The number of key/value collection pairs in the <see cref="T:System.Linq.SimpleLookup`2" />.</returns>
    public int Count => _count;

    /// <summary>Gets the collection of values indexed by the specified key.</summary>
    /// <param name="key">The key of the desired collection of values.</param>
    /// <returns>The collection of values indexed by the specified key.</returns>
    public IEnumerable<TElement> this[TKey key] => GetGrouping(key, false) ?? Enumerable.Empty<TElement>();

    /// <summary>Determines whether a specified key is in the <see cref="T:System.Linq.SimpleLookup`2" />.</summary>
    /// <param name="key">The key to find in the <see cref="T:System.Linq.SimpleLookup`2" />.</param>
    /// <returns>
    /// <see langword="true" /> if <paramref name="key" /> is in the <see cref="T:System.Linq.SimpleLookup`2" />; otherwise, <see langword="false" />.</returns>
    public bool Contains(TKey key) => GetGrouping(key, false) != null;

    /// <summary>Returns a generic enumerator that iterates through the <see cref="T:System.Linq.SimpleLookup`2" />.</summary>
    /// <returns>An enumerator for the <see cref="T:System.Linq.SimpleLookup`2" />.</returns>
    public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
    {
      var g = _lastGrouping;
      if (g == null) yield break;
      do
      {
        g = g.next;
        yield return g;
      }
      while (g != _lastGrouping);
    }

    /// <summary>Applies a transform function to each key and its associated values and returns the results.</summary>
    /// <param name="resultSelector">A function to project a result value from each key and its associated values.</param>
    /// <typeparam name="TResult">The type of the result values produced by <paramref name="resultSelector" />.</typeparam>
    /// <returns>A collection that contains one value for each key/value collection pair in the <see cref="T:System.Linq.SimpleLookup`2" />.</returns>
    public IEnumerable<TResult> ApplyResultSelector<TResult>(
      Func<TKey, IEnumerable<TElement>, TResult> resultSelector)
    {
      var g = _lastGrouping;
      if (g == null) yield break;
      do
      {
        g = g.next;
        if (g.count != g.elements.Length)
          Array.Resize(ref g.elements, g.count);
        yield return resultSelector(g.key, g.elements);
      }
      while (g != _lastGrouping);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public int InternalGetHashCode(TKey key) => (object) key != null ? _comparer.GetHashCode(key) & int.MaxValue : 0;

    public Grouping GetGrouping(TKey key, bool create)
    {
      var hashCode = InternalGetHashCode(key);
      for (var grouping = _groupings[hashCode % _groupings.Length]; grouping != null; grouping = grouping.hashNext)
      {
        if (grouping.hashCode == hashCode && _comparer.Equals(grouping.key, key))
          return grouping;
      }
      if (!create)
        return null;
      if (_count == _groupings.Length)
        Resize();
      var index = hashCode % _groupings.Length;
      var grouping1 = new Grouping
      {
        key = key, hashCode = hashCode, elements = new TElement[1], hashNext = _groupings[index]
      };
      _groupings[index] = grouping1;
      if (_lastGrouping == null)
      {
        grouping1.next = grouping1;
      }
      else
      {
        grouping1.next = _lastGrouping.next;
        _lastGrouping.next = grouping1;
      }
      _lastGrouping = grouping1;
      ++_count;
      return grouping1;
    }

    private void Resize()
    {
      var length = checked (_count * 2 + 1);
      var groupingArray = new Grouping[length];
      var grouping = _lastGrouping;
      do
      {
        grouping = grouping.next;
        var index = grouping.hashCode % length;
        grouping.hashNext = groupingArray[index];
        groupingArray[index] = grouping;
      }
      while (grouping != _lastGrouping);
      _groupings = groupingArray;
    }

    public class Grouping : IGrouping<TKey, TElement>, IList<TElement>
    {
      public TKey key;
      public int hashCode;
      public TElement[] elements;
      public int count;
      public Grouping hashNext;
      public Grouping next;

      public void Add(TElement element)
      {
        if (elements.Length == count)
          Array.Resize(ref elements, checked (count * 2));
        elements[count] = element;
        ++count;
      }

      public IEnumerator<TElement> GetEnumerator()
      {
        for (var i = 0; i < count; ++i)
          yield return elements[i];
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
        return GetEnumerator();
      }

      public TKey Key => key;

      int ICollection<TElement>.Count => count;

      bool ICollection<TElement>.IsReadOnly => true;

      void ICollection<TElement>.Add(TElement item)
        => throw new NotSupportedException();

      void ICollection<TElement>.Clear() => throw new NotSupportedException();

      bool ICollection<TElement>.Contains(TElement item) 
        => Array.IndexOf(elements, item, 0, count) >= 0;

      void ICollection<TElement>.CopyTo(TElement[] array, int arrayIndex)
        => Array.Copy(elements, 0, array, arrayIndex, count);

      bool ICollection<TElement>.Remove(TElement item)
        => throw new NotSupportedException();

      int IList<TElement>.IndexOf(TElement item)
        => Array.IndexOf(elements, item, 0, count);

      void IList<TElement>.Insert(int index, TElement item)
        => throw new NotSupportedException();

      void IList<TElement>.RemoveAt(int index)
        => throw new NotSupportedException();

      TElement IList<TElement>.this[int index]
      {
        get
        {
          if (index < 0 || index >= count)
            throw new ArgumentOutOfRangeException(nameof (index));
          return elements[index];
        }
        set => throw new NotSupportedException();
      }
    }
  }
}