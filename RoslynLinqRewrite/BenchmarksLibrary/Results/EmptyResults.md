|                     Method |        Job |       Runtime |    Toolchain |      Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |----------- |-------------- |------------- |----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|               EmptyToArray | Job-CIVGQE |      .NET 4.8 |        net48 | 49.641 ns | 0.1940 ns | 0.1814 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
|               EmptyToArray | Job-DEFMRF | .NET Core 3.1 | netcoreapp31 |  5.047 ns | 0.0217 ns | 0.0181 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|                            |            |               |              |           |           |           |       |         |        |       |       |           |
|      EmptyToArrayRewritten | Job-CIVGQE |      .NET 4.8 |        net48 |  2.561 ns | 0.0211 ns | 0.0198 ns |  1.00 |    0.00 | 0.0057 |     - |     - |      24 B |
|      EmptyToArrayRewritten | Job-DEFMRF | .NET Core 3.1 | netcoreapp31 |  2.687 ns | 0.0288 ns | 0.0270 ns |  1.05 |    0.01 | 0.0057 |     - |     - |      24 B |
|                            |            |               |              |           |           |           |       |         |        |       |       |           |
|          EmptyWhereToArray | Job-CIVGQE |      .NET 4.8 |        net48 | 56.346 ns | 0.2346 ns | 0.2194 ns |  1.00 |    0.00 | 0.0172 |     - |     - |      72 B |
|          EmptyWhereToArray | Job-DEFMRF | .NET Core 3.1 | netcoreapp31 | 49.246 ns | 0.3707 ns | 0.3468 ns |  0.87 |    0.01 | 0.0134 |     - |     - |      56 B |
|                            |            |               |              |           |           |           |       |         |        |       |       |           |
| EmptyWhereToArrayRewritten | Job-CIVGQE |      .NET 4.8 |        net48 | 15.786 ns | 0.1971 ns | 0.1539 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      80 B |
| EmptyWhereToArrayRewritten | Job-DEFMRF | .NET Core 3.1 | netcoreapp31 | 16.932 ns | 0.2190 ns | 0.2048 ns |  1.07 |    0.02 | 0.0191 |     - |     - |      80 B |