using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentStateHistoryConfiguration : IEntityTypeConfiguration<EquipmentStateHistory>
    {
        public void Configure(EntityTypeBuilder<EquipmentStateHistory> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("eqsh_uuid_equipment_state_history");
            builder.HasKey(c => c.Id).HasName("pk_eqsh_equipment_state_history");
        }
    }
}
