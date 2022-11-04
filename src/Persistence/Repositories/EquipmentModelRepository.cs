using Domain.Interfaces.Repositories;
using Domain.Models;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EquipmentModelRepository : BaseRepository<EquipmentModel>, IEquipmentModelRepository
    {
        public EquipmentModelRepository(AppDbContext context) :base(context) {}
    }
}
