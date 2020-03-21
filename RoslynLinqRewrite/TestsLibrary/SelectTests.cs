using System.Collections.Generic;
using System.Linq;
using LinqRewrite.DataStructures;
using NUnit.Framework;

namespace TestsLibrary
{
    public class SelectTests
    {
        [Datapoints] public int[] ArraySource = Enumerable.Range(1, 100).ToArray();
        [Datapoints] public static IEnumerable<int> StaticSource = Enumerable.Range(1, 100);
        [Datapoints] public IEnumerable<int> EnumerableSource = Enumerable.Range(1, 100);
        public int Selector(int a) => a + 3;
        
        public void TestSelect()
        {
            Select1().WriteCollectionEquals(nameof(Select1), Select1Rewritten());
            Select2().WriteCollectionEquals(nameof(Select2), Select2Rewritten());
            Select3().WriteCollectionEquals(nameof(Select3), Select3Rewritten());
            Select4().WriteCollectionEquals(nameof(Select4), Select4Rewritten());
            Select5().WriteCollectionEquals(nameof(Select5), Select5Rewritten());
            Select6().WriteCollectionEquals(nameof(Select6), Select6Rewritten());
            Select7().WriteCollectionEquals(nameof(Select7), Select7Rewritten());
            Select8().WriteCollectionEquals(nameof(Select8), Select8Rewritten());
            Select9().WriteCollectionEquals(nameof(Select9), Select9Rewritten());
            Select10().WriteCollectionEquals(nameof(Select10), Select10Rewritten());
            Select11().WriteCollectionEquals(nameof(Select11), Select11Rewritten());
            Select12().WriteCollectionEquals(nameof(Select12), Select12Rewritten());
            SelectStatic.Select13().WriteCollectionEquals(nameof(SelectStatic.Select13), SelectStatic.Select13Rewritten());
            SelectStatic.Select14().WriteCollectionEquals(nameof(SelectStatic.Select14), SelectStatic.Select14Rewritten());
        }

        [NoRewrite]
        public IEnumerable<int> Select1()
        {
            return ArraySource.Select(x => x + 2);
        }

        [NoRewrite]
        public IEnumerable<int> Select2()
        {
            return EnumerableSource.Select(x => x + 2);
        }

        [NoRewrite]
        public IEnumerable<int> Select3()
        {
            return StaticSource.Select(x => x + 2);
        }

        [NoRewrite]
        public IEnumerable<int> Select4()
        {
            return ArraySource.Select(Selector);
        }

        [NoRewrite]
        public IEnumerable<int> Select5()
        {
            return StaticSource.Select(Selector);
        }

        [NoRewrite]
        public IEnumerable<IEnumerable<int>> Select6()
        {
            return ArraySource.Select(x => ArraySource);
        }

        [NoRewrite]
        public IEnumerable<int> Select7()
        {
            return ArraySource
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3);
        }

        [NoRewrite]
        public IEnumerable<int> Select8()
        {
            return ArraySource
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x);
        }

        [NoRewrite]
        public IEnumerable<int> Select9()
        {
            var ext = 5;
            return ArraySource.Select(x => x + ext);
        }

        [NoRewrite]
        public IEnumerable<int> Select10()
        {
            var ext = 2;
            var ext1 = 3;
            var ext2 = 4;
            var ext3 = 5;
            var ext4 = 6;
            return ArraySource.Select(x => x * ext + ext1 * ext2 + ext3 + ext4);
        }

        [NoRewrite]
        public IEnumerable<int> Select11()
        {
            var collection = Enumerable.Range(0, 100);
            return collection.Select(x => x + 5);
        }

        [NoRewrite]
        public static IEnumerable<int> Select12()
        {
            return StaticSource.Select(x => x + 5);
        }

        
        public IEnumerable<int> Select1Rewritten()
        {
            return ArraySource.Select(x => x + 2);
        }

        public IEnumerable<int> Select2Rewritten()
        {
            return EnumerableSource.Select(x => x + 2);
        }

        public IEnumerable<int> Select3Rewritten()
        {
            return StaticSource.Select(x => x + 2);
        }

        public IEnumerable<int> Select4Rewritten()
        {
            return ArraySource.Select(Selector);
        }

        public IEnumerable<int> Select5Rewritten()
        {
            return StaticSource.Select(Selector);
        }

        public IEnumerable<IEnumerable<int>> Select6Rewritten()
        {
            return ArraySource.Select(x => ArraySource);
        }

        public IEnumerable<int> Select7Rewritten()
        {
            return ArraySource
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3)
                .Select(x => x + 3);
        }

        public IEnumerable<int> Select8Rewritten()
        {
            return ArraySource
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x)
                .Select(x => x + x);
        }

        public IEnumerable<int> Select9Rewritten()
        {
            var ext = 5;
            return ArraySource.Select(x => x + ext);
        }

        public IEnumerable<int> Select10Rewritten()
        {
            var ext = 2;
            var ext1 = 3;
            var ext2 = 4;
            var ext3 = 5;
            var ext4 = 6;
            return ArraySource.Select(x => x * ext + ext1 * ext2 + ext3 + ext4);
        }

        public IEnumerable<int> Select11Rewritten()
        {
            var collection = Enumerable.Range(0, 100);
            return collection.Select(x => x + 5);
        }

        public static IEnumerable<int> Select12Rewritten()
        {
            return StaticSource.Select(x => x + 5);
        }
    }

    public static class SelectStatic
    {
        [Datapoints] public static IEnumerable<int> StaticSource = Enumerable.Range(1, 100);

        [NoRewrite]
        public static IEnumerable<int> Select13()
        {
            var collection = Enumerable.Range(0, 100);
            return collection.Select(x => x + 5);
        }
        
        [NoRewrite]
        public static IEnumerable<int> Select14()
        {
            return StaticSource.Select(x => x + 2);
        } 
        
        public static IEnumerable<int> Select13Rewritten()
        {
            var collection = Enumerable.Range(0, 100);
            return collection.Select(x => x + 5);
        }
        
        public static IEnumerable<int> Select14Rewritten()
        {
            return StaticSource.Select(x => x + 2);
        }
    }
}