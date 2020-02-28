using System.Linq;
using System.Collections.Generic;

static class Example2
{
    static void Main()
    {
		var arr = new int[10].AsEnumerable();
		var arr2 = new int[10];
		var test = arr.Concat(arr2).ToArray();
    }
}