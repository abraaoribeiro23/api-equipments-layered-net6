using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Services.Services
{
    public class EquipmentStateService : BaseService<EquipmentState>
    {
        public EquipmentStateService(IEquipmentStateRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
