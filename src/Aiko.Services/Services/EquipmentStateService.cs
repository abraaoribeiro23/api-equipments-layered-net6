using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Services.Contracts.EquipmentState;
using AutoMapper;

namespace Aiko.Services.Services
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
