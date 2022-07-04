using Aiko.Domain.Interfaces;
using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;

namespace Aiko.Services.Services
{
    public class EquipmentModelStateHourlyEarningService : BaseService<EquipmentModelStateHourlyEarning>
    {
        public EquipmentModelStateHourlyEarningService(IEquipmentModelStateHourlyEarningRepository repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
