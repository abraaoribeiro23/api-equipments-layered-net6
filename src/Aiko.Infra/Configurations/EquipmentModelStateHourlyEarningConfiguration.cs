using Aiko.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aiko.Infra.Configurations
{
    public class EquipmentModelStateHourlyEarningConfiguration : IEntityTypeConfiguration<EquipmentModelStateHourlyEarning>
    {
        public void Configure(EntityTypeBuilder<EquipmentModelStateHourlyEarning> builder)
        {
            builder.HasNoKey();
        }
    }
}
