using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Domain.Services
{
    public class EquipmentStateHistoryService : BaseService<EquipmentStateHistory>
    {
        public EquipmentStateHistoryService(IBaseRepository<EquipmentStateHistory> repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
