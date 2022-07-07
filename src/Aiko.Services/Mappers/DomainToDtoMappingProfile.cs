using Aiko.Domain.Models;
using Aiko.Services.Contracts.EquipmentModel;
using Aiko.Services.Contracts.EquipmentState;
using AutoMapper;

namespace Aiko.Services.Mappers;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<EquipmentModel, EquipmentModelDto>();
        CreateMap<EquipmentModel, EquipmentModelGetAllDto>();

        CreateMap<EquipmentState, EquipmentStateDto>();
        CreateMap<EquipmentState, EquipmentStateGetAllDto>();
    }
}