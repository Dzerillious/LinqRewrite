|                             Method |          Mean |       Error |      StdDev |        Median |
|----------------------------------- |--------------:|------------:|------------:|--------------:|
|                           ArrayAny |    17.9148 ns |   0.1367 ns |   0.1212 ns |    17.9176 ns |
|                  ArrayAnyRewritten |     0.0008 ns |   0.0017 ns |   0.0015 ns |     0.0000 ns | x18000
|                  ArrayAnyCondition |    45.3375 ns |   0.2187 ns |   0.1939 ns |    45.3326 ns |
|         ArrayAnyConditionRewritten |     3.8620 ns |   0.0272 ns |   0.0254 ns |     3.8663 ns | x15
|                     ArraySelectAny |    37.3026 ns |   0.4275 ns |   0.3789 ns |    37.2523 ns |
|            ArraySelectAnyRewritten |     0.0032 ns |   0.0063 ns |   0.0059 ns |     0.0000 ns | x10000
|                      ArrayWhereAny |   302.1664 ns |   2.5616 ns |   2.2708 ns |   302.9268 ns |
|             ArrayWhereAnyRewritten |    72.1824 ns |   0.3543 ns |   0.3314 ns |    72.2818 ns | x4
|             ArrayWhereAnyCondition | 1,100.5521 ns |  10.6160 ns |   9.9302 ns | 1,101.5743 ns |
|    ArrayWhereAnyConditionRewritten |   179.0177 ns |   2.4931 ns |   2.3321 ns |   178.0964 ns | x7
|             EnumerableAnyCondition |    47.0247 ns |   0.4271 ns |   0.3995 ns |    46.8764 ns |
|    EnumerableAnyConditionRewritten |    38.4910 ns |   0.1776 ns |   0.1661 ns |    38.4692 ns | x1.3
|          EnumerableAnyNotCondition | 5,797.9630 ns | 111.3019 ns | 140.7613 ns | 5,830.4592 ns |
| EnumerableAnyNotConditionRewritten | 4,345.6867 ns |  84.4086 ns |  86.6814 ns | 4,334.8381 ns | x1.25
|          EnumerableAnyAllCondition |    30.0262 ns |   0.6169 ns |   0.5770 ns |    30.1398 ns |
| EnumerableAnyAllConditionRewritten |    25.8279 ns |   0.3252 ns |   0.3042 ns |    25.8026 ns | x1.2