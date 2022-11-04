using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Services.Contracts.EquipmentPositionHistory;

namespace Services.Services
{
    public class EquipmentPositionHistoryService : NewBaseService<EquipmentPositionHistory, EquipmentPositionHistoryCreateDto,
        EquipmentPositionHistoryUpdateDto, EquipmentPositionHistoryDto, EquipmentPositionHistoryGetAllDto>
    {
        public EquipmentPositionHistoryService(IEquipmentPositionHistoryRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper): base(repository, unitOfWork, mapper)
        {
        }
    }
}
