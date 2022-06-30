using System.ComponentModel.DataAnnotations.Schema;
using Aiko.Domain.Bases;

namespace Aiko.Domain.Models
{
    [Table("eqmo_equipment_model")]
    public class EquipmentModel : BaseEntity
    {
        [Column("eqmo_tx_name", TypeName = "varchar")]
        public string Name { get; set; }
    }
}