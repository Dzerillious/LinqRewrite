|                                Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|               ArrayElementAtOrDefault |  34.6149 ns | 0.7239 ns | 0.9155 ns |      - |     - |     - |         - |
|      ArrayElementAtOrDefaultRewritten |   0.2404 ns | 0.0265 ns | 0.0248 ns |      - |     - |     - |         - |
|          ArrayWhereElementAtOrDefault | 292.8882 ns | 5.7771 ns | 5.4039 ns | 0.0076 |     - |     - |      32 B |
| ArrayWhereElementAtOrDefaultRewritten |  95.1294 ns | 1.5082 ns | 1.4108 ns |      - |     - |     - |         - |
|          EnumerableElementAtOrDefault | 213.4596 ns | 3.0318 ns | 2.8360 ns | 0.0057 |     - |     - |      24 B |
| EnumerableElementAtOrDefaultRewritten | 200.4659 ns | 3.9646 ns | 4.8689 ns | 0.0057 |     - |     - |      24 B |