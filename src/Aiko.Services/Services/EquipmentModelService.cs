using Aiko.Domain.Interfaces;
using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;

namespace Aiko.Services.Services
{
    public class EquipmentModelService : BaseService<EquipmentModel>
    {
        public EquipmentModelService(IEquipmentModelRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
