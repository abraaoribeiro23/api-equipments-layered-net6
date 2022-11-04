using Services.Contracts.Base;

namespace Services.Contracts.EquipmentModelStateHourlyEarning
{
    public class EquipmentModelStateHourlyEarningDto : BaseEntityDto
    {
        public Guid EquipmentModelId { get; set; }
        public Guid EquipmentStateId { get; set; }
        public decimal Value { get; set; }
    }
}
