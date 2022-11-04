using Services.Contracts.Base;

namespace Services.Contracts.Equipment
{
    public class EquipmentUpdateDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public Guid EquipmentModelId { get; set; }
    }
}
