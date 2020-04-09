|                             Method |          Mean |       Error |      StdDev |
|----------------------------------- |--------------:|------------:|------------:|
|                               Skip |      8.905 ns |   0.1034 ns |   0.0968 ns |
|                      SkipRewritten |      6.275 ns |   0.0878 ns |   0.0821 ns |
|                        SkipToArray |  9,590.479 ns | 178.3897 ns | 175.2026 ns |
|               SkipToArrayRewritten |    154.546 ns |   1.6034 ns |   1.4214 ns |
|                       SkipMultiple |     98.595 ns |   1.9944 ns |   1.7680 ns |
|              SkipMultipleRewritten |      6.219 ns |   0.1429 ns |   0.1337 ns |
|                SkipMultipleToArray | 63,097.658 ns | 761.3040 ns | 674.8761 ns |
|       SkipMultipleToArrayRewritten |    119.012 ns |   2.4067 ns |   2.4715 ns |
|              EnumerableSkipToArray |  9,327.473 ns | 109.6760 ns |  91.5844 ns |
|     EnumerableSkipToArrayRewritten |  5,817.774 ns |  55.5877 ns |  49.2770 ns |
|          EnumerableSkipMoreToArray | 62,648.236 ns | 621.7254 ns | 581.5623 ns |
| EnumerableSkipMoreToArrayRewritten |  8,068.879 ns |  76.6148 ns |  71.6655 ns |
|                   SkipToSimpleList |  9,042.237 ns | 173.2087 ns | 162.0195 ns |
|          SkipToSimpleListRewritten |    509.359 ns |   5.3130 ns |   4.4366 ns |

|                             Method |          Mean |       Error |      StdDev |
|----------------------------------- |--------------:|------------:|------------:|
|                               Skip |      9.060 ns |   0.0948 ns |   0.0886 ns |
|                      SkipRewritten |      6.526 ns |   0.1244 ns |   0.1164 ns |
|                        SkipToArray |  9,619.795 ns | 112.3297 ns | 105.0732 ns |
|               SkipToArrayRewritten |    158.798 ns |   1.9264 ns |   1.7077 ns |
|                       SkipMultiple |     97.959 ns |   1.0705 ns |   1.0014 ns |
|              SkipMultipleRewritten |      6.432 ns |   0.1237 ns |   0.1157 ns |
|                SkipMultipleToArray | 63,143.808 ns | 867.2137 ns | 768.7624 ns |
|       SkipMultipleToArrayRewritten |    116.430 ns |   1.4384 ns |   1.1230 ns |
|              EnumerableSkipToArray |  9,282.781 ns |  83.1298 ns |  77.7597 ns |
|     EnumerableSkipToArrayRewritten |  5,814.771 ns |  63.5610 ns |  59.4550 ns |
|          EnumerableSkipMoreToArray | 62,702.469 ns | 958.8543 ns | 748.6104 ns |
| EnumerableSkipMoreToArrayRewritten |  8,088.607 ns | 125.2399 ns | 117.1495 ns |

|                             Method |          Mean |         Error |        StdDev |
|----------------------------------- |--------------:|--------------:|--------------:|
|                               Skip |     11.981 ns |     0.9013 ns |     2.6434 ns |
|                      SkipRewritten |      6.357 ns |     0.1609 ns |     0.2409 ns |
|                        SkipToArray |  9,808.436 ns |   195.4847 ns |   191.9922 ns |
|               SkipToArrayRewritten |    158.212 ns |     1.5938 ns |     1.4909 ns |
|                    SkipTakeToArray |  1,978.720 ns |    36.7728 ns |    34.3973 ns |
|           SkipTakeToArrayRewritten |     11.574 ns |     0.2379 ns |     0.2225 ns |
|                       SkipMultiple |     99.197 ns |     0.9095 ns |     0.7595 ns |
|              SkipMultipleRewritten |      6.217 ns |     0.1061 ns |     0.0992 ns |
|                SkipMultipleToArray | 62,892.797 ns | 1,078.7720 ns |   956.3033 ns |
|       SkipMultipleToArrayRewritten |    120.528 ns |     2.3390 ns |     3.0414 ns |
|              EnumerableSkipToArray |  9,516.332 ns |   185.0411 ns |   288.0866 ns |
|     EnumerableSkipToArrayRewritten |  5,895.338 ns |   114.5111 ns |   122.5256 ns |
|          EnumerableSkipMoreToArray | 62,885.360 ns | 1,241.7235 ns | 1,699.6851 ns |
| EnumerableSkipMoreToArrayRewritten |  8,186.699 ns |   150.4763 ns |   140.7556 ns |
|                   SkipToSimpleList |  8,933.214 ns |   143.0142 ns |   133.7756 ns |
|          SkipToSimpleListRewritten |    509.981 ns |     5.7655 ns |     5.3930 ns |

