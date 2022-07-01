using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Domain.Services
{
    public class EquipmentStateService : BaseService<EquipmentState>
    {
        public EquipmentStateService(IBaseRepository<EquipmentState> repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
