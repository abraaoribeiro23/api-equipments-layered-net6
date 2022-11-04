using Api.Modules.Common.FeatureFlags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.FeatureManagement;
using Persistence.Context;

namespace Api.Modules.Common
{
    public static class InfraExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            var featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();

            var isMsSqlServerEnabled = featureManager
                .IsEnabledAsync(nameof(CustomFeature.MsSqlServer))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            var injectInitialData = featureManager
                .IsEnabledAsync(nameof(CustomFeature.InjectInitialData))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();

            if (isMsSqlServerEnabled)
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetValue<string>("PersistenceModule:MsSqlDbConnection")));
            }
            else
            {
                services.AddDbContext<AppDbContext>(options =>
                    options.UseInMemoryDatabase("test_database").EnableSensitiveDataLogging()
                        .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

                if (!injectInitialData) return services;

                var context = services.BuildServiceProvider()
                    .GetService<AppDbContext>();
                InMemoryContextFake.AddDataFakeContext(context);
            }
            return services;
        }
    }
}
