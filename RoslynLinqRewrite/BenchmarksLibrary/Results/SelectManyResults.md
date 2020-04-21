|                        Method |      Mean |     Error |    StdDev |     Gen 0 |     Gen 1 |     Gen 2 | Allocated |
|------------------------------ |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
|               RangeSelectMany | 14.743 ms | 0.1014 ms | 0.0948 ms |  984.3750 |  984.3750 |  984.3750 |  11.86 MB |
|      RangeSelectManyRewritten |  9.355 ms | 0.1225 ms | 0.1086 ms | 1000.0000 | 1000.0000 | 1000.0000 |  14.51 MB |
|               ArraySelectMany | 14.343 ms | 0.1025 ms | 0.0959 ms |  984.3750 |  984.3750 |  984.3750 |  11.84 MB |
|      ArraySelectManyRewritten |  6.619 ms | 0.0397 ms | 0.0372 ms |  992.1875 |  992.1875 |  992.1875 |  14.48 MB |
|          EnumerableSelectMany | 14.652 ms | 0.0821 ms | 0.0768 ms |  984.3750 |  984.3750 |  984.3750 |  11.84 MB |
| EnumerableSelectManyRewritten | 10.110 ms | 0.0690 ms | 0.0612 ms | 1000.0000 | 1000.0000 | 1000.0000 |  14.51 MB |