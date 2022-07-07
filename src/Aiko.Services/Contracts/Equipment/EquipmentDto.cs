using Aiko.Services.Contracts.Base;

namespace Aiko.Services.Contracts.Equipment
{
    public class EquipmentDto : BaseEntityDto
    {
        public Guid EquipmentModelId { get; set; }
        public string Name { get; set; }
        
    }
}
