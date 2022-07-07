using System.ComponentModel.DataAnnotations;
using System.Net;
using Aiko.Application.Modules.Common;
using Aiko.Services.Contracts.EquipmentModelStateHourlyEarning;
using Aiko.Services.Services;
using Aiko.Services.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.Application.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentModelStateHourlyEarningController : ControllerBase
    {
        private readonly EquipmentModelStateHourlyEarningService _service;

        public EquipmentModelStateHourlyEarningController(EquipmentModelStateHourlyEarningService service)
        {
            _service = service;
        }

        /// <summary>
        ///     Get All EquipmentModelStateHourlyEarnings.
        /// </summary>
        [HttpGet("get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<EquipmentModelStateHourlyEarningGetAllDto> GetAll()
        {
            try
            {
                return _service.GetAll();
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
        public EquipmentModelStateHourlyEarningDto? GetById([FromRoute][Required] Guid id)
        {
            try
            {
                return _service.GetById(id);
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
        [HttpPost("create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<EquipmentModelStateHourlyEarningDto> Create([FromBody][Required] EquipmentModelStateHourlyEarningCreateDto dto)
        {
            try
            {
                return await _service.Create<EquipmentModelStateHourlyEarningValidator>(dto);
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
        [HttpPut("edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task<HttpResponseMessage> Edit([FromBody][Required] EquipmentModelStateHourlyEarningUpdateDto dto)
        {
            try
            {
                await _service.Update<EquipmentModelStateHourlyEarningValidator>(dto);
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
        public async Task<HttpResponseMessage> Delete([FromRoute][Required] Guid id)
        {
            try
            {
                await _service.Delete(id);
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