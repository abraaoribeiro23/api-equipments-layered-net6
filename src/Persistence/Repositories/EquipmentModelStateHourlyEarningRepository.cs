using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EquipmentModelStateHourlyEarningRepository
        : BaseRepository<EquipmentModelStateHourlyEarning>, IEquipmentModelStateHourlyEarningRepository
    {
        public EquipmentModelStateHourlyEarningRepository(AppDbContext context) : base(context) {}
    }
}
