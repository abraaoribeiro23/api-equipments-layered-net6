using Aiko.Domain.Models;
using Aiko.Services.Contracts.Equipment;
using Aiko.Services.Contracts.EquipmentModel;
using AutoMapper;

namespace Aiko.Services.Mappers;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<EquipmentModel, EquipmentModelDto>();
        CreateMap<EquipmentModel, EquipmentModelGetAllDto>();
    }
}