|                    Method |         Mean |      Error |     StdDev |
|-------------------------- |-------------:|-----------:|-----------:|
|           SkipTakeToArray |  1,958.70 ns |  25.677 ns |  24.019 ns |
|  SkipTakeToArrayRewritten |     11.39 ns |   0.247 ns |   0.264 ns |
|          SkipTakeToArray2 |  1,949.94 ns |  30.744 ns |  28.758 ns |
| SkipTakeToArrayRewritten2 |     18.87 ns |   0.244 ns |   0.228 ns |
|          SkipTakeToArray3 | 12,195.76 ns | 199.558 ns | 186.667 ns |
| SkipTakeToArrayRewritten3 |    206.35 ns |   1.596 ns |   1.493 ns |

|                    Method |         Mean |      Error |     StdDev |
|-------------------------- |-------------:|-----------:|-----------:|
|           SkipTakeToArray | 1,557.256 ns | 25.7191 ns | 24.0576 ns |
|  SkipTakeToArrayRewritten |     4.142 ns |  0.0558 ns |  0.0522 ns |
|          SkipTakeToArray2 | 1,571.544 ns | 30.7200 ns | 28.7355 ns |
| SkipTakeToArrayRewritten2 |    14.370 ns |  0.2231 ns |  0.1863 ns |

|                    Method |         Mean |      Error |     StdDev |
|-------------------------- |-------------:|-----------:|-----------:|
|           SkipTakeToArray | 1,509.575 ns | 22.7586 ns | 21.2884 ns |
|  SkipTakeToArrayRewritten |     2.951 ns |  0.0398 ns |  0.0372 ns |
|          SkipTakeToArray2 | 1,528.454 ns | 29.9855 ns | 29.4498 ns |
| SkipTakeToArrayRewritten2 |    13.900 ns |  0.2346 ns |  0.2195 ns |

