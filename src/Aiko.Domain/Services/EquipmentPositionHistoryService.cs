using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Domain.Services
{
    public class EquipmentPositionHistoryService : BaseService<EquipmentPositionHistory>
    {
        public EquipmentPositionHistoryService(IEquipmentPositionHistoryRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
