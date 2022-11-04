using Services.Contracts.Base;
using Services.Contracts.EquipmentModel;
using Services.Contracts.EquipmentPositionHistory;
using Services.Contracts.EquipmentStateHistory;

namespace Services.Contracts.Equipment
{
    public class EquipmentDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public Guid EquipmentModelId { get; set; }
        public EquipmentModelDto? EquipmentModel { get; set; }
        public IEnumerable<EquipmentStateHistoryDto>? EquipmentStateHistories { get; set; }
        public IEnumerable<EquipmentPositionHistoryDto>? EquipmentPositionHistories { get; set; }

    }
}
