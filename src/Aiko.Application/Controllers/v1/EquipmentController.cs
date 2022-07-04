using System.ComponentModel.DataAnnotations;
using System.Net;
using Aiko.Application.Modules.Common;
using Aiko.Domain.Models;
using Aiko.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.Application.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentController : ControllerBase
    {
        private readonly EquipmentService _equipmentService;

        public EquipmentController(EquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        /// <summary>
        ///     Get All Equipments.
        /// </summary>
        [HttpGet("get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<Equipment> GetAll()
        {
            try
            {
                return _equipmentService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Get an Equipment details.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("get-by-id/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public Equipment? GetById([FromRoute][Required] Guid id)
        {
            try
            {
                return _equipmentService.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Create an Equipment.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost("create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<Equipment> Create([FromBody][Required] Equipment dto)
        {
            try
            {
                return await _equipmentService.Create(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Edit an Equipment.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut("edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task<HttpResponseMessage> Edit([FromBody][Required] Equipment dto)
        {
            try
            {
                await _equipmentService.Update(dto);
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
        ///     Delete an Equipment.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("delete/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<HttpResponseMessage> Delete([FromRoute][Required] Guid id)
        {
            try
            {
                await _equipmentService.Delete(id);
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