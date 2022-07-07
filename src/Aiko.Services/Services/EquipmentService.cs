using Aiko.Domain.Interfaces.Repositories;
using Aiko.Domain.Models;
using Aiko.Services.Contracts.Equipment;
using AutoMapper;

namespace Aiko.Services.Services
{
    public class EquipmentService: NewBaseService<Equipment, EquipmentCreateDto,
        EquipmentUpdateDto, EquipmentDto, EquipmentGetAllDto>
    {
        public EquipmentService(IEquipmentRepository repository,
            IUnitOfWork unitOfWork, IMapper mapper): base(repository, unitOfWork, mapper)
        {
        }
    }
}
