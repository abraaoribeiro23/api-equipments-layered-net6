using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Aiko.Domain.Bases;

namespace Aiko.Domain.Models
{
    [Table("eqst_equipment_state")]
    public class EquipmentState : BaseEntity
    {
        [Column("eqst_tx_name", TypeName = "varchar")]
        [MaxLength(255)]
        public string Name  { get; set; }

        [Column("eqst_tx_color", TypeName = "varchar")]
        [MaxLength(255)]
        public string Color { get; set; }
    }
}