using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentStateHistoryConfiguration : IEntityTypeConfiguration<EquipmentStateHistory>
    {
        public void Configure(EntityTypeBuilder<EquipmentStateHistory> builder)
        {
            builder.HasNoKey();
        }
    }
}
