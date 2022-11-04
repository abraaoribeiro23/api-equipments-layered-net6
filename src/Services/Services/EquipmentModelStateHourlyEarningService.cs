using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Services.Contracts.EquipmentModelStateHourlyEarning;

namespace Services.Services
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
