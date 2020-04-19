|                                Method |        Mean |     Error |    StdDev |
|-------------------------------------- |------------:|----------:|----------:|
|               ArrayElementAtOrDefault |  37.0110 ns | 0.2752 ns | 0.2574 ns |
|      ArrayElementAtOrDefaultRewritten |   0.2773 ns | 0.0097 ns | 0.0090 ns | x150
|          ArrayWhereElementAtOrDefault | 310.7626 ns | 1.7834 ns | 1.5809 ns |
| ArrayWhereElementAtOrDefaultRewritten |  61.2799 ns | 0.5844 ns | 0.5466 ns | x5
|          EnumerableElementAtOrDefault | 225.5763 ns | 0.8343 ns | 0.7804 ns |
| EnumerableElementAtOrDefaultRewritten | 209.7668 ns | 1.0994 ns | 1.0284 ns | x1.1