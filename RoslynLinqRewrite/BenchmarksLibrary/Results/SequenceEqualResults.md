|                                               Method |     Mean |    Error |   StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------------------------------- |---------:|---------:|---------:|-------:|------:|------:|----------:|
|                              ArraySequenceEqualArray | 41.33 ns | 0.086 ns | 0.072 ns | 0.0095 |     - |     - |      40 B |
|                     ArraySequenceEqualArrayRewritten | 21.74 ns | 0.186 ns | 0.165 ns | 0.0048 |     - |     - |      20 B |
|                    ArrayWhereSequenceEqualArrayWhere | 40.89 ns | 0.485 ns | 0.454 ns | 0.0095 |     - |     - |      40 B |
|           ArrayWhereSequenceEqualArrayWhereRewritten | 21.61 ns | 0.410 ns | 0.384 ns | 0.0048 |     - |     - |      20 B |
|                         ArraySequenceEqualEnumerable | 42.60 ns | 0.402 ns | 0.313 ns | 0.0105 |     - |     - |      44 B |
|                ArraySequenceEqualEnumerableRewritten | 20.22 ns | 0.368 ns | 0.344 ns | 0.0057 |     - |     - |      24 B |
|               ArrayWhereSequenceEqualEnumerableWhere | 42.35 ns | 0.434 ns | 0.385 ns | 0.0105 |     - |     - |      44 B |
|      ArrayWhereSequenceEqualEnumerableWhereRewritten | 21.14 ns | 0.303 ns | 0.283 ns | 0.0057 |     - |     - |      24 B |
|                         EnumerableSequenceEqualArray | 43.43 ns | 0.449 ns | 0.420 ns | 0.0105 |     - |     - |      44 B |
|                EnumerableSequenceEqualArrayRewritten | 30.97 ns | 0.411 ns | 0.385 ns | 0.0105 |     - |     - |      44 B |
|               EnumerableWhereSequenceEqualArrayWhere | 43.42 ns | 0.539 ns | 0.504 ns | 0.0105 |     - |     - |      44 B |
|      EnumerableWhereSequenceEqualArrayWhereRewritten | 31.02 ns | 0.269 ns | 0.252 ns | 0.0105 |     - |     - |      44 B |
|                    EnumerableSequenceEqualEnumerable | 46.38 ns | 0.203 ns | 0.159 ns | 0.0114 |     - |     - |      48 B |
|           EnumerableSequenceEqualEnumerableRewritten | 34.09 ns | 0.420 ns | 0.373 ns | 0.0114 |     - |     - |      48 B |
|          EnumerableWhereSequenceEqualEnumerableWhere | 46.03 ns | 0.493 ns | 0.461 ns | 0.0114 |     - |     - |      48 B |
| EnumerableWhereSequenceEqualEnumerableWhereRewritten | 34.36 ns | 0.687 ns | 0.735 ns | 0.0114 |     - |     - |      48 B |