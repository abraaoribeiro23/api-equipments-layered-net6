using Aiko.Services.Contracts.Base;
using Aiko.Services.Contracts.EquipmentModel;
using Aiko.Services.Contracts.EquipmentPositionHistory;
using Aiko.Services.Contracts.EquipmentStateHistory;

namespace Aiko.Services.Contracts.Equipment
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
