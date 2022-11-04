using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EquipmentStateHistoryRepository
        : BaseRepository<EquipmentStateHistory>, IEquipmentStateHistoryRepository
    {
        public EquipmentStateHistoryRepository(AppDbContext context) : base(context) {}
    }
}
