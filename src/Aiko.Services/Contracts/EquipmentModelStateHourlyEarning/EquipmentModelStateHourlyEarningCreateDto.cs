namespace Aiko.Services.Contracts.EquipmentModelStateHourlyEarning
{
    public class EquipmentModelStateHourlyEarningCreateDto
    {
        public Guid EquipmentModelId { get; set; }
        public Guid EquipmentStateId { get; set; }
        public decimal Value { get; set; }
    }
}
