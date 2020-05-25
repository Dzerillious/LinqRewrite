|                                                    Method |        Job |       Runtime |    Toolchain |     Mean |    Error |   StdDev | Ratio |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|---------------------------------------------------------- |----------- |-------------- |------------- |---------:|---------:|---------:|------:|--------:|-------:|------:|----------:|
|                                   ArrayExceptArrayToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 47.27 us | 0.216 us | 0.202 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|                                   ArrayExceptArrayToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 43.13 us | 0.239 us | 0.200 us |  0.91 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                          ArrayExceptArrayToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 34.29 us | 0.184 us | 0.163 us |  1.00 | 14.5874 |      - |     - |  59.98 KB |
|                          ArrayExceptArrayToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 28.63 us | 0.141 us | 0.132 us |  0.84 | 14.6179 | 0.0305 |     - |  59.84 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                         ArrayWhereExceptArrayWhereToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 47.20 us | 0.237 us | 0.222 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|                         ArrayWhereExceptArrayWhereToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 42.94 us | 0.246 us | 0.230 us |  0.91 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                ArrayWhereExceptArrayWhereToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 34.29 us | 0.149 us | 0.139 us |  1.00 | 14.5874 |      - |     - |  59.98 KB |
|                ArrayWhereExceptArrayWhereToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 28.76 us | 0.297 us | 0.278 us |  0.84 | 14.6179 | 0.0305 |     - |  59.84 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                              ArrayExceptEnumerableToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 46.49 us | 0.264 us | 0.247 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|                              ArrayExceptEnumerableToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 45.70 us | 0.248 us | 0.232 us |  0.98 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                     ArrayExceptEnumerableToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 38.89 us | 0.160 us | 0.150 us |  1.00 | 15.1367 |      - |     - |  62.23 KB |
|                     ArrayExceptEnumerableToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 33.53 us | 0.230 us | 0.216 us |  0.86 | 15.1367 |      - |     - |  62.05 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                    ArrayWhereExceptEnumerableWhereToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 46.44 us | 0.234 us | 0.219 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|                    ArrayWhereExceptEnumerableWhereToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 41.37 us | 0.149 us | 0.139 us |  0.89 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|           ArrayWhereExceptEnumerableWhereToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 38.68 us | 0.224 us | 0.210 us |  1.00 | 15.1367 |      - |     - |  62.23 KB |
|           ArrayWhereExceptEnumerableWhereToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 33.52 us | 0.186 us | 0.165 us |  0.87 | 15.1367 |      - |     - |  62.05 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                              EnumerableExceptArrayToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 46.50 us | 0.256 us | 0.227 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|                              EnumerableExceptArrayToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 42.54 us | 0.179 us | 0.168 us |  0.91 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                     EnumerableExceptArrayToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 39.92 us | 0.136 us | 0.127 us |  1.00 | 15.1367 |      - |     - |  62.23 KB |
|                     EnumerableExceptArrayToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 35.38 us | 0.400 us | 0.374 us |  0.89 | 15.1367 |      - |     - |  62.05 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                    EnumerableWhereExceptArrayWhereToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 46.55 us | 0.165 us | 0.154 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|                    EnumerableWhereExceptArrayWhereToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 42.87 us | 0.254 us | 0.225 us |  0.92 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|           EnumerableWhereExceptArrayWhereToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 39.91 us | 0.239 us | 0.212 us |  1.00 | 15.1367 |      - |     - |  62.23 KB |
|           EnumerableWhereExceptArrayWhereToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 34.88 us | 0.173 us | 0.162 us |  0.87 | 15.1367 |      - |     - |  62.05 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                         EnumerableExceptEnumerableToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 46.08 us | 0.167 us | 0.156 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|                         EnumerableExceptEnumerableToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 45.97 us | 0.196 us | 0.184 us |  1.00 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                EnumerableExceptEnumerableToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 43.48 us | 0.154 us | 0.144 us |  1.00 | 15.1367 |      - |     - |  62.23 KB |
|                EnumerableExceptEnumerableToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 39.20 us | 0.166 us | 0.155 us |  0.90 | 15.1367 | 0.0610 |     - |  62.08 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|               EnumerableWhereExceptEnumerableWhereToArray | Job-ANDRGH |      .NET 4.8 |        net48 | 46.13 us | 0.197 us | 0.185 us |  1.00 | 17.2119 |      - |     - |  70.75 KB |
|               EnumerableWhereExceptEnumerableWhereToArray | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 45.93 us | 0.222 us | 0.208 us |  1.00 | 16.7847 |      - |     - |  68.75 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|      EnumerableWhereExceptEnumerableWhereToArrayRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 43.25 us | 0.102 us | 0.085 us |  1.00 | 15.1367 |      - |     - |  62.23 KB |
|      EnumerableWhereExceptEnumerableWhereToArrayRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 39.31 us | 0.110 us | 0.097 us |  0.91 | 15.1367 | 0.0610 |     - |  62.08 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                              ArrayExceptArrayToSimpleList | Job-ANDRGH |      .NET 4.8 |        net48 | 46.60 us | 0.221 us | 0.207 us |  1.00 | 16.3574 |      - |     - |  67.36 KB |
|                              ArrayExceptArrayToSimpleList | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 44.36 us | 0.307 us | 0.288 us |  0.95 | 16.3574 | 1.4648 |     - |  67.21 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                     ArrayExceptArrayToSimpleListRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 33.92 us | 0.147 us | 0.137 us |  1.00 | 14.5874 |      - |     - |  60.05 KB |
|                     ArrayExceptArrayToSimpleListRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 28.12 us | 0.118 us | 0.098 us |  0.83 | 14.6179 | 0.0305 |     - |  59.87 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                    ArrayWhereExceptArrayWhereToSimpleList | Job-ANDRGH |      .NET 4.8 |        net48 | 46.60 us | 0.195 us | 0.183 us |  1.00 | 16.3574 |      - |     - |  67.36 KB |
|                    ArrayWhereExceptArrayWhereToSimpleList | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 44.61 us | 0.173 us | 0.162 us |  0.96 | 16.3574 | 1.5259 |     - |  67.21 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|           ArrayWhereExceptArrayWhereToSimpleListRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 33.90 us | 0.145 us | 0.136 us |  1.00 | 14.5874 |      - |     - |  60.05 KB |
|           ArrayWhereExceptArrayWhereToSimpleListRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 27.99 us | 0.107 us | 0.089 us |  0.83 | 14.6179 | 0.0305 |     - |  59.87 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|                    EnumerableExceptEnumerableToSimpleList | Job-ANDRGH |      .NET 4.8 |        net48 | 45.56 us | 0.234 us | 0.219 us |  1.00 | 16.3574 |      - |     - |  67.36 KB |
|                    EnumerableExceptEnumerableToSimpleList | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 45.05 us | 0.303 us | 0.283 us |  0.99 | 16.3574 | 1.5869 |     - |  67.21 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|           EnumerableExceptEnumerableToSimpleListRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 43.86 us | 0.163 us | 0.152 us |  1.00 | 14.6484 |      - |     - |  60.27 KB |
|           EnumerableExceptEnumerableToSimpleListRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 39.08 us | 0.177 us | 0.165 us |  0.89 | 14.6484 |      - |     - |  60.13 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
|          EnumerableWhereExceptEnumerableWhereToSimpleList | Job-ANDRGH |      .NET 4.8 |        net48 | 45.71 us | 0.153 us | 0.136 us |  1.00 | 16.3574 |      - |     - |  67.36 KB |
|          EnumerableWhereExceptEnumerableWhereToSimpleList | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 42.08 us | 0.217 us | 0.203 us |  0.92 | 16.3574 | 1.5259 |     - |  67.21 KB |
|                                                           |            |               |              |          |          |          |       |         |        |       |           |
| EnumerableWhereExceptEnumerableWhereToSimpleListRewritten | Job-ANDRGH |      .NET 4.8 |        net48 | 44.10 us | 0.268 us | 0.250 us |  1.00 | 14.6484 |      - |     - |  60.27 KB |
| EnumerableWhereExceptEnumerableWhereToSimpleListRewritten | Job-LZCWTD | .NET Core 3.1 | netcoreapp31 | 37.75 us | 0.179 us | 0.167 us |  0.86 | 14.6484 |      - |     - |  60.13 KB |