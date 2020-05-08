|                       Method |        Job |       Runtime |    Toolchain | ToValue |        Mean |     Error |    StdDev |      Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |----------- |-------------- |------------- |-------- |------------:|----------:|----------:|------------:|------:|--------:|-------:|------:|------:|----------:|
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |      -1 |  2,053.5 ns |  34.44 ns |  30.53 ns |  2,048.5 ns |  1.12 |    0.02 | 0.0458 |     - |     - |     201 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      -1 |  1,837.0 ns |   5.12 ns |   4.79 ns |  1,835.9 ns |  1.00 |    0.00 | 0.0401 |     - |     - |     168 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      -1 |    778.1 ns |   1.94 ns |   1.62 ns |    777.9 ns |  1.45 |    0.01 | 0.0134 |     - |     - |      56 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      -1 |    535.1 ns |   1.93 ns |   1.61 ns |    534.7 ns |  1.00 |    0.00 | 0.0134 |     - |     - |      56 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      -1 |  2,005.4 ns |   8.94 ns |   8.36 ns |  2,003.3 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      -1 |  1,551.2 ns |   7.63 ns |   6.76 ns |  1,552.3 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |      -1 | 44,091.4 ns | 359.31 ns | 318.52 ns | 44,056.2 ns |  1.29 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      -1 | 34,185.3 ns | 141.48 ns | 125.41 ns | 34,161.4 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |      -1 |  2,859.4 ns |  33.13 ns |  27.66 ns |  2,850.4 ns |  1.34 |    0.02 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      -1 |  2,133.6 ns |  13.74 ns |  12.85 ns |  2,129.0 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |      -1 |  2,594.7 ns |  12.34 ns |  11.55 ns |  2,595.3 ns |  1.28 |    0.13 | 0.9880 |     - |     - |    4149 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      -1 |  2,357.4 ns |  63.51 ns | 174.93 ns |  2,410.8 ns |  1.00 |    0.00 | 0.9880 |     - |     - |    4136 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |      -1 |  2,167.4 ns |  26.46 ns |  22.10 ns |  2,157.3 ns |  0.78 |    0.02 | 0.9804 |     - |     - |    4124 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      -1 |  2,808.9 ns |  55.90 ns |  57.40 ns |  2,787.5 ns |  1.00 |    0.00 | 0.9804 |     - |     - |    4112 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |       0 |  2,161.5 ns |  26.27 ns |  35.96 ns |  2,151.3 ns |  1.17 |    0.02 | 0.0572 |     - |     - |     241 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       0 |  1,859.7 ns |   3.45 ns |   3.23 ns |  1,860.4 ns |  1.00 |    0.00 | 0.0553 |     - |     - |     232 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       0 |    782.8 ns |   1.72 ns |   1.44 ns |    783.0 ns |  1.45 |    0.01 | 0.0153 |     - |     - |      64 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       0 |    541.3 ns |   1.59 ns |   1.41 ns |    541.2 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       0 |  2,007.1 ns |  11.51 ns |  10.20 ns |  2,004.6 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       0 |  1,550.9 ns |   8.40 ns |   7.86 ns |  1,548.6 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |       0 | 44,360.6 ns | 231.61 ns | 193.40 ns | 44,360.7 ns |  1.29 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       0 | 34,328.4 ns | 198.15 ns | 175.65 ns | 34,344.3 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |       0 |  2,912.6 ns |  19.70 ns |  18.43 ns |  2,906.9 ns |  1.25 |    0.01 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       0 |  2,328.9 ns |   7.78 ns |   6.89 ns |  2,327.6 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |       0 |  2,534.5 ns |   8.39 ns |   7.01 ns |  2,533.4 ns |  1.31 |    0.00 | 0.9918 |     - |     - |    4165 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       0 |  1,930.0 ns |   5.39 ns |   5.05 ns |  1,929.0 ns |  1.00 |    0.00 | 0.9918 |     - |     - |    4152 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |       0 |  2,171.6 ns |   9.06 ns |   8.47 ns |  2,170.2 ns |  0.89 |    0.00 | 0.9842 |     - |     - |    4132 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       0 |  2,435.6 ns |   5.70 ns |   5.06 ns |  2,435.5 ns |  1.00 |    0.00 | 0.9842 |     - |     - |    4120 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |       1 |  2,076.1 ns |   9.18 ns |   8.14 ns |  2,075.0 ns |  1.11 |    0.01 | 0.0572 |     - |     - |     241 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       1 |  1,868.7 ns |   5.47 ns |   5.11 ns |  1,866.8 ns |  1.00 |    0.00 | 0.0553 |     - |     - |     232 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       1 |    782.8 ns |   1.93 ns |   1.72 ns |    783.0 ns |  1.44 |    0.00 | 0.0153 |     - |     - |      64 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       1 |    541.7 ns |   1.60 ns |   1.33 ns |    542.0 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       1 |  2,002.8 ns |   5.67 ns |   5.02 ns |  2,003.5 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       1 |  1,549.5 ns |   9.72 ns |   9.09 ns |  1,548.3 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |       1 | 44,012.4 ns | 252.02 ns | 235.74 ns | 43,919.0 ns |  1.30 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       1 | 33,926.0 ns | 241.04 ns | 225.47 ns | 33,907.2 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |       1 |  2,900.6 ns |  20.63 ns |  16.10 ns |  2,899.9 ns |  1.35 |    0.02 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       1 |  2,152.6 ns |  35.62 ns |  29.75 ns |  2,146.3 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |       1 |  2,434.7 ns |   7.29 ns |   6.47 ns |  2,433.7 ns |  1.25 |    0.02 | 0.9918 |     - |     - |    4165 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       1 |  1,952.0 ns |  33.06 ns |  33.95 ns |  1,938.7 ns |  1.00 |    0.00 | 0.9918 |     - |     - |    4152 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |       1 |  2,165.7 ns |   5.70 ns |   4.45 ns |  2,165.0 ns |  0.89 |    0.00 | 0.9842 |     - |     - |    4132 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       1 |  2,425.2 ns |   5.99 ns |   5.60 ns |  2,423.6 ns |  1.00 |    0.00 | 0.9842 |     - |     - |    4120 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |       2 |  2,098.6 ns |   6.85 ns |   5.35 ns |  2,100.0 ns |  1.12 |    0.01 | 0.0572 |     - |     - |     241 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       2 |  1,873.7 ns |   6.29 ns |   5.25 ns |  1,875.0 ns |  1.00 |    0.00 | 0.0553 |     - |     - |     232 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       2 |    785.2 ns |   4.80 ns |   4.26 ns |    783.4 ns |  1.45 |    0.01 | 0.0153 |     - |     - |      64 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       2 |    540.9 ns |   1.89 ns |   1.77 ns |    540.8 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       2 |  2,003.8 ns |   8.27 ns |   6.90 ns |  2,002.3 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       2 |  1,558.5 ns |  13.97 ns |  11.66 ns |  1,557.3 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |       2 | 44,285.6 ns | 198.02 ns | 185.23 ns | 44,256.6 ns |  1.34 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       2 | 33,116.6 ns | 120.30 ns | 106.64 ns | 33,082.8 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |       2 |  2,919.7 ns |  17.68 ns |  16.54 ns |  2,915.2 ns |  1.36 |    0.01 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       2 |  2,145.4 ns |  19.62 ns |  15.32 ns |  2,137.4 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |       2 |  2,438.9 ns |   8.39 ns |   7.43 ns |  2,435.9 ns |  1.26 |    0.01 | 0.9956 |     - |     - |    4182 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       2 |  1,938.7 ns |   7.73 ns |   6.46 ns |  1,936.7 ns |  1.00 |    0.00 | 0.9956 |     - |     - |    4168 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |       2 |  2,169.0 ns |   5.96 ns |   5.57 ns |  2,168.2 ns |  0.90 |    0.00 | 0.9842 |     - |     - |    4140 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       2 |  2,419.6 ns |   5.59 ns |   4.96 ns |  2,419.7 ns |  1.00 |    0.00 | 0.9842 |     - |     - |    4128 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |       5 |  2,136.5 ns |  10.03 ns |   9.38 ns |  2,134.4 ns |  1.11 |    0.01 | 0.0648 |     - |     - |     273 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       5 |  1,924.6 ns |  10.72 ns |  10.03 ns |  1,921.9 ns |  1.00 |    0.00 | 0.0610 |     - |     - |     264 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       5 |    787.3 ns |   1.84 ns |   1.63 ns |    787.6 ns |  1.44 |    0.01 | 0.0153 |     - |     - |      64 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       5 |    547.8 ns |   3.31 ns |   2.76 ns |    546.7 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      64 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |       5 |  1,997.7 ns |   6.91 ns |   6.13 ns |  1,996.4 ns |  1.28 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       5 |  1,555.3 ns |   9.23 ns |   7.71 ns |  1,555.6 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |       5 | 44,375.6 ns | 286.93 ns | 268.40 ns | 44,301.7 ns |  1.30 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       5 | 34,096.5 ns | 235.35 ns | 220.15 ns | 34,123.4 ns |  1.00 |    0.00 | 4.4556 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |       5 |  2,978.7 ns |  22.31 ns |  20.87 ns |  2,972.6 ns |  1.12 |    0.18 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       5 |  3,204.7 ns | 131.11 ns | 356.68 ns |  3,276.0 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |       5 |  2,441.3 ns |   8.83 ns |   8.26 ns |  2,437.9 ns |  0.96 |    0.03 | 0.9995 |     - |     - |    4198 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       5 |  2,568.8 ns |  51.33 ns | 126.86 ns |  2,559.6 ns |  1.00 |    0.00 | 0.9995 |     - |     - |    4184 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |       5 |  2,170.8 ns |   4.33 ns |   3.61 ns |  2,171.6 ns |  0.81 |    0.01 | 0.9880 |     - |     - |    4149 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |       5 |  2,683.1 ns |  29.76 ns |  26.38 ns |  2,683.3 ns |  1.00 |    0.00 | 0.9880 |     - |     - |    4136 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |      10 |  2,491.4 ns |  49.42 ns |  56.91 ns |  2,492.5 ns |  1.27 |    0.03 | 0.0763 |     - |     - |     321 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      10 |  1,952.7 ns |  11.03 ns |   9.21 ns |  1,951.4 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     304 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      10 |    903.8 ns |  13.91 ns |  13.01 ns |    898.7 ns |  1.57 |    0.02 | 0.0381 |     - |     - |     160 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      10 |    574.5 ns |   1.58 ns |   1.32 ns |    574.6 ns |  1.00 |    0.00 | 0.0381 |     - |     - |     160 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      10 |  2,253.6 ns |  26.02 ns |  23.07 ns |  2,253.7 ns |  1.44 |    0.02 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      10 |  1,560.9 ns |   8.00 ns |   7.09 ns |  1,562.3 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |      10 | 49,919.8 ns | 603.50 ns | 564.51 ns | 49,947.8 ns |  1.46 |    0.02 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      10 | 34,240.0 ns | 221.03 ns | 184.57 ns | 34,300.5 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |      10 |  3,237.9 ns |  61.01 ns | 133.92 ns |  3,171.1 ns |  1.41 |    0.03 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      10 |  2,450.6 ns |  15.63 ns |  13.86 ns |  2,448.7 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |      10 |  2,458.6 ns |   4.09 ns |   3.63 ns |  2,458.2 ns |  1.25 |    0.00 | 1.0109 |     - |     - |    4245 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      10 |  1,964.8 ns |   5.67 ns |   5.02 ns |  1,965.5 ns |  1.00 |    0.00 | 1.0109 |     - |     - |    4232 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |      10 |  2,209.6 ns |  28.68 ns |  23.95 ns |  2,199.1 ns |  0.91 |    0.01 | 0.9918 |     - |     - |    4173 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      10 |  2,441.1 ns |  11.62 ns |   9.07 ns |  2,438.3 ns |  1.00 |    0.00 | 0.9918 |     - |     - |    4160 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |      20 |  2,301.4 ns |  20.24 ns |  18.93 ns |  2,294.0 ns |  1.13 |    0.01 | 0.0916 |     - |     - |     385 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      20 |  2,035.1 ns |   5.15 ns |   4.57 ns |  2,036.4 ns |  1.00 |    0.00 | 0.0954 |     - |     - |     408 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      20 |    818.8 ns |   1.19 ns |   0.93 ns |    818.9 ns |  1.40 |    0.00 | 0.0401 |     - |     - |     169 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      20 |    583.8 ns |   2.29 ns |   2.03 ns |    583.6 ns |  1.00 |    0.00 | 0.0401 |     - |     - |     168 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      20 |  2,010.1 ns |   6.63 ns |   5.88 ns |  2,011.2 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      20 |  1,558.6 ns |   8.06 ns |   6.73 ns |  1,558.2 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |      20 | 44,423.7 ns | 186.18 ns | 155.47 ns | 44,438.0 ns |  1.31 |    0.02 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      20 | 34,146.0 ns | 598.07 ns | 559.43 ns | 33,922.2 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |      20 |  3,168.6 ns |  18.66 ns |  15.58 ns |  3,168.7 ns |  1.26 |    0.01 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      20 |  2,521.1 ns |   9.73 ns |   9.10 ns |  2,523.2 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |      20 |  2,478.9 ns |   9.26 ns |   8.21 ns |  2,477.1 ns |  1.24 |    0.01 | 1.0300 |     - |     - |    4328 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      20 |  1,992.6 ns |   5.97 ns |   5.29 ns |  1,991.5 ns |  1.00 |    0.00 | 1.0300 |     - |     - |    4312 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |      20 |  2,227.7 ns |   7.35 ns |   6.87 ns |  2,227.8 ns |  0.90 |    0.00 | 1.0033 |     - |     - |    4215 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      20 |  2,464.6 ns |   7.24 ns |   6.77 ns |  2,463.9 ns |  1.00 |    0.00 | 1.0033 |     - |     - |    4200 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |      50 |  2,574.5 ns |  18.40 ns |  17.21 ns |  2,571.5 ns |  1.21 |    0.01 | 0.1183 |     - |     - |     506 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      50 |  2,130.2 ns |   9.46 ns |   8.85 ns |  2,131.2 ns |  1.00 |    0.00 | 0.1183 |     - |     - |     496 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      50 |    851.0 ns |   1.97 ns |   1.85 ns |    850.7 ns |  1.36 |    0.00 | 0.0477 |     - |     - |     201 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      50 |    626.8 ns |   1.64 ns |   1.46 ns |    626.6 ns |  1.00 |    0.00 | 0.0477 |     - |     - |     200 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |      50 |  2,008.6 ns |   4.53 ns |   4.01 ns |  2,008.5 ns |  1.29 |    0.00 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      50 |  1,562.5 ns |   4.47 ns |   3.96 ns |  1,561.2 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |      50 | 44,774.5 ns | 176.32 ns | 156.30 ns | 44,788.9 ns |  1.29 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      50 | 34,588.1 ns | 244.94 ns | 229.12 ns | 34,587.7 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |      50 |  3,506.5 ns |  23.43 ns |  18.29 ns |  3,499.8 ns |  1.29 |    0.01 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      50 |  2,713.9 ns |  12.09 ns |  11.31 ns |  2,712.1 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |      50 |  2,531.6 ns |   6.09 ns |   5.70 ns |  2,531.3 ns |  1.23 |    0.00 | 1.0872 |     - |     - |    4568 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      50 |  2,063.4 ns |   6.56 ns |   6.14 ns |  2,063.0 ns |  1.00 |    0.00 | 1.0872 |     - |     - |    4552 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |      50 |  2,285.5 ns |   8.40 ns |   7.45 ns |  2,284.5 ns |  0.91 |    0.01 | 1.0300 |     - |     - |    4333 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |      50 |  2,499.8 ns |  20.07 ns |  16.76 ns |  2,493.5 ns |  1.00 |    0.00 | 1.0300 |     - |     - |    4320 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |     100 |  2,867.5 ns |   7.41 ns |   6.19 ns |  2,867.3 ns |  1.24 |    0.01 | 0.1678 |     - |     - |     706 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     100 |  2,303.9 ns |   9.70 ns |   9.07 ns |  2,301.2 ns |  1.00 |    0.00 | 0.1488 |     - |     - |     632 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |     100 |    940.4 ns |   2.85 ns |   2.66 ns |    939.4 ns |  1.29 |    0.01 | 0.1259 |     - |     - |     530 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     100 |    727.7 ns |   1.86 ns |   1.74 ns |    727.4 ns |  1.00 |    0.00 | 0.1259 |     - |     - |     528 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |     100 |  2,012.5 ns |   7.69 ns |   6.42 ns |  2,012.3 ns |  1.29 |    0.00 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     100 |  1,564.7 ns |   4.74 ns |   4.43 ns |  1,563.8 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |     100 | 45,737.4 ns | 320.69 ns | 299.97 ns | 45,752.4 ns |  1.31 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     100 | 34,936.4 ns | 234.29 ns | 219.15 ns | 34,942.7 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |     100 |  4,078.6 ns |  21.21 ns |  18.80 ns |  4,073.3 ns |  1.34 |    0.01 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     100 |  3,034.6 ns |  11.44 ns |  10.14 ns |  3,036.8 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |     100 |  2,598.9 ns |   7.68 ns |   6.81 ns |  2,596.6 ns |  1.20 |    0.01 | 1.1826 |     - |     - |    4968 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     100 |  2,171.0 ns |   9.80 ns |   9.17 ns |  2,172.9 ns |  1.00 |    0.00 | 1.1826 |     - |     - |    4952 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |     100 |  2,378.5 ns |   7.33 ns |   6.50 ns |  2,377.2 ns |  0.94 |    0.00 | 1.0796 |     - |     - |    4534 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     100 |  2,537.7 ns |   6.11 ns |   5.71 ns |  2,535.5 ns |  1.00 |    0.00 | 1.0796 |     - |     - |    4520 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |     200 |  3,478.9 ns |  20.89 ns |  19.54 ns |  3,477.9 ns |  1.34 |    0.01 | 0.2594 |     - |     - |    1091 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     200 |  2,592.8 ns |   7.23 ns |   6.41 ns |  2,592.0 ns |  1.00 |    0.00 | 0.2098 |     - |     - |     888 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |     200 |  1,077.9 ns |   3.95 ns |   3.30 ns |  1,077.4 ns |  1.21 |    0.00 | 0.1507 |     - |     - |     634 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     200 |    891.1 ns |   1.50 ns |   1.40 ns |    890.9 ns |  1.00 |    0.00 | 0.1507 |     - |     - |     632 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |     200 |  2,011.3 ns |   5.91 ns |   4.94 ns |  2,011.2 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     200 |  1,562.8 ns |   8.59 ns |   8.03 ns |  1,559.9 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |     200 | 46,909.5 ns | 314.58 ns | 294.26 ns | 46,854.0 ns |  1.32 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     200 | 35,576.7 ns | 199.66 ns | 186.77 ns | 35,612.2 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |     200 |  5,207.5 ns |  28.04 ns |  24.85 ns |  5,202.2 ns |  1.42 |    0.01 | 0.3281 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     200 |  3,667.4 ns |  11.81 ns |  10.47 ns |  3,665.1 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |     200 |  2,735.9 ns |   8.88 ns |   7.42 ns |  2,732.9 ns |  1.15 |    0.00 | 1.3733 |     - |     - |    5769 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     200 |  2,379.3 ns |   6.07 ns |   5.68 ns |  2,381.0 ns |  1.00 |    0.00 | 1.3733 |     - |     - |    5752 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |     200 |  2,569.9 ns |   7.54 ns |   7.05 ns |  2,569.1 ns |  0.95 |    0.03 | 1.1749 |     - |     - |    4935 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     200 |  2,675.1 ns |  47.62 ns |  63.56 ns |  2,644.1 ns |  1.00 |    0.00 | 1.1749 |     - |     - |    4920 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |     500 |  5,248.5 ns |  32.27 ns |  30.19 ns |  5,242.7 ns |  1.52 |    0.01 | 0.4578 |     - |     - |    1926 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     500 |  3,449.2 ns |  11.99 ns |  10.62 ns |  3,445.5 ns |  1.00 |    0.00 | 0.3700 |     - |     - |    1552 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |     500 |  1,497.8 ns |   2.72 ns |   2.41 ns |  1,498.0 ns |  1.06 |    0.00 | 0.4654 |     - |     - |    1958 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     500 |  1,408.1 ns |   3.52 ns |   3.12 ns |  1,407.9 ns |  1.00 |    0.00 | 0.4654 |     - |     - |    1952 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |     500 |  2,007.7 ns |   5.44 ns |   4.83 ns |  2,008.2 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     500 |  1,561.7 ns |   5.32 ns |   4.98 ns |  1,561.7 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |     500 | 50,400.9 ns | 467.50 ns | 437.30 ns | 50,273.1 ns |  1.34 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     500 | 37,544.5 ns | 307.66 ns | 272.74 ns | 37,570.1 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18989 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |     500 |  8,713.9 ns |  24.67 ns |  19.26 ns |  8,716.1 ns |  1.54 |    0.01 | 0.3204 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     500 |  5,648.9 ns |  27.68 ns |  23.11 ns |  5,640.5 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |     500 |  3,120.8 ns |  12.40 ns |  10.35 ns |  3,117.5 ns |  1.04 |    0.01 | 1.9455 |     - |     - |    8176 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     500 |  2,993.2 ns |  11.75 ns |  10.99 ns |  2,991.9 ns |  1.00 |    0.00 | 1.9455 |     - |     - |    8152 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |     500 |  3,129.4 ns |   8.78 ns |   7.78 ns |  3,127.9 ns |  1.07 |    0.00 | 1.4610 |     - |     - |    6139 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |     500 |  2,922.6 ns |   9.08 ns |   7.58 ns |  2,923.3 ns |  1.00 |    0.00 | 1.4610 |     - |     - |    6120 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |    1000 |  8,160.9 ns |  36.66 ns |  30.61 ns |  8,166.2 ns |  1.70 |    0.01 | 0.8240 |     - |     - |    3474 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    1000 |  4,789.1 ns |  12.93 ns |  12.10 ns |  4,787.3 ns |  1.00 |    0.00 | 0.6104 |     - |     - |    2560 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |    1000 |  2,035.9 ns |  10.87 ns |  10.17 ns |  2,037.5 ns |  0.99 |    0.01 | 0.3395 |     - |     - |    1428 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    1000 |  2,061.6 ns |   8.34 ns |   7.40 ns |  2,062.1 ns |  1.00 |    0.00 | 0.3395 |     - |     - |    1424 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |    1000 |  2,016.9 ns |  18.15 ns |  16.97 ns |  2,008.5 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    1000 |  1,566.2 ns |   7.94 ns |   7.43 ns |  1,565.3 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |    1000 | 55,567.4 ns | 241.46 ns | 188.51 ns | 55,584.6 ns |  1.35 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    1000 | 41,201.8 ns | 296.92 ns | 277.74 ns | 41,215.9 ns |  1.00 |    0.00 | 4.3945 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |    1000 | 14,348.9 ns | 111.91 ns |  99.21 ns | 14,354.2 ns |  1.61 |    0.01 | 0.3204 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    1000 |  8,935.5 ns |  21.13 ns |  17.64 ns |  8,934.1 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |    1000 |  3,599.3 ns |  36.88 ns |  34.50 ns |  3,579.8 ns |  0.94 |    0.01 | 1.9379 |     - |     - |    8136 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    1000 |  3,847.1 ns |  30.31 ns |  28.35 ns |  3,843.8 ns |  1.00 |    0.00 | 1.9379 |     - |     - |    8112 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |    1000 |  3,694.8 ns |   7.95 ns |   7.44 ns |  3,692.2 ns |  1.16 |    0.01 | 0.9766 |     - |     - |    4100 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    1000 |  3,189.0 ns |  19.72 ns |  18.45 ns |  3,180.6 ns |  1.00 |    0.00 | 0.9766 |     - |     - |    4088 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                   SystemLinq | Job-OZWONA |      .NET 4.8 |        net48 |    2000 |  8,209.5 ns |  66.65 ns |  62.34 ns |  8,221.2 ns |  1.71 |    0.01 | 0.8240 |     - |     - |    3474 B |
|                   SystemLinq | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    2000 |  4,784.4 ns |  19.19 ns |  17.02 ns |  4,785.5 ns |  1.00 |    0.00 | 0.6104 |     - |     - |    2560 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|         OptimizedLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |    2000 |  2,031.9 ns |   5.73 ns |   4.79 ns |  2,033.6 ns |  0.99 |    0.00 | 0.3395 |     - |     - |    1428 B |
|         OptimizedLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    2000 |  2,054.1 ns |   5.26 ns |   4.39 ns |  2,054.1 ns |  1.00 |    0.00 | 0.3395 |     - |     - |    1424 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            ShamanLinqRewrite | Job-OZWONA |      .NET 4.8 |        net48 |    2000 |  2,011.2 ns |   8.04 ns |   7.12 ns |  2,009.6 ns |  1.29 |    0.01 | 1.5144 |     - |     - |    6355 B |
|            ShamanLinqRewrite | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    2000 |  1,562.2 ns |   7.06 ns |   6.26 ns |  1,564.3 ns |  1.00 |    0.00 | 1.5125 |     - |     - |    6328 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|                LinqOptimizer | Job-OZWONA |      .NET 4.8 |        net48 |    2000 | 55,662.5 ns | 378.81 ns | 354.34 ns | 55,609.2 ns |  1.35 |    0.01 | 5.3711 |     - |     - |   22759 B |
|                LinqOptimizer | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    2000 | 41,369.4 ns | 190.97 ns | 178.63 ns | 41,344.7 ns |  1.00 |    0.00 | 4.5166 |     - |     - |   18988 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
| LinqOptimizerWithoutOverhead | Job-OZWONA |      .NET 4.8 |        net48 |    2000 | 14,353.3 ns |  60.64 ns |  53.76 ns | 14,347.1 ns |  1.61 |    0.01 | 0.3204 |     - |     - |    1380 B |
| LinqOptimizerWithoutOverhead | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    2000 |  8,917.5 ns |  33.01 ns |  27.57 ns |  8,920.6 ns |  1.00 |    0.00 | 0.3204 |     - |     - |    1352 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|            LinqFasterChained | Job-OZWONA |      .NET 4.8 |        net48 |    2000 |  3,597.3 ns |  24.09 ns |  22.53 ns |  3,598.1 ns |  0.93 |    0.01 | 1.9379 |     - |     - |    8136 B |
|            LinqFasterChained | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    2000 |  3,874.6 ns |  73.35 ns |  61.25 ns |  3,855.7 ns |  1.00 |    0.00 | 1.9379 |     - |     - |    8112 B |
|                              |            |               |              |         |             |           |           |             |       |         |        |       |       |           |
|          LinqFasterOptimized | Job-OZWONA |      .NET 4.8 |        net48 |    2000 |  3,699.0 ns |   8.92 ns |   7.44 ns |  3,699.3 ns |  1.16 |    0.00 | 0.9766 |     - |     - |    4100 B |
|          LinqFasterOptimized | Job-ZIAZAH | .NET Core 3.1 | netcoreapp31 |    2000 |  3,180.4 ns |  11.04 ns |   9.79 ns |  3,177.8 ns |  1.00 |    0.00 | 0.9766 |     - |     - |    4088 B |