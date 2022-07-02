using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentModelStateHourlyEarningConfiguration : IEntityTypeConfiguration<EquipmentModelStateHourlyEarning>
    {
        public void Configure(EntityTypeBuilder<EquipmentModelStateHourlyEarning> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("emsh_uuid_equipment_model_state_hourly_earning");
            builder.HasKey(c => c.Id).HasName("pk_emsh_equipment_model_state_hourly_earning");
        }
    }
}
