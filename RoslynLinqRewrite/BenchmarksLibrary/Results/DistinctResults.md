|                      Method |        Job |       Runtime |    Toolchain |     Mean |    Error |   StdDev | Ratio |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|---------------------------- |----------- |-------------- |------------- |---------:|---------:|---------:|------:|--------:|-------:|------:|----------:|
|               ArrayDistinct | Job-BPMZYF |      .NET 4.8 |        net48 | 28.33 us | 0.074 us | 0.069 us |  1.00 | 10.8643 |      - |     - |   44.6 KB |
|               ArrayDistinct | Job-AQLRUI | .NET Core 3.1 | netcoreapp31 | 21.89 us | 0.070 us | 0.066 us |  0.77 |  8.8501 |      - |     - |  36.26 KB |
|                             |            |               |              |          |          |          |       |         |        |       |           |
|      ArrayDistinctRewritten | Job-BPMZYF |      .NET 4.8 |        net48 | 22.45 us | 0.089 us | 0.079 us |  1.00 | 15.2588 |      - |     - |  62.71 KB |
|      ArrayDistinctRewritten | Job-AQLRUI | .NET Core 3.1 | netcoreapp31 | 20.58 us | 0.130 us | 0.122 us |  0.92 | 15.2588 | 0.0305 |     - |  62.54 KB |
|                             |            |               |              |          |          |          |       |         |        |       |           |
|          EnumerableDistinct | Job-BPMZYF |      .NET 4.8 |        net48 | 27.88 us | 0.218 us | 0.203 us |  1.00 | 10.8643 |      - |     - |   44.6 KB |
|          EnumerableDistinct | Job-AQLRUI | .NET Core 3.1 | netcoreapp31 | 20.80 us | 0.117 us | 0.110 us |  0.75 |  8.8501 |      - |     - |  36.26 KB |
|                             |            |               |              |          |          |          |       |         |        |       |           |
| EnumerableDistinctRewritten | Job-BPMZYF |      .NET 4.8 |        net48 | 27.64 us | 0.104 us | 0.097 us |  1.00 | 17.6086 |      - |     - |  72.23 KB |
| EnumerableDistinctRewritten | Job-AQLRUI | .NET Core 3.1 | netcoreapp31 | 24.02 us | 0.080 us | 0.071 us |  0.87 | 17.6086 | 0.0305 |     - |  72.02 KB |