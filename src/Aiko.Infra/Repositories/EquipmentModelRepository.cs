using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;
using Aiko.Infra.Context;

namespace Aiko.Infra.Repositories
{
    public class EquipmentModelRepository : BaseRepository<EquipmentModel>, IEquipmentModelRepository
    {
        public EquipmentModelRepository(AppDbContext context) :base(context) {}
    }
}
