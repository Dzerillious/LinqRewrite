|                               Method |          Mean |      Error |     StdDev |        Median |
|------------------------------------- |--------------:|-----------:|-----------:|--------------:|
|                           ArrayCount |    35.3193 ns |  0.1544 ns |  0.1444 ns |    35.3150 ns |
|                  ArrayCountRewritten |     0.0012 ns |  0.0036 ns |  0.0033 ns |     0.0000 ns | x30000
|                  ArrayCountCondition | 5,835.5837 ns | 45.4634 ns | 42.5265 ns | 5,828.8857 ns |
|         ArrayCountConditionRewritten |   578.0696 ns |  2.8551 ns |  2.6707 ns |   578.1410 ns | x10
|                     ArraySelectCount | 4,332.2522 ns | 41.0043 ns | 38.3554 ns | 4,324.9207 ns |
|            ArraySelectCountRewritten |     0.0005 ns |  0.0014 ns |  0.0013 ns |     0.0000 ns | x9 000 000
|                      ArrayWhereCount | 4,244.5176 ns | 22.5302 ns | 21.0748 ns | 4,244.7697 ns |
|             ArrayWhereCountRewritten |   616.0546 ns |  5.0733 ns |  4.7456 ns |   616.2005 ns | x7
|             ArrayWhereCountCondition | 6,716.9658 ns | 50.3816 ns | 47.1270 ns | 6,727.4677 ns |
|    ArrayWhereCountConditionRewritten |   628.0086 ns |  3.6717 ns |  3.2549 ns |   628.3654 ns | x10.5
|             EnumerableCountCondition | 5,738.8996 ns | 32.8992 ns | 30.7739 ns | 5,750.1888 ns |
|    EnumerableCountConditionRewritten | 4,526.7851 ns | 58.2269 ns | 54.4655 ns | 4,550.5119 ns | x1.4
|          EnumerableCountNotCondition | 6,249.6991 ns | 48.3577 ns | 42.8678 ns | 6,251.6560 ns |
| EnumerableCountNotConditionRewritten | 5,361.1202 ns | 30.0963 ns | 28.1521 ns | 5,355.4520 ns | x1.2
|          EnumerableCountAllCondition | 5,714.4656 ns | 28.6066 ns | 23.8878 ns | 5,721.4695 ns |
| EnumerableCountAllConditionRewritten | 4,518.5172 ns | 74.0201 ns | 65.6169 ns | 4,531.4175 ns | x1.4