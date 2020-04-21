|                  Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------ |------------:|----------:|----------:|-------:|------:|------:|----------:|
|          RangeElementAt |   165.88 ns |  1.896 ns |  1.681 ns | 0.0095 |     - |     - |      40 B |
| RangeElementAtRewritten |    57.05 ns |  0.509 ns |  0.476 ns |      - |     - |     - |         - |
|                RangeSum | 4,104.15 ns | 52.592 ns | 49.194 ns | 0.0076 |     - |     - |      40 B |
|       RangeSumRewritten |   797.35 ns |  2.268 ns |  2.122 ns |      - |     - |     - |         - |
|            RangeToArray | 5,885.41 ns | 65.787 ns | 61.537 ns | 2.9373 |     - |     - |   12358 B |
|   RangeToArrayRewritten |   695.33 ns |  6.919 ns |  6.133 ns | 0.9575 |     - |     - |    4021 B |