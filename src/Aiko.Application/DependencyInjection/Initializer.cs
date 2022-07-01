using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;
using Aiko.Domain.Services;
using Aiko.Infra.Context;
using Aiko.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

namespace Aiko.Application.DependencyInjection
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services)
        {
            var featureManager = services
                .BuildServiceProvider()
                .GetRequiredService<IFeatureManager>();
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("test_database").EnableSensitiveDataLogging()
                    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            var context = services.BuildServiceProvider()
                .GetService<AppDbContext>();
            //CreateMemoryContextFake.AddDataFakeContext(context);

            #region Repositories

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseRepository<Equipment>), typeof(BaseRepository<Equipment>));
            services.AddScoped(typeof(IBaseRepository<EquipmentModel>), typeof(BaseRepository<EquipmentModel>));
            services.AddScoped(typeof(IBaseRepository<EquipmentModelStateHourlyEarning>), typeof(BaseRepository<EquipmentModelStateHourlyEarning>));
            services.AddScoped(typeof(IBaseRepository<EquipmentState>), typeof(BaseRepository<EquipmentState>));
            services.AddScoped(typeof(IBaseRepository<EquipmentStateHistory>), typeof(BaseRepository<EquipmentStateHistory>));
            services.AddScoped(typeof(IBaseRepository<EquipmentPositionHistory>), typeof(BaseRepository<EquipmentPositionHistory>));

            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            #endregion

            #region Services

            services.AddScoped(typeof(EquipmentService));
            services.AddScoped(typeof(EquipmentModelService));
            services.AddScoped(typeof(EquipmentModelStateHourlyEarningService));
            services.AddScoped(typeof(EquipmentPositionHistoryService));
            services.AddScoped(typeof(EquipmentStateService));
            services.AddScoped(typeof(EquipmentStateHistoryService));

            #endregion

        }
    }
}