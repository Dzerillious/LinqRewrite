|                          Method | Offset |      Mean |     Error |    StdDev |
|-------------------------------- |------- |----------:|----------:|----------:|
|               ArrayWhereToArray |      0 | 283.78 ns |  4.525 ns |  4.233 ns |
|      ArrayWhereToArrayRewritten |      0 |  91.27 ns |  0.924 ns |  0.864 ns | x3.1
|          ArrayWhereToSimpleList |      0 | 269.40 ns |  3.159 ns |  2.955 ns | x1.05
| ArrayWhereToSimpleListRewritten |      0 |  88.04 ns |  1.071 ns |  1.002 ns | x3.2
|               ArrayWhereToArray |      1 | 297.87 ns |  4.269 ns |  3.993 ns | 
|      ArrayWhereToArrayRewritten |      1 |  96.82 ns |  1.240 ns |  1.160 ns | x3.06
|          ArrayWhereToSimpleList |      1 | 271.35 ns |  3.723 ns |  3.482 ns | x1.09
| ArrayWhereToSimpleListRewritten |      1 |  86.53 ns |  1.023 ns |  0.957 ns | x3.45
|               ArrayWhereToArray |      2 | 301.66 ns |  3.272 ns |  3.061 ns |
|      ArrayWhereToArrayRewritten |      2 |  97.83 ns |  1.102 ns |  0.921 ns | x3.1
|          ArrayWhereToSimpleList |      2 | 274.93 ns |  4.051 ns |  3.790 ns | x1.09
| ArrayWhereToSimpleListRewritten |      2 |  87.60 ns |  1.021 ns |  0.955 ns | x3.45
|               ArrayWhereToArray |      5 | 331.20 ns |  5.167 ns |  4.833 ns |
|      ArrayWhereToArrayRewritten |      5 | 101.29 ns |  1.127 ns |  1.054 ns | x3.27
|          ArrayWhereToSimpleList |      5 | 289.69 ns |  4.302 ns |  4.025 ns | x1.145
| ArrayWhereToSimpleListRewritten |      5 |  89.18 ns |  1.399 ns |  1.309 ns | x3.71
|               ArrayWhereToArray |     10 | 372.84 ns |  5.259 ns |  4.920 ns |
|      ArrayWhereToArrayRewritten |     10 | 137.97 ns |  2.226 ns |  2.082 ns | x2.71
|          ArrayWhereToSimpleList |     10 | 333.93 ns |  4.802 ns |  4.492 ns | x1.11
| ArrayWhereToSimpleListRewritten |     10 | 119.70 ns |  0.866 ns |  0.810 ns | x3.12
|               ArrayWhereToArray |     20 | 438.02 ns |  5.193 ns |  4.858 ns |
|      ArrayWhereToArrayRewritten |     20 | 152.08 ns |  2.429 ns |  2.272 ns | x2.88
|          ArrayWhereToSimpleList |     20 | 408.80 ns |  6.271 ns |  5.865 ns | x1.07
| ArrayWhereToSimpleListRewritten |     20 | 124.05 ns |  1.770 ns |  1.656 ns | x3.53
|               ArrayWhereToArray |     50 | 638.62 ns |  8.122 ns |  7.597 ns |
|      ArrayWhereToArrayRewritten |     50 | 202.68 ns |  2.328 ns |  2.178 ns | x3.15
|          ArrayWhereToSimpleList |     50 | 622.61 ns | 10.058 ns |  9.409 ns | x1.02
| ArrayWhereToSimpleListRewritten |     50 | 140.40 ns |  1.508 ns |  1.410 ns | x4.55
|               ArrayWhereToArray |    100 | 908.04 ns | 15.523 ns | 14.521 ns |
|      ArrayWhereToArrayRewritten |    100 | 229.70 ns |  3.036 ns |  2.839 ns | x3.96
|          ArrayWhereToSimpleList |    100 | 892.49 ns | 14.653 ns | 13.706 ns | x1.01
| ArrayWhereToSimpleListRewritten |    100 | 164.96 ns |  1.176 ns |  1.100 ns | x5.5
|               ArrayWhereToArray |    200 | 911.34 ns | 13.607 ns | 12.728 ns |
|      ArrayWhereToArrayRewritten |    200 | 230.12 ns |  2.773 ns |  2.594 ns | x3.96
|          ArrayWhereToSimpleList |    200 | 894.54 ns | 12.837 ns | 12.007 ns | x1.01
| ArrayWhereToSimpleListRewritten |    200 | 163.96 ns |  1.718 ns |  1.607 ns | x5.59
|               ArrayWhereToArray |    500 | 904.53 ns | 14.314 ns | 13.390 ns |
|      ArrayWhereToArrayRewritten |    500 | 235.83 ns |  1.027 ns |  0.961 ns | x3.84
|          ArrayWhereToSimpleList |    500 | 889.74 ns | 12.865 ns | 12.034 ns | x1.016
| ArrayWhereToSimpleListRewritten |    500 | 163.87 ns |  2.224 ns |  2.080 ns | x5.54