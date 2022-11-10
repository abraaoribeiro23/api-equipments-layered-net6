using System.ComponentModel.DataAnnotations.Schema;
using Domain.Bases;

namespace Domain.Models
{
    [Table("eqsh_equipment_state_history")]
    public class EquipmentStateHistory : BaseEntity
    {
        [Column("eqsh_uuid_equipment")]
        public Guid EquipmentId { get; set; }

        [Column("eqsh_uuid_equipment_state")]
        public Guid EquipmentStateId { get; set; }
        [Column("eqsh_dt_date", TypeName = "timestamp")]
        public DateTime Date { get; set; }
    }
}