using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Services.Contracts.EquipmentStateHistory;

namespace Services.Services
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
