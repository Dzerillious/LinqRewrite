using System;
using System.Collections.Generic;

namespace LinqRewrite.Core
{
  public class Set<TElement>
  {
    private int[] _buckets;
    private Slot[] _slots;
    private int _count;
    private int _freeList;
    private IEqualityComparer<TElement> _comparer;

    public Set()
      : this(null)
    {
    }

    public Set(IEqualityComparer<TElement> comparer)
    {
      if (comparer == null)
        comparer = EqualityComparer<TElement>.Default;
      _comparer = comparer;
      _buckets = new int[7];
      _slots = new Slot[7];
      _freeList = -1;
    }

    public bool Add(TElement value)
    {
      return !Find(value, true);
    }

    public bool Contains(TElement value)
    {
      return Find(value, false);
    }

    public bool Remove(TElement value)
    {
      int hashCode = PublicGetHashCode(value);
      int index1 = hashCode % _buckets.Length;
      int index2 = -1;
      for (int index3 = _buckets[index1] - 1; index3 >= 0; index3 = _slots[index3].next)
      {
        if (_slots[index3].hashCode == hashCode && _comparer.Equals(_slots[index3].value, value))
        {
          if (index2 < 0) _buckets[index1] = _slots[index3].next + 1;
          else _slots[index2].next = _slots[index3].next;
          
          _slots[index3].hashCode = -1;
          _slots[index3].value = default;
          _slots[index3].next = _freeList;
          _freeList = index3;
          return true;
        }
        index2 = index3;
      }
      return false;
    }

    private bool Find(TElement value, bool add)
    {
      int hashCode = PublicGetHashCode(value);
      for (int index = _buckets[hashCode % _buckets.Length] - 1; index >= 0; index = _slots[index].next)
      {
        if (_slots[index].hashCode == hashCode && _comparer.Equals(_slots[index].value, value))
          return true;
      }
      if (add)
      {
        int index1;
        if (_freeList >= 0)
        {
          index1 = _freeList;
          _freeList = _slots[index1].next;
        }
        else
        {
          if (_count == _slots.Length)
            Resize();
          index1 = _count;
          ++_count;
        }
        int index2 = hashCode % _buckets.Length;
        _slots[index1].hashCode = hashCode;
        _slots[index1].value = value;
        _slots[index1].next = _buckets[index2] - 1;
        _buckets[index2] = index1 + 1;
      }
      return false;
    }

    private void Resize()
    {
      int length = checked (_count * 2 + 1);
      int[] numArray = new int[length];
      Slot[] slotArray = new Slot[length];
      Array.Copy(_slots, 0, slotArray, 0, _count);
      for (int index1 = 0; index1 < _count; ++index1)
      {
        int index2 = slotArray[index1].hashCode % length;
        slotArray[index1].next = numArray[index2] - 1;
        numArray[index2] = index1 + 1;
      }
      _buckets = numArray;
      _slots = slotArray;
    }

    public int PublicGetHashCode(TElement value)
    {
      return (object) value != null ? _comparer.GetHashCode(value) & int.MaxValue : 0;
    }

    public struct Slot
    {
      public int hashCode;
      public TElement value;
      public int next;
    }
  }
}