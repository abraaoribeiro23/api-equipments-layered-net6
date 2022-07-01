using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;

namespace Aiko.Domain.Services
{
    public class EquipmentModelStateHourlyEarningService : BaseService<EquipmentModelStateHourlyEarning>
    {
        public EquipmentModelStateHourlyEarningService(IBaseRepository<EquipmentModelStateHourlyEarning> repository,
            IUnitOfWork unitOfWork): base(repository, unitOfWork)
        {
        }
    }
}