|                                Method |          Mean |       Error |      StdDev |
|-------------------------------------- |--------------:|------------:|------------:|
|              SkipTakeToArrayUnchecked |     43.428 ns |   0.6435 ns |   0.6019 ns |
|     SkipTakeToArrayUncheckedRewritten |      2.413 ns |   0.0761 ns |   0.0906 ns |
|                       SkipTakeToArray |     42.213 ns |   0.8032 ns |   0.7513 ns |
|              SkipTakeToArrayRewritten |      9.298 ns |   0.1327 ns |   0.1241 ns |
|             SkipTakeToArrayUnchecked1 |     80.484 ns |   1.5283 ns |   1.4295 ns |
|    SkipTakeToArrayUncheckedRewritten1 |      2.890 ns |   0.0817 ns |   0.0765 ns |
|                      SkipTakeToArray1 |     80.036 ns |   1.2047 ns |   1.1269 ns |
|             SkipTakeToArrayRewritten1 |     13.091 ns |   0.2025 ns |   0.1894 ns |
|            SkipTakeToArrayUnchecked10 |    215.796 ns |   1.4871 ns |   1.3910 ns |
|   SkipTakeToArrayUncheckedRewritten10 |      7.011 ns |   0.1433 ns |   0.1341 ns |
|                     SkipTakeToArray10 |    217.936 ns |   3.3671 ns |   2.9849 ns |
|            SkipTakeToArrayRewritten10 |     15.040 ns |   0.2283 ns |   0.2135 ns |
|            SkipTakeToArrayUnchecked20 |    362.837 ns |   7.2851 ns |   7.1550 ns |
|   SkipTakeToArrayUncheckedRewritten20 |     11.075 ns |   0.2060 ns |   0.1927 ns |
|                     SkipTakeToArray20 |    366.685 ns |   6.7124 ns |   5.6051 ns |
|            SkipTakeToArrayRewritten20 |     18.328 ns |   0.2968 ns |   0.2631 ns |
|           SkipTakeToArrayUnchecked100 |  1,419.129 ns |  27.0610 ns |  25.3129 ns |
|  SkipTakeToArrayUncheckedRewritten100 |     38.964 ns |   0.5850 ns |   0.5472 ns |
|                    SkipTakeToArray100 |  1,419.517 ns |  27.3347 ns |  25.5689 ns |
|           SkipTakeToArrayRewritten100 |     42.438 ns |   0.8376 ns |   0.8227 ns |
|          SkipTakeToArrayUnchecked1000 | 12,036.626 ns | 229.7328 ns | 245.8115 ns |
| SkipTakeToArrayUncheckedRewritten1000 |    210.002 ns |   4.1479 ns |   3.8799 ns |
|                   SkipTakeToArray1000 | 12,171.876 ns | 146.8251 ns | 137.3403 ns |
|          SkipTakeToArrayRewritten1000 |    210.824 ns |   4.2487 ns |   4.1728 ns |

|                               Method |         Mean |      Error |     StdDev |
|------------------------------------- |-------------:|-----------:|-----------:|
|             SkipTakeToArrayUnchecked |    52.597 ns |  0.7798 ns |  0.7294 ns |
|    SkipTakeToArrayUncheckedRewritten |     2.362 ns |  0.0724 ns |  0.0677 ns |
|                      SkipTakeToArray |    51.665 ns |  0.8338 ns |  0.7799 ns |
|             SkipTakeToArrayRewritten |     9.342 ns |  0.0901 ns |  0.0843 ns |
|            SkipTakeToArrayUnchecked1 | 2,590.109 ns | 36.8401 ns | 34.4603 ns |
|   SkipTakeToArrayUncheckedRewritten1 |     2.958 ns |  0.0587 ns |  0.0549 ns |
|                     SkipTakeToArray1 | 2,573.183 ns | 39.5555 ns | 37.0002 ns |
|            SkipTakeToArrayRewritten1 |    13.886 ns |  0.3034 ns |  0.2838 ns |
|           SkipTakeToArrayUnchecked10 | 2,779.852 ns | 37.7952 ns | 33.5044 ns |
|  SkipTakeToArrayUncheckedRewritten10 |     6.978 ns |  0.1632 ns |  0.1676 ns |
|                    SkipTakeToArray10 | 2,791.540 ns | 29.6248 ns | 27.7110 ns |
|           SkipTakeToArrayRewritten10 |    15.005 ns |  0.3123 ns |  0.3207 ns |
|           SkipTakeToArrayUnchecked20 | 2,982.802 ns | 59.1609 ns | 55.3391 ns |
|  SkipTakeToArrayUncheckedRewritten20 |    10.874 ns |  0.1538 ns |  0.1439 ns |
|                    SkipTakeToArray20 | 3,011.534 ns | 40.5207 ns | 37.9031 ns |
|           SkipTakeToArrayRewritten20 |    18.695 ns |  0.3747 ns |  0.3505 ns |
|          SkipTakeToArrayUnchecked100 | 4,432.086 ns | 71.1981 ns | 66.5987 ns |
| SkipTakeToArrayUncheckedRewritten100 |    39.459 ns |  0.3677 ns |  0.3439 ns |
|                   SkipTakeToArray100 | 4,426.395 ns | 85.0223 ns | 83.5032 ns |
|          SkipTakeToArrayRewritten100 |    41.190 ns |  0.6237 ns |  0.5834 ns |