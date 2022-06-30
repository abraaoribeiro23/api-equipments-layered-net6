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
    public class EquipmentModelController : ControllerBase
    {
        //private readonly EquipmentModelService _equipmentModelService;
        private readonly IBaseRepository<EquipmentModel> _repository;

        public EquipmentModelController(IBaseRepository<EquipmentModel> repository)
        {
            //_equipmentService = equipmentService;
            _repository = repository;
        }

        /// <summary>
        ///     Get All EquipmentModels.
        /// </summary>
        [HttpGet("get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<EquipmentModel> GetAll()
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
        ///     Get an EquipmentModel details.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("get-by-id/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public EquipmentModel Get([FromRoute][Required] Guid id)
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
        ///     Create an EquipmentModel.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost(Name = "create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public EquipmentModel Create([FromBody][Required] EquipmentModel dto)
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
        ///     Edit an EquipmentModel.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public HttpResponseMessage Edit([FromBody][Required] EquipmentModel dto)
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
        ///     Delete an EquipmentModel.
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