using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;
using Aiko.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentService _equipmentService;
        private readonly IRepository<Equipment> _repository;

        public EquipmentController(EquipmentService equipmentService,
            IRepository<Equipment> repository)
        {
            _equipmentService = equipmentService;
            _repository = repository;
        }

        [HttpGet(Name = "/")]
        public IEnumerable<Equipment> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}