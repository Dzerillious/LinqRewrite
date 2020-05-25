|                                               Method |        Job |       Runtime |    Toolchain |     Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------------------- |----------- |-------------- |------------- |---------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                              ArraySequenceEqualArray | Job-GLNTOX |      .NET 4.8 |        net48 | 40.58 ns | 0.532 ns | 0.497 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                              ArraySequenceEqualArray | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 63.34 ns | 0.317 ns | 0.281 ns |  1.56 |    0.02 |      - |     - |     - |         - |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|                     ArraySequenceEqualArrayRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 16.91 ns | 0.200 ns | 0.178 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                     ArraySequenceEqualArrayRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 16.61 ns | 0.101 ns | 0.094 ns |  0.98 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|                    ArrayWhereSequenceEqualArrayWhere | Job-GLNTOX |      .NET 4.8 |        net48 | 40.45 ns | 0.539 ns | 0.504 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                    ArrayWhereSequenceEqualArrayWhere | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 62.96 ns | 0.333 ns | 0.295 ns |  1.56 |    0.02 |      - |     - |     - |         - |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|           ArrayWhereSequenceEqualArrayWhereRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 17.01 ns | 0.057 ns | 0.051 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|           ArrayWhereSequenceEqualArrayWhereRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 15.97 ns | 0.131 ns | 0.122 ns |  0.94 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|                         ArraySequenceEqualEnumerable | Job-GLNTOX |      .NET 4.8 |        net48 | 40.31 ns | 0.215 ns | 0.201 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                         ArraySequenceEqualEnumerable | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 49.91 ns | 0.285 ns | 0.222 ns |  1.24 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|                ArraySequenceEqualEnumerableRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 16.26 ns | 0.100 ns | 0.084 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|                ArraySequenceEqualEnumerableRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 20.63 ns | 0.162 ns | 0.152 ns |  1.27 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|               ArrayWhereSequenceEqualEnumerableWhere | Job-GLNTOX |      .NET 4.8 |        net48 | 40.14 ns | 0.232 ns | 0.217 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|               ArrayWhereSequenceEqualEnumerableWhere | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 52.25 ns | 0.259 ns | 0.230 ns |  1.30 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|      ArrayWhereSequenceEqualEnumerableWhereRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 16.14 ns | 0.101 ns | 0.089 ns |  1.00 |    0.00 | 0.0076 |     - |     - |      32 B |
|      ArrayWhereSequenceEqualEnumerableWhereRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 20.43 ns | 0.186 ns | 0.174 ns |  1.27 |    0.01 | 0.0076 |     - |     - |      32 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|                         EnumerableSequenceEqualArray | Job-GLNTOX |      .NET 4.8 |        net48 | 40.65 ns | 0.412 ns | 0.366 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                         EnumerableSequenceEqualArray | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 39.22 ns | 0.593 ns | 0.463 ns |  0.96 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|                EnumerableSequenceEqualArrayRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 31.96 ns | 0.150 ns | 0.126 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                EnumerableSequenceEqualArrayRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 35.35 ns | 0.473 ns | 0.395 ns |  1.11 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|               EnumerableWhereSequenceEqualArrayWhere | Job-GLNTOX |      .NET 4.8 |        net48 | 40.70 ns | 0.287 ns | 0.269 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|               EnumerableWhereSequenceEqualArrayWhere | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 38.39 ns | 0.607 ns | 0.568 ns |  0.94 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|      EnumerableWhereSequenceEqualArrayWhereRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 32.03 ns | 0.222 ns | 0.186 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|      EnumerableWhereSequenceEqualArrayWhereRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 35.38 ns | 0.434 ns | 0.363 ns |  1.10 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|                    EnumerableSequenceEqualEnumerable | Job-GLNTOX |      .NET 4.8 |        net48 | 41.30 ns | 0.415 ns | 0.368 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                    EnumerableSequenceEqualEnumerable | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 41.57 ns | 0.387 ns | 0.362 ns |  1.01 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|           EnumerableSequenceEqualEnumerableRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 32.50 ns | 0.180 ns | 0.140 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|           EnumerableSequenceEqualEnumerableRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 39.92 ns | 0.237 ns | 0.197 ns |  1.23 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
|          EnumerableWhereSequenceEqualEnumerableWhere | Job-GLNTOX |      .NET 4.8 |        net48 | 41.32 ns | 0.253 ns | 0.224 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|          EnumerableWhereSequenceEqualEnumerableWhere | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 40.86 ns | 0.437 ns | 0.365 ns |  0.99 |    0.01 | 0.0153 |     - |     - |      64 B |
|                                                      |            |               |              |          |          |          |       |         |        |       |       |           |
| EnumerableWhereSequenceEqualEnumerableWhereRewritten | Job-GLNTOX |      .NET 4.8 |        net48 | 32.38 ns | 0.256 ns | 0.214 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
| EnumerableWhereSequenceEqualEnumerableWhereRewritten | Job-OLFYIB | .NET Core 3.1 | netcoreapp31 | 39.84 ns | 0.201 ns | 0.188 ns |  1.23 |    0.01 | 0.0153 |     - |     - |      64 B |