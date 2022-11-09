using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Extensions;

namespace Persistence.Configurations
{
    public class EquipmentStateConfiguration : IEntityTypeConfiguration<EquipmentState>
    {
        protected const string SeedJsonBasePath = "Persistence.SeedData";
        public void Configure(EntityTypeBuilder<EquipmentState> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("eqst_uuid_equipment_state");
            builder.HasKey(c => c.Id).HasName("pk_eqst_equipment_state");

            builder.InsertSeedData($"{SeedJsonBasePath}.equipment_state.json");
        }
    }
}
