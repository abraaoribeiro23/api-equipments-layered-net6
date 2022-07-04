using Aiko.Services.Services;

namespace Aiko.Application.Modules.Common
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            services.AddScoped(typeof(EquipmentService));
            services.AddScoped(typeof(EquipmentModelService));
            services.AddScoped(typeof(EquipmentModelStateHourlyEarningService));
            services.AddScoped(typeof(EquipmentPositionHistoryService));
            services.AddScoped(typeof(EquipmentStateService));
            services.AddScoped(typeof(EquipmentStateHistoryService));
            return services;
        }
    }
}
