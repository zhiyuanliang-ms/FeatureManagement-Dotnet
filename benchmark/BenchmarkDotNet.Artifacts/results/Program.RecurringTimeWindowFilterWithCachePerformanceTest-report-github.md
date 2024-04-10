```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700, 1 CPU, 20 logical and 12 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 6.0.28 (6.0.2824.12007), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.28 (6.0.2824.12007), X64 RyuJIT AVX2


```
| Method                                     | Mean     | Error   | StdDev  |
|------------------------------------------- |---------:|--------:|--------:|
| VanillaTimeWindowEvaluation                | 407.6 ns | 1.71 ns | 1.33 ns |
| DailyRecurringTimeWindowEvaluation         | 520.6 ns | 2.57 ns | 2.14 ns |
| WeeklyRecurringTimeWindowEvaluation        | 529.7 ns | 2.85 ns | 2.53 ns |
| ComplexWeeklyRecurringTimeWindowEvaluation | 548.4 ns | 2.81 ns | 2.49 ns |
