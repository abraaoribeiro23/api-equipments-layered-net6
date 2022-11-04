namespace Services.Contracts.EquipmentStateHistory
{
    public class EquipmentStateHistoryCreateDto
    {
        public Guid EquipmentId { get; set; }
        public Guid EquipmentStateId { get; set; }
        public DateTime Date { get; set; }
    }
}
