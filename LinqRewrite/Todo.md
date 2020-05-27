Possible improvements

Improve math optimization (For accepting division, for optimizing for program calculation, not for being nice)
Implement SIMD
Implement SelectMany copying by ArrayCopy
Implement ArrayCopy with fixed pointer
Implement remaining operators

Possible simple rewrites

Range(.Skip|.Take|.Distinct|.Reverse)*.Sum              -> (min + max) * count / 2
Range(.Skip|.Take|.Distinct|.Reverse)*.Average          -> (min + max) / 2
Range(.Skip|.Take|.Distinct|.Reverse)*.Count            -> count
Range(.Skip|.Take|.Distinct|.Reverse)*.ElementAt        -> min + arg[0]
Range(.Skip|.Take|.Distinct|.Reverse)*.First            -> min
Range(.Skip|.Take|.Distinct|.Reverse)*.FirstOrDefault   -> min
Range(.Skip|.Take|.Distinct|.Reverse)*.Last             -> max
Range(.Skip|.Take|.Distinct|.Reverse)*.LastOrDefault    -> max
Range(.Skip|.Take|.Distinct|.Reverse)*.Single           -> error
Range(.Skip|.Take|.Distinct|.Reverse)*.SingleOrDefault  -> error
Range(.Skip|.Take|.Distinct|.Reverse)*.Contains         -> arg[0] < max && arg[0] > min
Range.Select.First                                      -> arg[0](min)

Repeat(.Skip|.Take|.Distinct|.Reverse)*.Sum             -> element * count
Repeat(.Skip|.Take|.Distinct|.Reverse)*.Average         -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.Count           -> count
Repeat(.Skip|.Take|.Distinct|.Reverse)*.ElementAt       -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.First           -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.FirstOrDefault  -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.Last            -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.LastOrDefault   -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.Single          -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.SingleOrDefault -> element
Repeat(.Skip|.Take|.Distinct|.Reverse)*.Contains        -> arg[0] == element

Empty(.Skip|.Take|.Distinct|.Reverse)*.Sum             -> error
Empty(.Skip|.Take|.Distinct|.Reverse)*.Average         -> error
Empty(.Skip|.Take|.Distinct|.Reverse)*.Count           -> 0
Empty(.Skip|.Take|.Distinct|.Reverse)*.ElementAt       -> error
Empty(.Skip|.Take|.Distinct|.Reverse)*.First           -> error
Empty(.Skip|.Take|.Distinct|.Reverse)*.FirstOrDefault  -> default
Empty(.Skip|.Take|.Distinct|.Reverse)*.Last            -> error
Empty(.Skip|.Take|.Distinct|.Reverse)*.LastOrDefault   -> default
Empty(.Skip|.Take|.Distinct|.Reverse)*.Single          -> error
Empty(.Skip|.Take|.Distinct|.Reverse)*.SingleOrDefault -> default
Empty(.Skip|.Take|.Distinct|.Reverse)*.Contains        -> false


