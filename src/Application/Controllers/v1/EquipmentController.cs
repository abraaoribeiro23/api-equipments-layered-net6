using System.ComponentModel.DataAnnotations;
using System.Net;
using Api.Modules.Common;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts.Equipment;
using Services.Services;
using Services.Validators;

namespace Api.Controllers.v1
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

        [HttpGet("get-all")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.List))]
        public IActionResult GetAll()
        {
            var result = _equipmentService.GetAll();
            return StatusCode((int)HttpStatusCode.OK, result);
        }

        [HttpGet("get-by-id/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public IActionResult GetById([FromRoute][Required] Guid id)
        {
            var resultDto = _equipmentService.GetById(id);
            return StatusCode((int) HttpStatusCode.OK, resultDto);
        }

        [HttpPost("create")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Create))]
        public async Task<IActionResult> Create([FromBody][Required] EquipmentCreateDto dto)
        {
            var resultDto = await _equipmentService.Create<EquipmentValidator>(dto);
            return StatusCode((int) HttpStatusCode.Created, resultDto);
        }

        [HttpPut("edit")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Edit))]
        public async Task<IActionResult> Edit([FromBody][Required] EquipmentUpdateDto dto)
        {
            try
            {
                await _equipmentService.Update<EquipmentValidator>(dto);
                return StatusCode((int)HttpStatusCode.Accepted);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new StringContent(ex.Message));
            }
        }

        [HttpDelete("delete/{id:Guid}")]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Delete))]
        public async Task<IActionResult> Delete([FromRoute][Required] Guid id)
        {
            try
            {
                await _equipmentService.Delete(id);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError,
                    new StringContent(ex.Message));
            }
        }
    }
}