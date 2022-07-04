using Aiko.Domain.Interfaces;
using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Infra.Context;

namespace Aiko.Infra.Repositories
{
    public class EquipmentStateHistoryRepository : BaseRepository<EquipmentStateHistory>, IEquipmentStateHistoryRepository
    {
        public EquipmentStateHistoryRepository(AppDbContext context) : base(context) {}
    }
}
