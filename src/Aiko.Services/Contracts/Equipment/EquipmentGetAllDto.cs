using Aiko.Services.Contracts.Base;

namespace Aiko.Services.Contracts.Equipment
{
    public class EquipmentGetAllDto : BaseEntityDto
    {
        public Guid EquipmentModelId { get; set; }
        public string Name { get; set; }
        
    }
}
