|                               Method |         Mean |      Error |     StdDev |
|------------------------------------- |-------------:|-----------:|-----------:|
|             SkipTakeToArrayUnchecked |    52.597 ns |  0.7798 ns |  0.7294 ns |
|    SkipTakeToArrayUncheckedRewritten |     2.362 ns |  0.0724 ns |  0.0677 ns | x26
|                      SkipTakeToArray |    51.665 ns |  0.8338 ns |  0.7799 ns |
|             SkipTakeToArrayRewritten |     9.342 ns |  0.0901 ns |  0.0843 ns | x5.5
|            SkipTakeToArrayUnchecked1 | 2,590.109 ns | 36.8401 ns | 34.4603 ns |
|   SkipTakeToArrayUncheckedRewritten1 |     2.958 ns |  0.0587 ns |  0.0549 ns | x2200
|                     SkipTakeToArray1 | 2,573.183 ns | 39.5555 ns | 37.0002 ns |
|            SkipTakeToArrayRewritten1 |    13.886 ns |  0.3034 ns |  0.2838 ns | x200
|           SkipTakeToArrayUnchecked10 | 2,779.852 ns | 37.7952 ns | 33.5044 ns |
|  SkipTakeToArrayUncheckedRewritten10 |     6.978 ns |  0.1632 ns |  0.1676 ns | x400
|                    SkipTakeToArray10 | 2,791.540 ns | 29.6248 ns | 27.7110 ns |
|           SkipTakeToArrayRewritten10 |    15.005 ns |  0.3123 ns |  0.3207 ns | x200
|           SkipTakeToArrayUnchecked20 | 2,982.802 ns | 59.1609 ns | 55.3391 ns |
|  SkipTakeToArrayUncheckedRewritten20 |    10.874 ns |  0.1538 ns |  0.1439 ns | x300
|                    SkipTakeToArray20 | 3,011.534 ns | 40.5207 ns | 37.9031 ns |
|           SkipTakeToArrayRewritten20 |    18.695 ns |  0.3747 ns |  0.3505 ns | x150
|          SkipTakeToArrayUnchecked100 | 4,432.086 ns | 71.1981 ns | 66.5987 ns |
| SkipTakeToArrayUncheckedRewritten100 |    39.459 ns |  0.3677 ns |  0.3439 ns | x100
|                   SkipTakeToArray100 | 4,426.395 ns | 85.0223 ns | 83.5032 ns |
|          SkipTakeToArrayRewritten100 |    41.190 ns |  0.6237 ns |  0.5834 ns | x100