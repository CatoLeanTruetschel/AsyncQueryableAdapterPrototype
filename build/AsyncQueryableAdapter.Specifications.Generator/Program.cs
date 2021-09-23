using System;
using System.Threading.Tasks;
using AsyncQueryableAdapter.Specifications.Generator.Parameters;
using AsyncQueryableAdapter.Specifications.Generator.Tests;
using Microsoft.Extensions.DependencyInjection;

namespace AsyncQueryableAdapter.Specifications.Generator
{
    internal static class Program
    {
        private static string _outputDirectory = null!;

        private static async Task Main(string[] args)
        {
            _outputDirectory = args[0];

            var serviceProvider = ConfigureServices();
            var generator = ActivatorUtilities.GetServiceOrCreateInstance<SpecificationBuilder>(serviceProvider);
            await generator.GenerateTestCasesAsync().ConfigureAwait(false);
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            return services.BuildServiceProvider(validateScopes: true);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.Configure<ApplicationOptions>(options => options.OutputDirectory = _outputDirectory);
            services.AddSingleton<SpecificationBuilder>();

            // Const registries
            services.AddSingleton<KnownNamespaces>();
            services.AddSingleton<KnownCollectionTypes>();

            // Parameter evaluators
            services.AddSingleton<IParameterEvaluator, QueryableParameterEvaluator>();
            services.AddSingleton<IParameterEvaluator, EqualityComparerParameterEvaluator>();
            services.AddSingleton<IParameterEvaluator, ComparerParameterEvaluator>();
            services.AddSingleton<IParameterEvaluator, LambdaParameterEvaluator>();
            services.AddSingleton<IParameterEvaluator, IntegratedNumericTypeParameterEvaluator>();

            // ParametersBuilder
            services.AddSingleton<ParametersBuilder>();

            // Test case generators
            services.AddSingleton<ITestCaseGenerator, EquivalenceTestCaseGenerator>();
            services.AddSingleton<ITestCaseGenerator, CanceledTestCaseGenerator>();
            services.AddSingleton<ITestCaseGenerator, NullParameterTestCaseGenerator>();
        }
    }
}
