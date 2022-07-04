using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Services.Services
{
    public class EquipmentStateHistoryService : BaseService<EquipmentStateHistory>
    {
        public EquipmentStateHistoryService(IEquipmentStateHistoryRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
