|                       Method |          Mean |      Error |     StdDev |
|----------------------------- |--------------:|-----------:|-----------:|
|               RangeAggregate | 4,151.8734 ns | 19.2661 ns | 17.0789 ns |
|        RangeAggregateToArray |   550.4343 ns |  3.7559 ns |  3.5133 ns | x8
|              ArrayAggregate5 |    89.8640 ns |  0.7627 ns |  0.7134 ns |
|     ArrayAggregate5Rewritten |     0.5887 ns |  0.1347 ns |  0.1260 ns | x180
|             ArrayAggregate10 |   155.2360 ns |  1.6030 ns |  1.4994 ns | 
|    ArrayAggregate10Rewritten |     1.6706 ns |  0.2257 ns |  0.2111 ns | x120
|        ArrayWhereAggregate10 | 4,408.8863 ns | 30.6035 ns | 27.1292 ns |
| ArrayWhereAggregateRewritten |   692.7588 ns |  1.7673 ns |  1.4758 ns | x7
|          EnumerableAggregate | 4,004.5849 ns | 25.0372 ns | 20.9072 ns |
| EnumerableAggregateRewritten | 3,046.1073 ns | 32.4628 ns | 30.3657 ns | x1.33