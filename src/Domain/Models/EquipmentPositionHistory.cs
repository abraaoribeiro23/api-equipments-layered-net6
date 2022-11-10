using System.ComponentModel.DataAnnotations.Schema;
using Domain.Bases;

namespace Domain.Models
{
    [Table("eqph_equipment_position_history")]
    public class EquipmentPositionHistory : BaseEntity
    {
        [Column("eqph_uuid_equipment")]
        public Guid EquipmentId { get; set; }
        [Column("eqph_dt_date", TypeName = "timestamp")]
        public DateTime Date { get; set; }
        [Column("eqph_nm_lat", TypeName = "float")]
        public double Lat { get; set; }
        [Column("eqph_nm_lon", TypeName = "float")]
        public double Lon { get; set; }
    }
}