using AutoMapper;
using Domain.Models;
using Services.Contracts.Equipment;
using Services.Contracts.EquipmentModel;
using Services.Contracts.EquipmentModelStateHourlyEarning;
using Services.Contracts.EquipmentPositionHistory;
using Services.Contracts.EquipmentState;
using Services.Contracts.EquipmentStateHistory;

namespace Services.Mappers;

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