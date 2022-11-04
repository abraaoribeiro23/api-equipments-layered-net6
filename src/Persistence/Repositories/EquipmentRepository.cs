using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories
{
    public class EquipmentRepository: BaseRepository<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(AppDbContext context) : base(context) {}

        public override IEnumerable<Equipment> GetAll()
        {
            return _dbSet
                .Include(equipment => equipment.EquipmentModel)
                .ToList();
        }
        public override Equipment? GetById(Guid id)
        {
            var query = _dbSet.Where(entity => entity.Id == id)
                .Include(equipment => equipment.EquipmentModel)
                .Include(equipment => equipment.EquipmentStateHistories)
                .Include(equipment => equipment.EquipmentPositionHistories);
            return query.Any() ? query.FirstOrDefault() : null;
        }
    }
}
