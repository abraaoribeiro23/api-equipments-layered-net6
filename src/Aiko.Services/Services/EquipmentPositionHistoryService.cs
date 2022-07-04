using Aiko.Domain.Interfaces;
using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;

namespace Aiko.Services.Services
{
    public class EquipmentPositionHistoryService : BaseService<EquipmentPositionHistory>
    {
        public EquipmentPositionHistoryService(IEquipmentPositionHistoryRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
