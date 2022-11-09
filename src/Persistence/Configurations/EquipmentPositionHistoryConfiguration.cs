using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Extensions;

namespace Persistence.Configurations
{
    public class EquipmentPositionHistoryConfiguration : IEntityTypeConfiguration<EquipmentPositionHistory>
    {
        protected const string SeedJsonBasePath = "Persistence.SeedData";
        public void Configure(EntityTypeBuilder<EquipmentPositionHistory> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("eqph_uuid_equipment_position_history");
            builder.HasKey(c => c.Id).HasName("pk_eqph_equipment_position_history");

            builder.InsertSeedData($"{SeedJsonBasePath}.equipment_position_history.json");
        }
    }
}
