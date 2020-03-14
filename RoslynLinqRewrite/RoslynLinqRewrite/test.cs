using System.Linq;

class Example2
{
	public void Method1()
	{
		var arr = new[] { 1, 2, 3, 4 }.AsEnumerable();
		arr.Aggregate((x, y) => x + y);
	}
}