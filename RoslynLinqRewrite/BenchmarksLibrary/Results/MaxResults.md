|                    Method |       Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |-----------:|----------:|----------:|-------:|------:|------:|----------:|
|                  RangeMax | 6,147.4 ns |  86.71 ns |  81.11 ns | 0.0076 |     - |     - |      40 B |
|         RangeMaxRewritten |   369.0 ns |   3.28 ns |   3.07 ns |      - |     - |     - |         - |
|                  ArrayMax | 6,178.3 ns |  85.30 ns |  79.79 ns |      - |     - |     - |      20 B |
|         ArrayMaxRewritten |   556.3 ns |   7.42 ns |   6.94 ns |      - |     - |     - |         - |
|             ArrayWhereMax | 3,736.5 ns |  41.37 ns |  38.70 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereMaxRewritten | 1,008.5 ns |  13.85 ns |  12.95 ns |      - |     - |     - |         - |
|          ArrayNullableMax | 8,425.8 ns | 148.60 ns | 139.00 ns |      - |     - |     - |      40 B |
| ArrayNullableMaxRewritten | 1,233.9 ns |  17.11 ns |  16.00 ns |      - |     - |     - |         - |
|             EnumerableMax | 6,900.3 ns |  85.03 ns |  79.53 ns |      - |     - |     - |      24 B |
|    EnumerableMaxRewritten | 4,217.1 ns |  58.31 ns |  51.69 ns |      - |     - |     - |      24 B |