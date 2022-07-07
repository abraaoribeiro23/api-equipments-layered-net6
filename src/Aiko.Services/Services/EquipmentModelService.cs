using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Services.Contracts.EquipmentModel;
using AutoMapper;

namespace Aiko.Services.Services
{
    public class EquipmentModelService : NewBaseService<EquipmentModel, EquipmentModelCreateDto,EquipmentModelUpdateDto,
        EquipmentModelDto,EquipmentModelGetAllDto>
    {
        public EquipmentModelService(IEquipmentModelRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
