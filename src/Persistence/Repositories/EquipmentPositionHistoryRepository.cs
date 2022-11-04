using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EquipmentPositionHistoryRepository
        : BaseRepository<EquipmentPositionHistory>, IEquipmentPositionHistoryRepository
    {
        public EquipmentPositionHistoryRepository(AppDbContext context) : base(context) {}
    }
}
