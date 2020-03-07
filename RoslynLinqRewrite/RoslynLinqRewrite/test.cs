using System.Linq;
using System.Collections.Generic;

static class Example2
{
    static void Main()
    {
		var arr = new int[10];
		var arr2 = new int[10].AsEnumerable();
		var test = arr.Skip(20).ToArray();
    }
}