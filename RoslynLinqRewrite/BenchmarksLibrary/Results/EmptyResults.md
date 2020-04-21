|                     Method |      Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |----------:|----------:|----------:|-------:|------:|------:|----------:|
|               EmptyToArray | 47.729 ns | 0.9205 ns | 0.8610 ns | 0.0029 |     - |     - |      12 B |
|      EmptyToArrayRewritten |  2.102 ns | 0.0620 ns | 0.0580 ns | 0.0029 |     - |     - |      12 B |
|          EmptyWhereToArray | 52.579 ns | 0.9297 ns | 0.8697 ns | 0.0105 |     - |     - |      44 B |
| EmptyWhereToArrayRewritten | 21.357 ns | 0.4582 ns | 0.5093 ns | 0.0134 |     - |     - |      56 B |