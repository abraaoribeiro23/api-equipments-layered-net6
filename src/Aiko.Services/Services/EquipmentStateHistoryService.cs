using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Services.Contracts.EquipmentStateHistory;
using AutoMapper;

namespace Aiko.Services.Services
{
    public class EquipmentStateHistoryService : NewBaseService<EquipmentStateHistory, EquipmentStateHistoryCreateDto,
        EquipmentStateHistoryUpdateDto, EquipmentStateHistoryDto, EquipmentStateHistoryGetAllDto>
    {
        public EquipmentStateHistoryService(IEquipmentStateHistoryRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper): base(repository, unitOfWork, mapper)
        {
        }
    }
}
