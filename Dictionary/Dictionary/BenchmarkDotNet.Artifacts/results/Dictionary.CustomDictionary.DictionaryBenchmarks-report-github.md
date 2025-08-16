```

BenchmarkDotNet v0.15.2, Windows 11 (10.0.26100.4946/24H2/2024Update/HudsonValley)
11th Gen Intel Core i7-11800H 2.30GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.302
  [Host]     : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI [AttachedDebugger]
  DefaultJob : .NET 8.0.18 (8.0.1825.31117), X64 RyuJIT AVX-512F+CD+BW+DQ+VL+VBMI


```
| Method                  | Mean         | Error      | StdDev     | Gen0     | Gen1     | Gen2     | Allocated  |
|------------------------ |-------------:|-----------:|-----------:|---------:|---------:|---------:|-----------:|
| MyDictionary_Add        | 32,501.44 μs | 625.400 μs | 813.196 μs | 125.0000 |  62.5000 |  62.5000 | 17812181 B |
| DotNetDictionary_Add    |  6,241.71 μs | 124.316 μs | 204.254 μs | 117.1875 | 117.1875 | 117.1875 |  8452440 B |
| MyDictionary_Lookup     |    967.01 μs |  17.792 μs |  16.643 μs |        - |        - |        - |          - |
| DotNetDictionary_Lookup |    243.45 μs |   4.687 μs |   4.384 μs |        - |        - |        - |          - |
| MyDictionary_Remove     |    869.28 μs |   9.196 μs |   7.679 μs |        - |        - |        - |          - |
| DotNetDictionary_Remove |     71.51 μs |   0.821 μs |   0.686 μs |        - |        - |        - |          - |
