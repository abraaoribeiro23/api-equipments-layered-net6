using Services.Contracts.Base;

namespace Services.Contracts.EquipmentPositionHistory
{
    public class EquipmentPositionHistoryDto : BaseEntityDto
    {
        public Guid EquipmentId { get; set; }
        public DateTime Date { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
    }
}
