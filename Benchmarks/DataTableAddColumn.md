``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1288 (21H1/May2021Update)
Intel Xeon CPU E3-1225 V2 3.20GHz, 1 CPU, 4 logical and 4 physical cores
.NET SDK=6.0.100
  [Host]   : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT
  .NET 6.0 : .NET 6.0.0 (6.0.21.52210), X64 RyuJIT

Job=.NET 6.0  Runtime=.NET 6.0  

```
|          Method |     Mean |     Error |    StdDev | Ratio | RatioSD |
|---------------- |---------:|----------:|----------:|------:|--------:|
|         AddBulk | 1.864 ms | 0.0366 ms | 0.0391 ms |  1.00 |    0.00 |
| AddByColumnName | 2.121 ms | 0.0246 ms | 0.0230 ms |  1.13 |    0.02 |
