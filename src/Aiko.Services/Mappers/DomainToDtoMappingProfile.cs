using Aiko.Domain.Models;
using Aiko.Services.Contracts.Equipment;
using AutoMapper;

namespace Aiko.Services.Mappers;

public class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<Equipment, EquipmentDto>();
    }
}