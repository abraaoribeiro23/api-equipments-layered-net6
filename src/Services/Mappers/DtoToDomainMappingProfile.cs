using AutoMapper;
using Domain.Models;
using Services.Contracts.Equipment;
using Services.Contracts.EquipmentModel;
using Services.Contracts.EquipmentModelStateHourlyEarning;
using Services.Contracts.EquipmentPositionHistory;
using Services.Contracts.EquipmentState;
using Services.Contracts.EquipmentStateHistory;

namespace Services.Mappers;

public class DtoToDomainMappingProfile : Profile
{
    public DtoToDomainMappingProfile()
    {
        CreateMap<EquipmentModelDto, EquipmentModel>();
        CreateMap<EquipmentModelCreateDto, EquipmentModel>();
        CreateMap<EquipmentModelUpdateDto, EquipmentModel>();

        CreateMap<EquipmentStateDto, EquipmentState>();
        CreateMap<EquipmentStateCreateDto, EquipmentState>();
        CreateMap<EquipmentStateUpdateDto, EquipmentState>();

        CreateMap<EquipmentDto, Equipment>();
        CreateMap<EquipmentCreateDto, Equipment>();
        CreateMap<EquipmentUpdateDto, Equipment>();

        CreateMap<EquipmentModelStateHourlyEarningDto, EquipmentModelStateHourlyEarning>();
        CreateMap<EquipmentModelStateHourlyEarningCreateDto, EquipmentModelStateHourlyEarning>();
        CreateMap<EquipmentModelStateHourlyEarningUpdateDto, EquipmentModelStateHourlyEarning>();

        CreateMap<EquipmentPositionHistoryDto, EquipmentPositionHistory>();
        CreateMap<EquipmentPositionHistoryCreateDto, EquipmentPositionHistory>();
        CreateMap<EquipmentPositionHistoryUpdateDto, EquipmentPositionHistory>();

        CreateMap<EquipmentStateHistoryDto, EquipmentStateHistory>();
        CreateMap<EquipmentStateHistoryCreateDto, EquipmentStateHistory>();
        CreateMap<EquipmentStateHistoryUpdateDto, EquipmentStateHistory>();
    }
}