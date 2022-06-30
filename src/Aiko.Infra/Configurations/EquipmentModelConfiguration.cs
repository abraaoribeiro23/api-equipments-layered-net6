using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentModelConfiguration : IEntityTypeConfiguration<EquipmentModel>
    {
        public void Configure(EntityTypeBuilder<EquipmentModel> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("equi_uuid_equipment_model");
            builder.HasKey(c => c.Id).HasName("pk_eqmo_equipment_model");
        }
    }
}
