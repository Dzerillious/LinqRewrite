|                                Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|               ArrayElementAtOrDefault |  35.5207 ns | 0.6911 ns | 0.6788 ns |      - |     - |     - |         - |
|      ArrayElementAtOrDefaultRewritten |   0.1906 ns | 0.0216 ns | 0.0180 ns |      - |     - |     - |         - |
|          ArrayWhereElementAtOrDefault | 298.6211 ns | 5.9176 ns | 5.5353 ns | 0.0076 |     - |     - |      32 B |
| ArrayWhereElementAtOrDefaultRewritten |  95.6353 ns | 0.8149 ns | 0.7622 ns |      - |     - |     - |         - |
|          EnumerableElementAtOrDefault | 210.9681 ns | 3.2400 ns | 3.0307 ns | 0.0057 |     - |     - |      24 B |
| EnumerableElementAtOrDefaultRewritten | 194.4773 ns | 3.0759 ns | 2.8772 ns | 0.0057 |     - |     - |      24 B |