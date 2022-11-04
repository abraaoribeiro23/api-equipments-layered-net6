using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations
{
    public class EquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.Property(equipment => equipment.Id).HasColumnName("equi_uuid_equipment");
            builder.HasKey(c => c.Id).HasName("pk_equi_equipment");
            
            builder
                .HasOne(x => x.EquipmentModel)
                .WithMany()
                .HasForeignKey(x => x.EquipmentModelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.EquipmentStateHistories)
                .WithOne()
                .HasForeignKey(x => x.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.EquipmentPositionHistories)
                .WithOne()
                .HasForeignKey(x => x.EquipmentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
