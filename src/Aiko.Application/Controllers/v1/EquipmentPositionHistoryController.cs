using System.ComponentModel.DataAnnotations;
using System.Net;
using Aiko.Application.Modules.Common;
using Aiko.Services.Contracts.EquipmentPositionHistory;
using Aiko.Services.Services;
using Aiko.Services.Validators;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.Application.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentPositionHistoryController : ControllerBase
    {
        private readonly EquipmentPositionHistoryService _equipmentPositionHistoryService;

        public EquipmentPositionHistoryController(EquipmentPositionHistoryService equipmentPositionHistoryService)
        {
            _equipmentPositionHistoryService = equipmentPositionHistoryService;
        }

        /// <summary>
        ///     Get All EquipmentPositionHistorys.
        /// </summary>
        [HttpGet("get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<EquipmentPositionHistoryGetAllDto> GetAll()
        {
            try
            {
                return _equipmentPositionHistoryService.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Get an EquipmentPositionHistory details.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("get-by-id/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Find))]
        public EquipmentPositionHistoryDto? GetById([FromRoute][Required] Guid id)
        {
            try
            {
                return _equipmentPositionHistoryService.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Create an EquipmentPositionHistory.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPost("create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<EquipmentPositionHistoryDto> Create([FromBody][Required] EquipmentPositionHistoryCreateDto dto)
        {
            try
            {
                return await _equipmentPositionHistoryService.Create<EquipmentPositionHistoryValidator>(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///     Edit an EquipmentPositionHistory.
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut("edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task<HttpResponseMessage> Edit([FromBody][Required] EquipmentPositionHistoryUpdateDto dto)
        {
            try
            {
                await _equipmentPositionHistoryService.Update<EquipmentPositionHistoryValidator>(dto);
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
        ///     Delete an EquipmentPositionHistory.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("delete/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<HttpResponseMessage> Delete([FromRoute][Required] Guid id)
        {
            try
            {
                await _equipmentPositionHistoryService.Delete(id);
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