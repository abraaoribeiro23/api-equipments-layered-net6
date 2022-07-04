﻿using Aiko.Domain.Interfaces;
using Aiko.Domain.Interfaces.Repositories;
using Aiko.Infra.Repositories;

namespace Aiko.Application.Modules.Common
{
    public static class EntityRepositoryExtensions
    {
        public static IServiceCollection AddEntityRepository(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IEquipmentRepository), typeof(EquipmentRepository));
            services.AddScoped(typeof(IEquipmentModelRepository), typeof(EquipmentModelRepository));
            services.AddScoped(typeof(IEquipmentModelStateHourlyEarningRepository), typeof(EquipmentModelStateHourlyEarningRepository));
            services.AddScoped(typeof(IEquipmentStateRepository), typeof(EquipmentStateRepository));
            services.AddScoped(typeof(IEquipmentStateHistoryRepository), typeof(EquipmentStateHistoryRepository));
            services.AddScoped(typeof(IEquipmentPositionHistoryRepository), typeof(EquipmentPositionHistoryRepository));
            
            return services;
        }
    }
}
