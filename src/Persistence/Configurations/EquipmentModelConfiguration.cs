using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Extensions;

namespace Persistence.Configurations
{
    public class EquipmentModelConfiguration : IEntityTypeConfiguration<EquipmentModel>
    {
        protected const string SeedJsonBasePath = "Persistence.SeedData";
        public void Configure(EntityTypeBuilder<EquipmentModel> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("eqmo_uuid_equipment_model");
            builder.HasKey(c => c.Id).HasName("pk_eqmo_equipment_model");

            builder.InsertSeedData($"{SeedJsonBasePath}.equipment_model.json");
        }
    }
}
