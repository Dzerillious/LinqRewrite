|                             Method |       Mean |     Error |    StdDev |
|----------------------------------- |-----------:|----------:|----------:|
|                  ArrayAllCondition |  21.269 ns | 0.2532 ns | 0.2369 ns |
|         ArrayAllConditionRewritten |   1.133 ns | 0.0180 ns | 0.0160 ns | x20
|             ArrayWhereAllCondition | 337.049 ns | 4.7284 ns | 4.4229 ns |
|    ArrayWhereAllConditionRewritten |  69.409 ns | 0.5233 ns | 0.4639 ns | x5
|             EnumerableAllCondition |  21.002 ns | 0.1494 ns | 0.1247 ns |
|    EnumerableAllConditionRewritten |  19.096 ns | 0.1202 ns | 0.1066 ns | x1.1
|          EnumerableAllNotCondition |  21.048 ns | 0.1558 ns | 0.1381 ns |
| EnumerableAllNotConditionRewritten |  19.103 ns | 0.1050 ns | 0.0982 ns | x1.1
|          EnumerableAllAllCondition |  20.899 ns | 0.1810 ns | 0.1605 ns |
| EnumerableAllAllConditionRewritten |  18.942 ns | 0.1860 ns | 0.1649 ns | x1.1