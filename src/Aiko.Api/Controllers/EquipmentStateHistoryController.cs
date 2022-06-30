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
    public class EquipmentStateHistoryController : ControllerBase
    {
        //private readonly EquipmentStateHistoryService _equipmentStateHistoryService;
        private readonly IBaseRepository<EquipmentStateHistory> _repository;

        public EquipmentStateHistoryController(IBaseRepository<EquipmentStateHistory> repository)
        {
            //_equipmentStateHistoryService = equipmentStateHistoryService;
            _repository = repository;
        }

        /// <summary>
        ///     Get All EquipmentStateHistorys.
        /// </summary>
        [HttpGet("/get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<EquipmentStateHistory> GetAll()
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
        ///     Get an EquipmentStateHistory details.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("get-by-id/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public EquipmentStateHistory Get([FromRoute][Required] Guid id)
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
        ///     Create an EquipmentStateHistory.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost(Name = "/create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public EquipmentStateHistory Create([FromBody][Required] EquipmentStateHistory dto)
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
        ///     Edit an EquipmentStateHistory.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "/edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public HttpResponseMessage Edit([FromBody][Required] EquipmentStateHistory dto)
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
        ///     Delete an EquipmentStateHistory.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("/delete/{id:Guid}")]
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