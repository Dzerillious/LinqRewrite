|                       Method |        Mean |     Error |    StdDev |
|----------------------------- |------------:|----------:|----------:|
|               ArrayElementAt |  34.3646 ns | 0.1781 ns | 0.1579 ns |
|      ArrayElementAtRewritten |   0.0208 ns | 0.0139 ns | 0.0130 ns | x1500
|          ArrayWhereElementAt | 369.3647 ns | 2.5993 ns | 2.0293 ns |
| ArrayWhereElementAtRewritten |  73.0300 ns | 0.4852 ns | 0.4538 ns | x5
|          EnumerableElementAt | 215.5690 ns | 0.8717 ns | 0.8154 ns |
| EnumerableElementAtRewritten | 184.8089 ns | 1.5025 ns | 1.4054 ns | x1.15