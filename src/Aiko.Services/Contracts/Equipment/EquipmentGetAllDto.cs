using Aiko.Services.Contracts.Base;
using Aiko.Services.Contracts.EquipmentModel;

namespace Aiko.Services.Contracts.Equipment
{
    public class EquipmentGetAllDto : BaseEntityDto
    {
        public string? Name { get; set; }
        public Guid EquipmentModelId { get; set; }
        public EquipmentModelDto? EquipmentModel { get; set; }

    }
}
