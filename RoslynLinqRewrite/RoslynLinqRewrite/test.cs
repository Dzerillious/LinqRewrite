using System.Linq;
using System.Collections.Generic;

static class Example2
{
    static void Main()
    {
		var arr = new int[10];
		var a = 4;
		var test = arr.Where(x => x > 3).Concat(arr.Select(x => x + 2)).ToArray();
    }
}