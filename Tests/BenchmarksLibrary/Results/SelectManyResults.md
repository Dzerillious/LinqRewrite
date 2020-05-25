|                        Method |        Job |       Runtime |    Toolchain |      Mean |     Error |    StdDev | Ratio |    Gen 0 |    Gen 1 |    Gen 2 | Allocated |
|------------------------------ |----------- |-------------- |------------- |----------:|----------:|----------:|------:|---------:|---------:|---------:|----------:|
|               RangeSelectMany | Job-FSPUPA |      .NET 4.8 |        net48 | 17.866 ms | 0.2189 ms | 0.2048 ms |  1.00 | 968.7500 | 968.7500 | 968.7500 |  11.87 MB |
|               RangeSelectMany | Job-QWUOGD | .NET Core 3.1 | netcoreapp31 |  6.120 ms | 0.0289 ms | 0.0256 ms |  0.34 | 992.1875 | 992.1875 | 992.1875 |   3.88 MB |
|                               |            |               |              |           |           |           |       |          |          |          |           |
|      RangeSelectManyRewritten | Job-FSPUPA |      .NET 4.8 |        net48 | 10.148 ms | 0.0317 ms | 0.0281 ms |  1.00 | 500.0000 | 484.3750 | 484.3750 |  14.51 MB |
|      RangeSelectManyRewritten | Job-QWUOGD | .NET Core 3.1 | netcoreapp31 | 10.510 ms | 0.0835 ms | 0.0781 ms |  1.04 | 500.0000 | 484.3750 | 484.3750 |  14.51 MB |
|                               |            |               |              |           |           |           |       |          |          |          |           |
|               ArraySelectMany | Job-FSPUPA |      .NET 4.8 |        net48 | 17.040 ms | 0.1616 ms | 0.1512 ms |  1.00 | 968.7500 | 968.7500 | 968.7500 |  11.85 MB |
|               ArraySelectMany | Job-QWUOGD | .NET Core 3.1 | netcoreapp31 |  1.777 ms | 0.0094 ms | 0.0084 ms |  0.10 | 998.0469 | 998.0469 | 998.0469 |   3.85 MB |
|                               |            |               |              |           |           |           |       |          |          |          |           |
|      ArraySelectManyRewritten | Job-FSPUPA |      .NET 4.8 |        net48 |  6.557 ms | 0.0366 ms | 0.0343 ms |  1.00 | 500.0000 | 492.1875 | 492.1875 |  14.48 MB |
|      ArraySelectManyRewritten | Job-QWUOGD | .NET Core 3.1 | netcoreapp31 |  6.565 ms | 0.0335 ms | 0.0297 ms |  1.00 | 500.0000 | 492.1875 | 492.1875 |  14.48 MB |
|                               |            |               |              |           |           |           |       |          |          |          |           |
|          EnumerableSelectMany | Job-FSPUPA |      .NET 4.8 |        net48 | 16.547 ms | 0.2016 ms | 0.1885 ms |  1.00 | 968.7500 | 968.7500 | 968.7500 |  11.85 MB |
|          EnumerableSelectMany | Job-QWUOGD | .NET Core 3.1 | netcoreapp31 |  6.635 ms | 0.0636 ms | 0.0563 ms |  0.40 | 796.8750 | 796.8750 | 796.8750 |   7.85 MB |
|                               |            |               |              |           |           |           |       |          |          |          |           |
| EnumerableSelectManyRewritten | Job-FSPUPA |      .NET 4.8 |        net48 | 10.723 ms | 0.0222 ms | 0.0185 ms |  1.00 | 500.0000 | 484.3750 | 484.3750 |  14.51 MB |
| EnumerableSelectManyRewritten | Job-QWUOGD | .NET Core 3.1 | netcoreapp31 | 10.200 ms | 0.0421 ms | 0.0373 ms |  0.95 | 500.0000 | 484.3750 | 484.3750 |  14.51 MB |