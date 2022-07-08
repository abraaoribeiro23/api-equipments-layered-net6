using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Services.Contracts.EquipmentModelStateHourlyEarning;
using AutoMapper;

namespace Aiko.Services.Services
{
    public class EquipmentModelStateHourlyEarningService : NewBaseService<EquipmentModelStateHourlyEarning,
        EquipmentModelStateHourlyEarningCreateDto, EquipmentModelStateHourlyEarningUpdateDto,
        EquipmentModelStateHourlyEarningDto, EquipmentModelStateHourlyEarningGetAllDto>
    {
        public EquipmentModelStateHourlyEarningService(IEquipmentModelStateHourlyEarningRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper): base(repository, unitOfWork, mapper)
        {
        }
    }
}
