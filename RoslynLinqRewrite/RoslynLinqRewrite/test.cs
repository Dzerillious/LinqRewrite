using System.Linq;
using System.Collections.Generic;

class Example2
{
	public int Method1()
	{
		var arr = new[] { 1, 2, 3, 4 };
		var q = 2;
		return arr.Where(x => x > q).Select(x => x + 3).Sum();
	}
}