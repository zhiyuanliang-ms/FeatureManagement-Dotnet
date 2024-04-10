```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3296/23H2/2023Update/SunValley3)
12th Gen Intel Core i7-12700, 1 CPU, 20 logical and 12 physical cores
.NET SDK 8.0.202
  [Host]     : .NET 6.0.28 (6.0.2824.12007), X64 RyuJIT AVX2
  DefaultJob : .NET 6.0.28 (6.0.2824.12007), X64 RyuJIT AVX2


```
| Method                                     | Mean     | Error   | StdDev  |
|------------------------------------------- |---------:|--------:|--------:|
| VanillaTimeWindowEvaluation                | 408.6 ns | 1.78 ns | 1.58 ns |
| DailyRecurringTimeWindowEvaluation         | 497.7 ns | 1.28 ns | 1.14 ns |
| WeeklyRecurringTimeWindowEvaluation        | 616.7 ns | 1.81 ns | 1.51 ns |
| ComplexWeeklyRecurringTimeWindowEvaluation | 672.7 ns | 2.72 ns | 2.27 ns |
