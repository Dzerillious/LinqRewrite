
|                                          Method |         Mean |         Error |        StdDev |       Median |
|------------------------------------------------ |-------------:|--------------:|--------------:|-------------:|
|                                     ArraySelect |    16.404 ns |     0.2571 ns |     0.2405 ns |    16.273 ns | x2.68
|                            ArraySelectRewritten |     6.154 ns |     0.0386 ns |     0.0322 ns |     6.143 ns |
|                              ArraySelectToArray | 1,063.851 ns |    16.5737 ns |    15.5031 ns | 1,073.009 ns | x70
|                     ArraySelectToArrayRewritten |    65.585 ns |     1.2573 ns |     1.1761 ns |    65.398 ns |
|                               ArraySelectMethod |    21.461 ns |     0.2658 ns |     0.2486 ns |    21.493 ns | x2.48
|                      ArraySelectMethodRewritten |     8.651 ns |     0.1558 ns |     0.1457 ns |     8.734 ns |
|                        ArraySelectMethodToArray | 1,016.042 ns |    17.4468 ns |    16.3198 ns | 1,022.410 ns | x15
|               ArraySelectMethodToArrayRewritten |    67.145 ns |     1.1490 ns |     1.0748 ns |    67.645 ns |
|                                ArraySelectArray |    17.098 ns |     0.2996 ns |     0.2803 ns |    17.228 ns | x2.69
|                       ArraySelectArrayRewritten |     6.301 ns |     0.1296 ns |     0.1212 ns |     6.371 ns |
|                         ArraySelectArrayToArray | 3,014.323 ns |    43.6154 ns |    40.7978 ns | 3,035.243 ns | x2.51
|                ArraySelectArrayToArrayRewritten | 1,200.528 ns |    19.1081 ns |    17.8737 ns | 1,206.868 ns |
|                             ArraySelectMultiple |   394.649 ns |     4.8444 ns |     4.5315 ns |   396.262 ns | x65.76
|                    ArraySelectMultipleRewritten |     6.079 ns |     0.1338 ns |     0.1118 ns |     6.118 ns | 
|                      ArraySelectMultipleToArray | 4,400.506 ns |    64.8515 ns |    60.6621 ns | 4,418.739 ns | x66.87
|             ArraySelectMultipleToArrayRewritten |    65.833 ns |     0.2144 ns |     0.2006 ns |    65.848 ns |
|                      ArraySelectComplexMultiple |   395.749 ns |     2.9415 ns |     2.6076 ns |   396.122 ns | x64.9
|             ArraySelectComplexMultipleRewritten |     6.105 ns |     0.1369 ns |     0.1280 ns |     6.151 ns |
|               ArraySelectComplexMultipleToArray | 4,307.731 ns |    62.6182 ns |    58.5731 ns | 4,337.605 ns | x29.9
|      ArraySelectComplexMultipleToArrayRewritten |   144.308 ns |     1.5443 ns |     1.2895 ns |   144.847 ns |
|                       ArraySelectMethodMultiple |   458.094 ns |     6.4973 ns |     6.0776 ns |   461.632 ns | x53.3
|              ArraySelectMethodMultipleRewritten |     8.609 ns |     0.1612 ns |     0.1508 ns |     8.709 ns |
|                ArraySelectMethodMultipleToArray | 4,225.344 ns |    68.3396 ns |    60.5813 ns | 4,252.956 ns | x64.2
|       ArraySelectMethodMultipleToArrayRewritten |    65.808 ns |     1.0529 ns |     0.9848 ns |    65.501 ns |
|                         EnumerableSelectToArray | 1,403.665 ns |    24.5374 ns |    20.4898 ns | 1,405.632 ns | x2.16
|                EnumerableSelectToArrayRewritten |   649.168 ns |     9.5847 ns |     8.9655 ns |   652.477 ns |
|                   EnumerableSelectMethodToArray | 1,406.435 ns |    19.7215 ns |    18.4475 ns | 1,414.881 ns | x2.16
|          EnumerableSelectMethodToArrayRewritten |   647.140 ns |    10.2166 ns |     9.5566 ns |   652.905 ns |
|                    EnumerableSelectArrayToArray | 3,421.189 ns |    55.5852 ns |    51.9944 ns | 3,401.855 ns | x2.05
|           EnumerableSelectArrayToArrayRewritten | 1,667.037 ns |    31.1643 ns |    29.1511 ns | 1,676.663 ns |