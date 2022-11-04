using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Services.Contracts.EquipmentModel;

namespace Services.Services
{
    public class EquipmentModelService
        : NewBaseService<EquipmentModel, EquipmentModelCreateDto,EquipmentModelUpdateDto,
        EquipmentModelDto,EquipmentModelGetAllDto>
    {
        public EquipmentModelService(IEquipmentModelRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }
    }
}
