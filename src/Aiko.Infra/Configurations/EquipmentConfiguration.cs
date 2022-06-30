using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("equi_uuid_equipment");
            builder.HasKey(c => c.Id).HasName("pk_equi_airplane");
        }
    }
}
