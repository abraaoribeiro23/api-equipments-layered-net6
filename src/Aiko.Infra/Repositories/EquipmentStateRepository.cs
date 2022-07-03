using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;
using Aiko.Infra.Context;

namespace Aiko.Infra.Repositories
{
    public class EquipmentStateRepository : BaseRepository<EquipmentState>, IEquipmentStateRepository
    {
        public EquipmentStateRepository(AppDbContext context) : base(context) {}
    }
}
