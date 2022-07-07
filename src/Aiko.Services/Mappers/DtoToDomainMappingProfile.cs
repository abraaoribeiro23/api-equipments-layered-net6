using Aiko.Domain.Models;
using Aiko.Services.Contracts.EquipmentModel;
using AutoMapper;

namespace Aiko.Services.Mappers;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<EquipmentModelDto, EquipmentModel>();
        CreateMap<EquipmentModelCreateDto, EquipmentModel>();
        CreateMap<EquipmentModelUpdateDto, EquipmentModel>();
    }
}