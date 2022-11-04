using Services.Mappers;

namespace Api.Modules.Common;

public static class AutoMapperSetup
{
    public static IServiceCollection AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(
            typeof(DomainToDtoMappingProfile),
            typeof(DtoToDomainMappingProfile));

        return services;
    }
}