using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;
using Aiko.Infra.Context;

namespace Aiko.Infra.Repositories
{
    public class EquipmentPositionHistoryRepository : BaseRepository<EquipmentPositionHistory>, IEquipmentPositionHistoryRepository
    {
        public EquipmentPositionHistoryRepository(AppDbContext context) : base(context) {}
    }
}
