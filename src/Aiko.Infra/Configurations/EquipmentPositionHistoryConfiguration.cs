using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentPositionHistoryConfiguration : IEntityTypeConfiguration<EquipmentPositionHistory>
    {
        public void Configure(EntityTypeBuilder<EquipmentPositionHistory> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("eqph_uuid_equipment_position_history");
            builder.HasKey(c => c.Id).HasName("pk_eqph_equipment_position_history");
        }
    }
}
