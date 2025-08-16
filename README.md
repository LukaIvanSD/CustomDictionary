# CustomDictionary
## To run benchmark test build in release mode.
### [My benchmark results](https://github.com/LukaIvanSD/CustomDictionary/blob/main/Dictionary/Dictionary/BenchmarkDotNet.Artifacts/results/Dictionary.CustomDictionary.DictionaryBenchmarks-report-github.md):

| Method                  | Job        | InvocationCount | UnrollFactor | N       | Mean          | Error         | StdDev        | Median        | Gen0     | Gen1     | Gen2     | Allocated   |
|------------------------ |----------- |---------------- |------------- |-------- |--------------:|--------------:|--------------:|--------------:|---------:|---------:|---------:|------------:|
| MyDictionary_Add        | DefaultJob | Default         | 16           | 1000    |     109.01 us |      1.196 us |      1.061 us |     108.80 us |   0.7324 |   0.1221 |        - |    180480 B |
| DotNetDictionary_Add    | DefaultJob | Default         | 16           | 1000    |      24.81 us |      0.207 us |      0.161 us |      24.85 us |   0.3967 |   0.0305 |        - |    102216 B |
| MyDictionary_Lookup     | Job-CNUJVU | 1               | 1            | 1000    |      88.96 us |      2.974 us |      7.886 us |      88.10 us |        - |        - |        - |           - |
| DotNetDictionary_Lookup | Job-CNUJVU | 1               | 1            | 1000    |      33.29 us |      1.993 us |      5.845 us |      32.60 us |        - |        - |        - |           - |
| MyDictionary_Remove     | Job-CNUJVU | 1               | 1            | 1000    |      75.99 us |      3.601 us |      9.796 us |      75.70 us |        - |        - |        - |           - |
| DotNetDictionary_Remove | Job-CNUJVU | 1               | 1            | 1000    |      34.32 us |      1.878 us |      5.477 us |      33.20 us |        - |        - |        - |           - |
| MyDictionary_Add        | DefaultJob | Default         | 16           | 10000   |   1,784.66 us |     34.442 us |     47.144 us |   1,783.13 us |   9.7656 |   7.8125 |   3.9063 |   1734755 B |
| DotNetDictionary_Add    | DefaultJob | Default         | 16           | 10000   |     640.79 us |     12.709 us |     12.482 us |     645.18 us |  21.4844 |  21.4844 |  21.4844 |    942033 B |
| MyDictionary_Lookup     | Job-CNUJVU | 1               | 1            | 10000   |     522.44 us |     70.281 us |    207.227 us |     385.85 us |        - |        - |        - |           - |
| DotNetDictionary_Lookup | Job-CNUJVU | 1               | 1            | 10000   |     228.60 us |     20.431 us |     59.598 us |     210.45 us |        - |        - |        - |           - |
| MyDictionary_Remove     | Job-CNUJVU | 1               | 1            | 10000   |     315.66 us |     18.607 us |     53.386 us |     292.80 us |        - |        - |        - |           - |
| DotNetDictionary_Remove | Job-CNUJVU | 1               | 1            | 10000   |     246.16 us |     20.068 us |     58.220 us |     234.00 us |        - |        - |        - |           - |
| MyDictionary_Add        | DefaultJob | Default         | 16           | 100000  |  24,891.15 us |  1,070.216 us |  3,138.760 us |  26,357.65 us |  62.5000 |  31.2500 |  31.2500 |  16296962 B |
| DotNetDictionary_Add    | DefaultJob | Default         | 16           | 100000  |   6,199.64 us |     96.762 us |     85.777 us |   6,221.32 us | 117.1875 | 117.1875 | 117.1875 |   8452438 B |
| MyDictionary_Lookup     | Job-CNUJVU | 1               | 1            | 100000  |   5,841.46 us |    233.229 us |    638.461 us |   5,729.20 us |        - |        - |        - |           - |
| DotNetDictionary_Lookup | Job-CNUJVU | 1               | 1            | 100000  |   2,570.04 us |    124.736 us |    357.892 us |   2,462.50 us |        - |        - |        - |           - |
| MyDictionary_Remove     | Job-CNUJVU | 1               | 1            | 100000  |   4,689.55 us |    185.909 us |    518.239 us |   4,534.60 us |        - |        - |        - |           - |
| DotNetDictionary_Remove | Job-CNUJVU | 1               | 1            | 100000  |   2,682.71 us |    118.523 us |    338.152 us |   2,569.45 us |        - |        - |        - |           - |
| MyDictionary_Add        | DefaultJob | Default         | 16           | 1000000 | 734,579.44 us | 12,298.336 us | 10,902.154 us | 733,660.10 us |        - |        - |        - | 244236464 B |
| DotNetDictionary_Add    | DefaultJob | Default         | 16           | 1000000 |  75,177.90 us |  1,458.631 us |  2,183.210 us |  74,590.19 us | 142.8571 | 142.8571 | 142.8571 |  75443614 B |
| MyDictionary_Lookup     | Job-CNUJVU | 1               | 1            | 1000000 | 166,177.21 us |  2,285.205 us |  2,025.775 us | 165,793.65 us |        - |        - |        - |           - |
| DotNetDictionary_Lookup | Job-CNUJVU | 1               | 1            | 1000000 |  60,713.60 us |  1,853.337 us |  5,317.572 us |  60,622.50 us |        - |        - |        - |           - |
| MyDictionary_Remove     | Job-CNUJVU | 1               | 1            | 1000000 | 159,670.05 us |  3,766.844 us | 10,928.298 us | 156,082.10 us |        - |        - |        - |           - |
| DotNetDictionary_Remove | Job-CNUJVU | 1               | 1            | 1000000 |  54,585.39 us |  1,085.359 us |  2,265.549 us |  54,124.75 us |        - |        - |        - |           - |
