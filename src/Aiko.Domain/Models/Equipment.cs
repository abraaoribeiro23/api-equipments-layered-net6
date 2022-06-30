using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using Aiko.Domain.Bases;

namespace Aiko.Domain.Models
{
    [Table("equi_equipment")]
    public class Equipment : BaseEntity
    {
        public Equipment(Guid equipmentModelId, string name)
        {
            EquipmentModelId = equipmentModelId;
            Name = name;
        }

        public void Update(Guid equipmentModelId, string name)
        {
            EquipmentModelId = equipmentModelId;
            Name = name;
        }

        [Column("equi_uuid_equipment_model")]
        public Guid EquipmentModelId { get; set; }
        [Column("equi_tx_name", TypeName = "varchar")]
        public string Name { get; set; }
    }
}