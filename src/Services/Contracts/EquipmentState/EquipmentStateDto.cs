using Services.Contracts.Base;

namespace Services.Contracts.EquipmentState
{
    public class EquipmentStateDto : BaseEntityDto
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
