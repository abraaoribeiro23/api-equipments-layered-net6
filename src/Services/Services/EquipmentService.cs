using AutoMapper;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Services.Contracts.Equipment;

namespace Services.Services
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
