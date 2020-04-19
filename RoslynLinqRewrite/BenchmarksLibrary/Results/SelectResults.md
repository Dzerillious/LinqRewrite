|                                          Method |          Mean |          Error |         StdDev |        Median |
|------------------------------------------------ |--------------:|---------------:|---------------:|--------------:|
|                                     ArraySelect |     17.120 ns |      0.2149 ns |      0.2010 ns |     17.057 ns |
|                            ArraySelectRewritten |      6.695 ns |      0.1069 ns |      0.1000 ns |      6.688 ns | x3
|                              ArraySelectToArray |  8,815.234 ns |    118.4145 ns |    110.7650 ns |  8,862.946 ns |
|                     ArraySelectToArrayRewritten |    710.201 ns |     11.5635 ns |     10.8165 ns |    709.424 ns | x13
|                               ArraySelectMethod |     23.201 ns |      0.3996 ns |      0.3738 ns |     23.222 ns |
|                      ArraySelectMethodRewritten |      8.932 ns |      0.1811 ns |      0.1605 ns |      8.896 ns | x2.3
|                        ArraySelectMethodToArray |  8,847.712 ns |     52.8179 ns |     46.8217 ns |  8,844.841 ns |
|               ArraySelectMethodToArrayRewritten |    711.747 ns |     14.3076 ns |     13.3833 ns |    710.223 ns | x13
|                                ArraySelectArray |     18.442 ns |      0.1786 ns |      0.1671 ns |     18.496 ns |
|                       ArraySelectArrayRewritten |      6.964 ns |      0.1005 ns |      0.0940 ns |      6.937 ns | x3
|                         ArraySelectArrayToArray | 29,943.380 ns |    224.4146 ns |    209.9176 ns | 29,997.740 ns |
|                ArraySelectArrayToArrayRewritten | 12,763.323 ns |    109.1541 ns |     91.1486 ns | 12,775.567 ns | x2
|                             ArraySelectMultiple |    460.433 ns |      9.2002 ns |     21.3229 ns |    461.128 ns |
|                    ArraySelectMultipleRewritten |      6.733 ns |      0.1807 ns |      0.2285 ns |      6.696 ns | x70
|                      ArraySelectMultipleToArray | 40,321.530 ns |    835.0098 ns |  1,170.5671 ns | 39,937.170 ns |
|             ArraySelectMultipleToArrayRewritten |    703.484 ns |      9.2259 ns |      8.6299 ns |    702.946 ns | x560
|                      ArraySelectComplexMultiple |    420.001 ns |      4.5264 ns |      4.2340 ns |    421.628 ns |
|             ArraySelectComplexMultipleRewritten |      6.279 ns |      0.0739 ns |      0.0692 ns |      6.291 ns | x70
|               ArraySelectComplexMultipleToArray | 39,291.255 ns |    504.4996 ns |    471.9093 ns | 39,445.847 ns |
|      ArraySelectComplexMultipleToArrayRewritten |  1,402.750 ns |     13.6845 ns |     12.8005 ns |  1,403.863 ns | x30
|                       ArraySelectMethodMultiple |    497.653 ns |      4.7251 ns |      4.4198 ns |    495.376 ns |
|              ArraySelectMethodMultipleRewritten |      9.066 ns |      0.1389 ns |      0.1299 ns |      9.062 ns | x50
|                ArraySelectMethodMultipleToArray | 38,158.866 ns |    386.9621 ns |    343.0318 ns | 38,228.491 ns |
|       ArraySelectMethodMultipleToArrayRewritten |    699.415 ns |      6.9083 ns |      6.1240 ns |    700.556 ns | x50
|                         EnumerableSelectToArray | 13,719.663 ns |    148.2839 ns |    131.4498 ns | 13,738.519 ns |
|                EnumerableSelectToArrayRewritten |  5,928.829 ns |     75.2822 ns |     66.7357 ns |  5,948.785 ns | x2.5
|                   EnumerableSelectMethodToArray | 12,455.604 ns |     85.7081 ns |     71.5702 ns | 12,483.632 ns |
|          EnumerableSelectMethodToArrayRewritten |  5,902.731 ns |     63.1258 ns |     52.7129 ns |  5,928.750 ns | x2
|                    EnumerableSelectArrayToArray | 35,710.449 ns |    371.3700 ns |    347.3797 ns | 35,786.865 ns |
|           EnumerableSelectArrayToArrayRewritten | 17,751.482 ns |     85.0198 ns |     75.3679 ns | 17,765.666 ns | x2
|                 EnumerableSelectMultipleToArray | 43,021.796 ns |    534.9961 ns |    500.4356 ns | 43,146.936 ns |
|        EnumerableSelectMultipleToArrayRewritten |  5,918.534 ns |     82.6225 ns |     77.2851 ns |  5,935.986 ns | x8
|          EnumerableSelectComplexMultipleToArray | 59,684.385 ns | 22,718.8380 ns | 30,328.9962 ns | 43,178.946 ns |
| EnumerableSelectComplexMultipleToArrayRewritten |  6,920.568 ns |     69.5895 ns |     65.0941 ns |  6,933.302 ns | x10
|           EnumerableSelectMethodMultipleToArray | 38,126.190 ns |    648.1736 ns |    506.0513 ns | 38,219.012 ns |
|  EnumerableSelectMethodMultipleToArrayRewritten |    708.256 ns |      4.2203 ns |      3.9477 ns |    709.303 ns | x50
|                         ArraySelectToSimpleList |  7,362.374 ns |     82.4050 ns |     73.0499 ns |  7,377.127 ns |
|                ArraySelectToSimpleListRewritten |    582.259 ns |      9.3649 ns |      8.7600 ns |    578.774 ns | x16
|                        StaticArraySelectToArray |  8,901.797 ns |     93.4421 ns |     87.4058 ns |  8,931.834 ns |
|               StaticArraySelectToArrayRewritten |    702.007 ns |      8.0653 ns |      7.5443 ns |    699.718 ns | x14
|                   StaticClassArraySelectToArray |  1,046.038 ns |     14.7819 ns |     13.8270 ns |  1,041.298 ns |
|          StaticClassArraySelectToArrayRewritten |     78.963 ns |      0.7906 ns |      0.7395 ns |     79.177 ns | x15