using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentStateConfiguration : IEntityTypeConfiguration<EquipmentState>
    {
        public void Configure(EntityTypeBuilder<EquipmentState> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("eqst_uuid_equipment_state");
            builder.HasKey(c => c.Id).HasName("pk_eqst_equipment_state");
        }
    }
}
