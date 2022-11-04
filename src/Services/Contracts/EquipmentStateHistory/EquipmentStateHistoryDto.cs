using Services.Contracts.Base;

namespace Services.Contracts.EquipmentStateHistory
{
    public class EquipmentStateHistoryDto : BaseEntityDto
    {
        public Guid EquipmentId { get; set; }
        public Guid EquipmentStateId { get; set; }
        public DateTime Date { get; set; }
    }
}
