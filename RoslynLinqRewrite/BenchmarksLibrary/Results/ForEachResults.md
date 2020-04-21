|                             Method |     Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------- |---------:|----------:|----------:|-------:|------:|------:|----------:|
|                    ArrayForEachSum | 5.054 us | 0.0542 us | 0.0507 us | 0.0153 |     - |     - |      64 B |
|           ArrayForEachSumRewritten | 1.492 us | 0.0148 us | 0.0138 us |      - |     - |     - |         - |
|               EnumerableForEachSum | 5.915 us | 0.0407 us | 0.0361 us | 0.0153 |     - |     - |      68 B |
|      EnumerableForEachSumRewritten | 4.527 us | 0.0851 us | 0.0836 us |      - |     - |     - |      24 B |
|               ArrayWhereforeachSum | 9.098 us | 0.1133 us | 0.1060 us |      - |     - |     - |      56 B |
|      ArrayWhereforeachSumRewritten | 4.171 us | 0.0688 us | 0.0643 us | 0.0076 |     - |     - |      32 B |
|          EnumerableWhereforeachSum | 9.297 us | 0.0191 us | 0.0169 us |      - |     - |     - |      56 B |
| EnumerableWhereforeachSumRewritten | 8.628 us | 0.1177 us | 0.1101 us |      - |     - |     - |      56 B |