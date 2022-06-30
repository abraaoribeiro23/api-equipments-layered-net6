using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentPositionHistoryConfiguration : IEntityTypeConfiguration<EquipmentPositionHistory>
    {
        public void Configure(EntityTypeBuilder<EquipmentPositionHistory> builder)
        {
            builder.HasNoKey();
        }
    }
}
