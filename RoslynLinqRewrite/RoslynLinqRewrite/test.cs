using System.Linq;
using System.Collections.Generic;

static class Example2
{
    static void Main()
    {
		var arr = new int[10].AsEnumerable();
		var add = 3;
		var test = arr.Select((x, i) => x + add).ToArray();
    }
}