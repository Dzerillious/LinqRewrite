|                     Method |      Mean |     Error |    StdDev |
|--------------------------- |----------:|----------:|----------:|
|               EmptyToArray | 50.613 ns | 0.2661 ns | 0.2359 ns |
|      EmptyToArrayRewritten |  2.255 ns | 0.0305 ns | 0.0286 ns | x25
|          EmptyWhereToArray | 56.476 ns | 0.2797 ns | 0.2479 ns |
| EmptyWhereToArrayRewritten | 22.071 ns | 0.2535 ns | 0.2371 ns | x2