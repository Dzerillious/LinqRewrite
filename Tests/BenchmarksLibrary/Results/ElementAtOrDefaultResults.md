|                                Method |        Job |       Runtime |    Toolchain |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------------------------------- |----------- |-------------- |------------- |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|               ArrayElementAtOrDefault | Job-YTIEFF |      .NET 4.8 |        net48 |  27.5563 ns | 0.2153 ns | 0.2014 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|               ArrayElementAtOrDefault | Job-MGXZJS | .NET Core 3.1 | netcoreapp31 |  28.3963 ns | 0.1330 ns | 0.1179 ns |  1.03 |    0.01 |      - |     - |     - |         - |
|                                       |            |               |              |             |           |           |       |         |        |       |       |           |
|      ArrayElementAtOrDefaultRewritten | Job-YTIEFF |      .NET 4.8 |        net48 |   0.2641 ns | 0.0090 ns | 0.0084 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|      ArrayElementAtOrDefaultRewritten | Job-MGXZJS | .NET Core 3.1 | netcoreapp31 |   0.3029 ns | 0.0062 ns | 0.0058 ns |  1.15 |    0.04 |      - |     - |     - |         - |
|                                       |            |               |              |             |           |           |       |         |        |       |       |           |
|          ArrayWhereElementAtOrDefault | Job-YTIEFF |      .NET 4.8 |        net48 | 370.3850 ns | 2.2816 ns | 2.1342 ns |  1.00 |    0.00 | 0.0114 |     - |     - |      48 B |
|          ArrayWhereElementAtOrDefault | Job-MGXZJS | .NET Core 3.1 | netcoreapp31 | 362.9069 ns | 1.3016 ns | 1.2175 ns |  0.98 |    0.01 | 0.0114 |     - |     - |      48 B |
|                                       |            |               |              |             |           |           |       |         |        |       |       |           |
| ArrayWhereElementAtOrDefaultRewritten | Job-YTIEFF |      .NET 4.8 |        net48 |  59.2104 ns | 0.2201 ns | 0.2059 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ArrayWhereElementAtOrDefaultRewritten | Job-MGXZJS | .NET Core 3.1 | netcoreapp31 |  56.7339 ns | 0.2363 ns | 0.2210 ns |  0.96 |    0.00 |      - |     - |     - |         - |
|                                       |            |               |              |             |           |           |       |         |        |       |       |           |
|          EnumerableElementAtOrDefault | Job-YTIEFF |      .NET 4.8 |        net48 | 206.1661 ns | 0.8668 ns | 0.8108 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|          EnumerableElementAtOrDefault | Job-MGXZJS | .NET Core 3.1 | netcoreapp31 | 211.1799 ns | 0.6443 ns | 0.5712 ns |  1.02 |    0.00 | 0.0076 |     - |     - |      32 B |
|                                       |            |               |              |             |           |           |       |         |        |       |       |           |
| EnumerableElementAtOrDefaultRewritten | Job-YTIEFF |      .NET 4.8 |        net48 | 169.4855 ns | 0.8302 ns | 0.7766 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
| EnumerableElementAtOrDefaultRewritten | Job-MGXZJS | .NET Core 3.1 | netcoreapp31 | 181.0345 ns | 1.3187 ns | 1.2335 ns |  1.07 |    0.01 | 0.0076 |     - |     - |      32 B |