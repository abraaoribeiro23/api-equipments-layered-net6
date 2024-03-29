﻿using System.ComponentModel.DataAnnotations.Schema;
using Domain.Bases;

namespace Domain.Models
{
    [Table("emsh_equipment_model_state_hourly_earning")]
    public class EquipmentModelStateHourlyEarning : BaseEntity
    {
        [Column("emsh_uuid_equipment_model")]
        public Guid EquipmentModelId { get; set; }
        [Column("emsh_uuid_equipment_state")]
        public Guid EquipmentStateId { get; set; }
        [Column("emsh_nm_value", TypeName = "decimal(18,2)")]
        public decimal Value { get; set; }
    }
}