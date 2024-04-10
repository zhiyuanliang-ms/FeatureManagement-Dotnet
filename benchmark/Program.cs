using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

public class Program
{
    public class RecurringTimeWindowFilterWithoutCachePerformanceTest
    {
        private readonly IFeatureManager _featureManager;

        public RecurringTimeWindowFilterWithoutCachePerformanceTest()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var Cache = new MemoryCache(new MemoryCacheOptions());

            var timeWindowFilter = new TimeWindowFilter()
            {
                Cache = null
            };

            _featureManager = new FeatureManager(
                new ConfigurationFeatureDefinitionProvider(configuration))
            {
                FeatureFilters = new List<IFeatureFilterMetadata> { timeWindowFilter },
                Cache = Cache
            };
        }

        [Benchmark]
        public async Task VanillaTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("TimeWindowFeature");
        }

        [Benchmark]
        public async Task DailyRecurringTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("DailyRecurringTimeWindowFeature");
        }

        [Benchmark]
        public async Task WeeklyRecurringTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("WeeklyRecurringTimeWindowFeature");
        }

        [Benchmark]
        public async Task ComplexWeeklyRecurringTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("ComplexWeeklyRecurringTimeWindowFeature");
        }
    }

    public class RecurringTimeWindowFilterWithCachePerformanceTest
    {
        private readonly IFeatureManager _featureManager;

        public RecurringTimeWindowFilterWithCachePerformanceTest()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var Cache = new MemoryCache(new MemoryCacheOptions());

            var timeWindowFilterWithCache = new TimeWindowFilter()
            {
                Cache = Cache
            };

            _featureManager = new FeatureManager(
                new ConfigurationFeatureDefinitionProvider(configuration))
            {
                FeatureFilters = new List<IFeatureFilterMetadata> { timeWindowFilterWithCache },
                Cache = Cache
            };
        }

        [Benchmark]
        public async Task VanillaTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("TimeWindowFeature");
        }

        [Benchmark]
        public async Task DailyRecurringTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("DailyRecurringTimeWindowFeature");
        }

        [Benchmark]
        public async Task WeeklyRecurringTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("WeeklyRecurringTimeWindowFeature");
        }

        [Benchmark]
        public async Task ComplexWeeklyRecurringTimeWindowEvaluation()
        {
            await _featureManager.IsEnabledAsync("ComplexWeeklyRecurringTimeWindowFeature");
        }
    }

    public static void Main()
    {
        BenchmarkRunner.Run<RecurringTimeWindowFilterWithoutCachePerformanceTest>();

        BenchmarkRunner.Run<RecurringTimeWindowFilterWithCachePerformanceTest>();
    }
}