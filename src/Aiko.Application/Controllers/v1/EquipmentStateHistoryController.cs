using System.ComponentModel.DataAnnotations;
using System.Net;
using Aiko.Application.Modules.Common;
using Aiko.Domain.Models;
using Aiko.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aiko.Application.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class EquipmentStateHistoryController : ControllerBase
    {
        private readonly EquipmentStateHistoryService _equipmentStateHistoryService;

        public EquipmentStateHistoryController(EquipmentStateHistoryService equipmentStateHistoryService)
        {
            _equipmentStateHistoryService = equipmentStateHistoryService;
        }

        /// <summary>
        ///     Get All EquipmentStateHistorys.
        /// </summary>
        [HttpGet("get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IEnumerable<EquipmentStateHistory> GetAll()
        {
            try
            {
                return _equipmentStateHistoryService.GetAll();
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
        public EquipmentStateHistory? GetById([FromRoute][Required] Guid id)
        {
            try
            {
                return _equipmentStateHistoryService.GetById(id);
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
        [HttpPost("create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<EquipmentStateHistory> Create([FromBody][Required] EquipmentStateHistory dto)
        {
            try
            {
                return await _equipmentStateHistoryService.Create(dto);
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
        [HttpPut("edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task<HttpResponseMessage> Edit([FromBody][Required] EquipmentStateHistory dto)
        {
            try
            {
                await _equipmentStateHistoryService.Update(dto);
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
        [HttpDelete("delete/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<HttpResponseMessage> Delete([FromRoute][Required] Guid id)
        {
            try
            {
                await _equipmentStateHistoryService.Delete(id);
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