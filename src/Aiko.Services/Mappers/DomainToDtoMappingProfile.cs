using Aiko.Domain.Models;
using Aiko.Services.Contracts.Equipment;
using Aiko.Services.Contracts.EquipmentModel;
using Aiko.Services.Contracts.EquipmentModelStateHourlyEarning;
using Aiko.Services.Contracts.EquipmentPositionHistory;
using Aiko.Services.Contracts.EquipmentState;
using Aiko.Services.Contracts.EquipmentStateHistory;
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

        CreateMap<Equipment, EquipmentDto>();
        CreateMap<Equipment, EquipmentGetAllDto>();

        CreateMap<EquipmentModelStateHourlyEarning, EquipmentModelStateHourlyEarningDto>();
        CreateMap<EquipmentModelStateHourlyEarning, EquipmentModelStateHourlyEarningGetAllDto>();

        CreateMap<EquipmentPositionHistory, EquipmentPositionHistoryDto>();
        CreateMap<EquipmentPositionHistory, EquipmentPositionHistoryGetAllDto>();

        CreateMap<EquipmentStateHistory, EquipmentStateHistoryDto>();
        CreateMap<EquipmentStateHistory, EquipmentStateHistoryGetAllDto>();
    }
}