using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Services.Contracts.EquipmentState;

namespace Services.Services
{
    public class EquipmentStateService : NewBaseService<EquipmentState, EquipmentStateCreateDto,
        EquipmentStateUpdateDto, EquipmentStateDto, EquipmentStateGetAllDto>
    {
        public EquipmentStateService(IEquipmentStateRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
