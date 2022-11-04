using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Bases;

namespace Domain.Models
{
    [Table("eqmo_equipment_model")]
    public class EquipmentModel : BaseEntity
    {
        [Column("eqmo_tx_name", TypeName = "varchar")]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}