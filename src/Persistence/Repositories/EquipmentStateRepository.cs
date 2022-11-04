using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EquipmentStateRepository : BaseRepository<EquipmentState>, IEquipmentStateRepository
    {
        public EquipmentStateRepository(AppDbContext context) : base(context) {}
    }
}
