using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Domain.Services
{
    public class EquipmentService
    {
        private readonly IBaseRepository<Equipment> _repository;

        public EquipmentService(IBaseRepository<Equipment> repository)
        {
            _repository = repository;
        }
        public void Add(Guid equipmentModelId, string name)
        {
            _repository.Add(new Equipment(equipmentModelId, name));
        }
        public void Update(Guid id, Guid equipmentModelId, string name)
        {
            var equipment = _repository.GetById(id);
            equipment.Update(equipmentModelId, name);
            _repository.Update(equipment);
        }
    }
}
