using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Domain.Services
{
    public class EquipmentModelService : BaseService<EquipmentModel>
    {
        public EquipmentModelService(IEquipmentModelRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
