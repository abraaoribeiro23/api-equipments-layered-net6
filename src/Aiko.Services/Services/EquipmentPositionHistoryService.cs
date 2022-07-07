using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Services.Contracts.EquipmentPositionHistory;
using AutoMapper;

namespace Aiko.Services.Services
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
