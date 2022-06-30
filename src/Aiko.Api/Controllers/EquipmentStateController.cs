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
    public class EquipmentStateController : ControllerBase
    {
        //private readonly EquipmentStateService _equipmentStateService;
        private readonly IBaseRepository<EquipmentState> _repository;

        public EquipmentStateController(IBaseRepository<EquipmentState> repository)
        {
            //_equipmentStateService = equipmentStateService;
            _repository = repository;
        }

        /// <summary>
        ///     Get All EquipmentStates.
        /// </summary>
        [HttpGet("/get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<EquipmentState> GetAll()
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
        ///     Get an EquipmentState details.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("get-by-id/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public EquipmentState Get([FromRoute][Required] Guid id)
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
        ///     Create an EquipmentState.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost(Name = "/create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public EquipmentState Create([FromBody][Required] EquipmentState dto)
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
        ///     Edit an EquipmentState.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "/edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public HttpResponseMessage Edit([FromBody][Required] EquipmentState dto)
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
        ///     Delete an EquipmentState.
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