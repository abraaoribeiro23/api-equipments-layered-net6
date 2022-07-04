using Aiko.Domain.Interfaces;
using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;

namespace Aiko.Services.Services
{
    public class EquipmentService: BaseService<Equipment>
    {
        public EquipmentService(IEquipmentRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
