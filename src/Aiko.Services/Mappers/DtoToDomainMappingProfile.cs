using Aiko.Domain.Models;
using Aiko.Services.Contracts.Equipment;
using AutoMapper;

namespace Aiko.Services.Mappers;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<EquipmentDto, Equipment>();
        CreateMap<EquipmentCreateDto, Equipment>();
        CreateMap<EquipmentUpdateDto, Equipment>();
    }
}