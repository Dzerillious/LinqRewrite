
|                                                    Method |      Mean |     Error |    StdDev |
|---------------------------------------------------------- |----------:|----------:|----------:|
|                                   ArrayConcatArrayToArray | 21.290 us | 0.1812 us | 0.1606 us |
|                          ArrayConcatArrayToArrayRewritten |  1.507 us | 0.0119 us | 0.0106 us | x12
|                         ArrayWhereConcatArrayWhereToArray | 21.057 us | 0.1157 us | 0.1082 us |
|                ArrayWhereConcatArrayWhereToArrayRewritten |  1.493 us | 0.0088 us | 0.0078 us | x12
|                              ArrayConcatEnumerableToArray | 21.269 us | 0.1710 us | 0.1600 us |
|                     ArrayConcatEnumerableToArrayRewritten |  8.936 us | 0.0607 us | 0.0568 us | x2.5
|                    ArrayWhereConcatEnumerableWhereToArray | 21.306 us | 0.1498 us | 0.1401 us |
|           ArrayWhereConcatEnumerableWhereToArrayRewritten |  8.853 us | 0.0569 us | 0.0504 us | x2.5
|                              EnumerableConcatArrayToArray | 21.289 us | 0.1574 us | 0.1472 us |
|                     EnumerableConcatArrayToArrayRewritten |  8.567 us | 0.1205 us | 0.0941 us | x2.5
|                    EnumerableWhereConcatArrayWhereToArray | 21.253 us | 0.1815 us | 0.1698 us |
|           EnumerableWhereConcatArrayWhereToArrayRewritten |  8.498 us | 0.1170 us | 0.1095 us | x2.5
|                         EnumerableConcatEnumerableToArray | 21.555 us | 0.1554 us | 0.1453 us |
|                EnumerableConcatEnumerableToArrayRewritten | 10.450 us | 0.0787 us | 0.0697 us | x2
|               EnumerableWhereConcatEnumerableWhereToArray | 21.567 us | 0.1417 us | 0.1256 us |
|      EnumerableWhereConcatEnumerableWhereToArrayRewritten | 10.492 us | 0.0842 us | 0.0787 us | x2
|                              ArrayConcatArrayToSimpleList | 20.821 us | 0.3511 us | 0.3284 us |
|                     ArrayConcatArrayToSimpleListRewritten |  2.146 us | 0.0204 us | 0.0181 us | x10
|                    ArrayWhereConcatArrayWhereToSimpleList | 20.771 us | 0.2141 us | 0.2003 us |
|           ArrayWhereConcatArrayWhereToSimpleListRewritten |  2.139 us | 0.0291 us | 0.0272 us | x10
|                    EnumerableConcatEnumerableToSimpleList | 22.213 us | 0.1149 us | 0.1075 us |
|           EnumerableConcatEnumerableToSimpleListRewritten | 11.048 us | 0.0946 us | 0.0885 us | x2
|          EnumerableWhereConcatEnumerableWhereToSimpleList | 22.271 us | 0.1605 us | 0.1501 us |
| EnumerableWhereConcatEnumerableWhereToSimpleListRewritten | 11.059 us | 0.1268 us | 0.1186 us | x2