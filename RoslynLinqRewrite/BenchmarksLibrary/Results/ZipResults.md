|                 Method |      Mean |    Error |   StdDev |   Gen 0 |   Gen 1 |   Gen 2 | Allocated |
|----------------------- |----------:|---------:|---------:|--------:|--------:|--------:|----------:|
|               ArrayZip | 167.53 us | 1.509 us | 1.337 us | 40.5273 |       - |       - | 167.51 KB |
|      ArrayZipRewritten |  46.74 us | 0.450 us | 0.421 us |  9.5215 |       - |       - |  39.16 KB |
|          EnumerableZip | 175.71 us | 2.079 us | 1.944 us | 40.5273 |       - |       - | 167.51 KB |
| EnumerableZipRewritten | 135.33 us | 1.229 us | 1.089 us | 41.5039 | 41.5039 | 41.5039 | 210.15 KB |