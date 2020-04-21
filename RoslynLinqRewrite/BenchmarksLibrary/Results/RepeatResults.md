|                   Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|          RepeatElementAt |   215.50 ns |  0.860 ns |  0.804 ns | 0.0095 |     - |     - |      40 B |
| RepeatElementAtRewritten |    56.10 ns |  0.595 ns |  0.556 ns |      - |     - |     - |         - |
|                RepeatSum | 4,443.59 ns | 43.041 ns | 40.261 ns | 0.0076 |     - |     - |      40 B |
|       RepeatSumRewritten |   284.36 ns |  4.202 ns |  3.725 ns |      - |     - |     - |         - |
|            RepeatToArray | 5,663.04 ns | 73.781 ns | 65.405 ns | 2.9373 |     - |     - |   12358 B |
|   RepeatToArrayRewritten |   459.46 ns |  5.616 ns |  5.254 ns | 0.9575 |     - |     - |    4021 B |