|                             Method |          Mean |       Error |      StdDev |
|----------------------------------- |--------------:|------------:|------------:|
|                               Skip |      8.498 ns |   0.1552 ns |   0.1452 ns |
|                      SkipRewritten |      5.904 ns |   0.0915 ns |   0.0856 ns |
|                        SkipToArray |  7,780.634 ns | 134.0540 ns | 125.3942 ns |
|               SkipToArrayRewritten |    174.271 ns |   2.4235 ns |   2.1484 ns |
|                       SkipMultiple |     85.950 ns |   1.3267 ns |   1.2410 ns |
|              SkipMultipleRewritten |      5.860 ns |   0.0960 ns |   0.0898 ns |
|                SkipMultipleToArray | 48,916.759 ns | 854.0446 ns | 713.1660 ns |
|       SkipMultipleToArrayRewritten |    130.696 ns |   2.5652 ns |   2.3995 ns |
|              EnumerableSkipToArray |  8,588.502 ns | 112.5310 ns | 105.2616 ns |
|     EnumerableSkipToArrayRewritten |  5,346.919 ns |  78.8728 ns |  73.7777 ns |
|          EnumerableSkipMoreToArray | 48,612.054 ns | 659.0184 ns | 584.2027 ns |
| EnumerableSkipMoreToArrayRewritten |  7,839.697 ns | 150.5341 ns | 147.8446 ns |
|                   SkipToSimpleList |  7,555.341 ns | 123.4039 ns | 115.4321 ns |
|          SkipToSimpleListRewritten |    523.106 ns |   8.2094 ns |   7.6790 ns |
