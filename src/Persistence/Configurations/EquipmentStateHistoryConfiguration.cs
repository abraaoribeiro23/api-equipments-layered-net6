using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Extensions;

namespace Persistence.Configurations
{
    public class EquipmentStateHistoryConfiguration : IEntityTypeConfiguration<EquipmentStateHistory>
    {
        protected const string SeedJsonBasePath = "Persistence.SeedData";
        public void Configure(EntityTypeBuilder<EquipmentStateHistory> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("eqsh_uuid_equipment_state_history");
            builder.HasKey(c => c.Id).HasName("pk_eqsh_equipment_state_history");

            builder.InsertSeedData($"{SeedJsonBasePath}.equipment_state_history.json");
        }
    }
}
