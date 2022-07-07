using Aiko.Domain.Models;
using Aiko.Services.Contracts.Equipment;
using Aiko.Services.Contracts.EquipmentModel;
using Aiko.Services.Contracts.EquipmentModelStateHourlyEarning;
using Aiko.Services.Contracts.EquipmentPositionHistory;
using Aiko.Services.Contracts.EquipmentState;
using Aiko.Services.Contracts.EquipmentStateHistory;
using AutoMapper;

namespace Aiko.Services.Mappers;

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