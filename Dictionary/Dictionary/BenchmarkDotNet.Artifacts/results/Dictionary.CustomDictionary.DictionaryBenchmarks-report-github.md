```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4946/24H2/2024Update/HudsonValley)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.302
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI [AttachedDebugger]
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                  | Mean         | Error        | StdDev       | Gen0     | Gen1     | Gen2     | Allocated  |
|------------------------ |-------------:|-------------:|-------------:|---------:|---------:|---------:|-----------:|
| MyDictionary_Add        | 30,790.08 μs | 1,049.058 μs | 3,076.706 μs |  62.5000 |  31.2500 |  31.2500 | 16298002 B |
| DotNetDictionary_Add    |  6,533.25 μs |   128.871 μs |   196.799 μs | 148.4375 | 148.4375 | 109.3750 |  8452412 B |
| MyDictionary_Lookup     |    986.74 μs |    19.418 μs |    20.777 μs |        - |        - |        - |          - |
| DotNetDictionary_Lookup |    248.56 μs |     4.944 μs |     5.077 μs |        - |        - |        - |          - |
| MyDictionary_Remove     |  1,074.89 μs |    35.656 μs |   104.011 μs |        - |        - |        - |          - |
| DotNetDictionary_Remove |     76.07 μs |     1.500 μs |     2.705 μs |        - |        - |        - |          - |
