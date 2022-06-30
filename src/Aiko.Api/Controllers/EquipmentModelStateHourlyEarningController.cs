using System.ComponentModel.DataAnnotations;
using System.Net;
using Aiko.Api.Modules.Common;
using Aiko.Domain.Interfaces;
using Aiko.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentModelStateHourlyEarningController : ControllerBase
    {
        //private readonly EquipmentModelStateHourlyEarningService _equipmentModelStateHourlyEarningService;
        private readonly IBaseRepository<EquipmentModelStateHourlyEarning> _repository;

        public EquipmentModelStateHourlyEarningController(IBaseRepository<EquipmentModelStateHourlyEarning> repository)
        {
            //_equipmentModelStateHourlyEarningService = equipmentModelStateHourlyEarningService;
            _repository = repository;
        }

        /// <summary>
        ///     Get All EquipmentModelStateHourlyEarnings.
        /// </summary>
        [HttpGet("get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<EquipmentModelStateHourlyEarning> GetAll()
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
        /// <summary>
        ///     Get an EquipmentModelStateHourlyEarning details.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("get-by-id/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public EquipmentModelStateHourlyEarning Get([FromRoute][Required] Guid id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Create an EquipmentModelStateHourlyEarning.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost(Name = "create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public EquipmentModelStateHourlyEarning Create([FromBody][Required] EquipmentModelStateHourlyEarning dto)
        {
            try
            {
                return _repository.Add(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Edit an EquipmentModelStateHourlyEarning.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public HttpResponseMessage Edit([FromBody][Required] EquipmentModelStateHourlyEarning dto)
        {
            try
            {
                _repository.Update(dto);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
                return response;
            }
        }
        /// <summary>
        ///     Delete an EquipmentModelStateHourlyEarning.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("delete/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public HttpResponseMessage Delete([FromRoute][Required] Guid id)
        {
            try
            {
                _repository.Delete(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message)
                };
                return response;
            }
        }
    }
}