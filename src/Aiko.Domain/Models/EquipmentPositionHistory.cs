using System.ComponentModel.DataAnnotations.Schema;
using Aiko.Domain.Bases;

namespace Aiko.Domain.Models
{
    [Table("eqph_equipment_position_history")]
    public class EquipmentPositionHistory : BaseEntity
    {
        [Column("eqph_uuid_equipment")]
        public Guid EquipmentId { get; set; }
        [Column("eqph_dt_date", TypeName = "datetime")]
        public DateTime Date { get; set; }
        [Column("eqph_nm_lat", TypeName = "double")]
        public double Lat { get; set; }
        [Column("eqph_nm_lon", TypeName = "double")]
        public double Lon { get; set; }
    }
}