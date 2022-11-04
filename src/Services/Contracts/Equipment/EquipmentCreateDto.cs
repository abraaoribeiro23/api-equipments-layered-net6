namespace Services.Contracts.Equipment
{
    public class EquipmentCreateDto
    {
        public string? Name { get; set; }
        public Guid EquipmentModelId { get; set; }
    }
}
