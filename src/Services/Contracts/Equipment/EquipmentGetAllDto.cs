using Services.Contracts.Base;
using Services.Contracts.EquipmentModel;

namespace Services.Contracts.Equipment
{
    public class EquipmentGetAllDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public Guid EquipmentModelId { get; set; }
        public EquipmentModelDto? EquipmentModel { get; set; }

    }
}
