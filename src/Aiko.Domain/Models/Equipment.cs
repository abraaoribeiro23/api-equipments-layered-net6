using System.ComponentModel.DataAnnotations;
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
        [Column("equi_tx_name", TypeName = "varchar")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("equi_uuid_equipment_model")]
        [Required]
        public Guid EquipmentModelId { get; set; }
        public virtual EquipmentModel? EquipmentModel { get; set; }
        public virtual IEnumerable<EquipmentStateHistory>? EquipmentStateHistories { get; set; }
        public virtual IEnumerable<EquipmentPositionHistory>? EquipmentPositionHistories { get; set; }
    }
}