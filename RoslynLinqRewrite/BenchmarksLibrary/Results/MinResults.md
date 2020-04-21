|                    Method |       Mean |     Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------- |-----------:|----------:|---------:|-------:|------:|------:|----------:|
|                  RangeMin | 4,665.3 ns |  58.00 ns | 54.26 ns | 0.0076 |     - |     - |      40 B |
|         RangeMinRewritten |   985.1 ns |  19.45 ns | 23.16 ns |      - |     - |     - |         - |
|                  ArrayMin | 4,211.1 ns |  45.01 ns | 39.90 ns |      - |     - |     - |      20 B |
|         ArrayMinRewritten |   949.8 ns |  18.78 ns | 30.32 ns |      - |     - |     - |         - |
|             ArrayWhereMin | 3,293.6 ns |  35.88 ns | 33.56 ns | 0.0076 |     - |     - |      32 B |
|    ArrayWhereMinRewritten |   984.7 ns |  12.38 ns | 11.58 ns |      - |     - |     - |         - |
|          ArrayNullableMin | 8,415.6 ns | 100.45 ns | 93.96 ns |      - |     - |     - |      40 B |
| ArrayNullableMinRewritten | 1,277.8 ns |  14.00 ns | 13.09 ns |      - |     - |     - |         - |
|             EnumerableMin | 5,393.6 ns |  86.27 ns | 76.48 ns |      - |     - |     - |      24 B |
|    EnumerableMinRewritten | 4,532.0 ns |  70.50 ns | 65.94 ns |      - |     - |     - |      24 B |