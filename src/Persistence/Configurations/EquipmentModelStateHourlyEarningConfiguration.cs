using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Extensions;

namespace Persistence.Configurations
{
    public class EquipmentModelStateHourlyEarningConfiguration
        : IEntityTypeConfiguration<EquipmentModelStateHourlyEarning>
    {
        protected const string SeedJsonBasePath = "Persistence.SeedData";
        public void Configure(EntityTypeBuilder<EquipmentModelStateHourlyEarning> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("emsh_uuid_equipment_model_state_hourly_earning");
            builder.HasKey(c => c.Id).HasName("pk_emsh_equipment_model_state_hourly_earning");

            builder.InsertSeedData($"{SeedJsonBasePath}.equipment_model_state_hourly_earnings.json");
        }
    }
}
