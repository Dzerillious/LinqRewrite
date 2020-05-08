|                                                   Method |        Job |       Runtime |    Toolchain |     Mean |    Error |   StdDev | Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------------------------------------------- |----------- |-------------- |------------- |---------:|---------:|---------:|------:|--------:|--------:|-------:|------:|----------:|
|                                   ArrayUnionArrayToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 46.46 us | 0.333 us | 0.312 us |  1.33 |    0.02 | 21.1182 | 0.0610 |     - |   86.8 KB |
|                                   ArrayUnionArrayToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 35.00 us | 0.387 us | 0.362 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                          ArrayUnionArrayToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 30.82 us | 0.056 us | 0.047 us |  1.18 |    0.00 | 17.9443 |      - |     - |  73.75 KB |
|                          ArrayUnionArrayToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 26.12 us | 0.101 us | 0.094 us |  1.00 |    0.00 | 17.9443 | 0.0305 |     - |  73.55 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                         ArrayWhereUnionArrayWhereToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 46.10 us | 0.166 us | 0.155 us |  1.39 |    0.01 | 21.1182 | 0.0610 |     - |   86.8 KB |
|                         ArrayWhereUnionArrayWhereToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 33.18 us | 0.250 us | 0.221 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                ArrayWhereUnionArrayWhereToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 30.79 us | 0.088 us | 0.069 us |  1.15 |    0.00 | 17.9443 |      - |     - |  73.75 KB |
|                ArrayWhereUnionArrayWhereToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 26.71 us | 0.079 us | 0.070 us |  1.00 |    0.00 | 17.9443 | 0.0305 |     - |  73.55 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                              ArrayUnionEnumerableToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 46.13 us | 0.054 us | 0.051 us |  1.30 |    0.01 | 21.1182 | 0.0610 |     - |   86.8 KB |
|                              ArrayUnionEnumerableToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 35.54 us | 0.258 us | 0.242 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                     ArrayUnionEnumerableToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 34.39 us | 0.125 us | 0.111 us |  1.14 |    0.00 | 18.0664 |      - |     - |  74.21 KB |
|                     ArrayUnionEnumerableToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 30.03 us | 0.063 us | 0.056 us |  1.00 |    0.00 | 18.0664 | 0.0610 |     - |  73.98 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                    ArrayWhereUnionEnumerableWhereToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 45.47 us | 0.097 us | 0.081 us |  1.25 |    0.01 | 21.1182 | 0.0610 |     - |   86.8 KB |
|                    ArrayWhereUnionEnumerableWhereToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 36.39 us | 0.306 us | 0.271 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|           ArrayWhereUnionEnumerableWhereToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 34.38 us | 0.109 us | 0.096 us |  1.12 |    0.00 | 18.0664 |      - |     - |  74.21 KB |
|           ArrayWhereUnionEnumerableWhereToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 30.65 us | 0.084 us | 0.078 us |  1.00 |    0.00 | 18.0664 | 0.1221 |     - |  73.98 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                              EnumerableUnionArrayToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 46.45 us | 0.194 us | 0.172 us |  1.27 |    0.01 | 21.1182 | 0.0610 |     - |   86.8 KB |
|                              EnumerableUnionArrayToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 36.63 us | 0.358 us | 0.335 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                     EnumerableUnionArrayToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 34.55 us | 0.105 us | 0.099 us |  1.11 |    0.00 | 18.0664 |      - |     - |  74.21 KB |
|                     EnumerableUnionArrayToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 31.06 us | 0.131 us | 0.116 us |  1.00 |    0.00 | 18.0664 | 0.1221 |     - |  73.98 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                    EnumerableWhereUnionArrayWhereToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 46.39 us | 0.140 us | 0.124 us |  1.27 |    0.01 | 21.1182 | 0.0610 |     - |   86.8 KB |
|                    EnumerableWhereUnionArrayWhereToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 36.46 us | 0.277 us | 0.246 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|           EnumerableWhereUnionArrayWhereToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 34.59 us | 0.111 us | 0.104 us |  1.12 |    0.01 | 18.0664 |      - |     - |  74.21 KB |
|           EnumerableWhereUnionArrayWhereToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 30.89 us | 0.193 us | 0.181 us |  1.00 |    0.00 | 18.0664 | 0.1221 |     - |  73.98 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                         EnumerableUnionEnumerableToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 45.40 us | 0.180 us | 0.160 us |  1.19 |    0.01 | 21.1182 | 0.0610 |     - |   86.8 KB |
|                         EnumerableUnionEnumerableToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 38.20 us | 0.193 us | 0.181 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                EnumerableUnionEnumerableToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 38.35 us | 0.274 us | 0.228 us |  1.10 |    0.01 | 18.0664 |      - |     - |   74.2 KB |
|                EnumerableUnionEnumerableToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 34.88 us | 0.221 us | 0.185 us |  1.00 |    0.00 | 18.0664 | 2.9907 |     - |  74.01 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|               EnumerableWhereUnionEnumerableWhereToArray | Job-JQHHQI |      .NET 4.8 |        net48 | 45.45 us | 0.226 us | 0.201 us |  1.20 |    0.01 | 21.1182 | 0.0610 |     - |   86.8 KB |
|               EnumerableWhereUnionEnumerableWhereToArray | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 37.84 us | 0.155 us | 0.129 us |  1.00 |    0.00 | 17.1509 | 0.0610 |     - |  70.29 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|      EnumerableWhereUnionEnumerableWhereToArrayRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 38.30 us | 0.132 us | 0.110 us |  1.10 |    0.00 | 18.0664 |      - |     - |   74.2 KB |
|      EnumerableWhereUnionEnumerableWhereToArrayRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 34.99 us | 0.085 us | 0.066 us |  1.00 |    0.00 | 18.0664 | 2.9907 |     - |  74.01 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                              ArrayUnionArrayToSimpleList | Job-JQHHQI |      .NET 4.8 |        net48 | 44.75 us | 0.088 us | 0.069 us |  1.03 |    0.00 | 18.3105 |      - |     - |  75.43 KB |
|                              ArrayUnionArrayToSimpleList | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 43.57 us | 0.090 us | 0.080 us |  1.00 |    0.00 | 18.3105 | 0.0610 |     - |  75.21 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                     ArrayUnionArrayToSimpleListRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 30.06 us | 0.084 us | 0.066 us |  1.12 |    0.01 | 16.5100 | 0.0305 |     - |  67.93 KB |
|                     ArrayUnionArrayToSimpleListRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 26.75 us | 0.218 us | 0.203 us |  1.00 |    0.00 | 16.5100 | 2.7466 |     - |   67.7 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                    ArrayWhereUnionArrayWhereToSimpleList | Job-JQHHQI |      .NET 4.8 |        net48 | 44.71 us | 0.108 us | 0.101 us |  1.02 |    0.01 | 18.3105 |      - |     - |  75.43 KB |
|                    ArrayWhereUnionArrayWhereToSimpleList | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 43.75 us | 0.308 us | 0.257 us |  1.00 |    0.00 | 18.3105 | 0.0610 |     - |  75.21 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|           ArrayWhereUnionArrayWhereToSimpleListRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 30.28 us | 0.153 us | 0.128 us |  1.14 |    0.01 | 16.4795 | 0.0610 |     - |  67.93 KB |
|           ArrayWhereUnionArrayWhereToSimpleListRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 26.65 us | 0.265 us | 0.221 us |  1.00 |    0.00 | 16.5100 | 0.6409 |     - |   67.7 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|                    EnumerableUnionEnumerableToSimpleList | Job-JQHHQI |      .NET 4.8 |        net48 | 44.22 us | 0.110 us | 0.097 us |  1.03 |    0.00 | 18.3105 |      - |     - |  75.43 KB |
|                    EnumerableUnionEnumerableToSimpleList | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 42.73 us | 0.155 us | 0.137 us |  1.00 |    0.00 | 18.3105 | 0.0610 |     - |  75.21 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|           EnumerableUnionEnumerableToSimpleListRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 39.15 us | 0.105 us | 0.093 us |  1.16 |    0.01 | 16.6626 |      - |     - |  68.34 KB |
|           EnumerableUnionEnumerableToSimpleListRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 33.89 us | 0.253 us | 0.211 us |  1.00 |    0.00 | 16.6626 | 0.7324 |     - |  68.16 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
|          EnumerableWhereUnionEnumerableWhereToSimpleList | Job-JQHHQI |      .NET 4.8 |        net48 | 44.19 us | 0.074 us | 0.066 us |  0.95 |    0.00 | 18.3105 |      - |     - |  75.43 KB |
|          EnumerableWhereUnionEnumerableWhereToSimpleList | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 46.37 us | 0.110 us | 0.103 us |  1.00 |    0.00 | 18.3105 | 0.0610 |     - |  75.21 KB |
|                                                          |            |               |              |          |          |          |       |         |         |        |       |           |
| EnumerableWhereUnionEnumerableWhereToSimpleListRewritten | Job-JQHHQI |      .NET 4.8 |        net48 | 39.16 us | 0.103 us | 0.092 us |  1.19 |    0.01 | 16.6626 |      - |     - |  68.34 KB |
| EnumerableWhereUnionEnumerableWhereToSimpleListRewritten | Job-JQLEBD | .NET Core 3.1 | netcoreapp31 | 33.02 us | 0.200 us | 0.167 us |  1.00 |    0.00 | 16.6626 | 0.7324 |     - |  68.16 KB |