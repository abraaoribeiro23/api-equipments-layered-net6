using Aiko.Services.Contracts.Base;

namespace Aiko.Services.Contracts.EquipmentState
{
    public class EquipmentStateUpdateDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
