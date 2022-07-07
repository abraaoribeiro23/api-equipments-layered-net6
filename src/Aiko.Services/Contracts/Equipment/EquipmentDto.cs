using Aiko.Domain.Models;
using Aiko.Services.Contracts.Base;
using Aiko.Services.Contracts.EquipmentModel;

namespace Aiko.Services.Contracts.Equipment
{
    public class EquipmentDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public Guid EquipmentModelId { get; set; }
        public EquipmentModelDto? EquipmentModel { get; set; }
        public IEnumerable<EquipmentStateHistory>? EquipmentStateHistories { get; set; }
        public IEnumerable<EquipmentPositionHistory>? EquipmentPositionHistories { get; set; }

    }
}
