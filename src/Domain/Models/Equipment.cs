﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Bases;

namespace Domain.Models
{
    [Table("equi_equipment")]
    public class Equipment : BaseEntity
    {
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