using Aiko.Domain.Interfaces;
using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Infra.Context;

namespace Aiko.Infra.Repositories
{
    public class EquipmentModelStateHourlyEarningRepository : BaseRepository<EquipmentModelStateHourlyEarning>, IEquipmentModelStateHourlyEarningRepository
    {
        public EquipmentModelStateHourlyEarningRepository(AppDbContext context) : base(context) {}
    }
}
