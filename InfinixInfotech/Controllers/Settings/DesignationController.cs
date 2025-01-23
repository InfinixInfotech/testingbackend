using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Services.Settings.IClass;

namespace InfinixInfotech.CRM.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly IDesignationService _designationService;
        public DesignationController(IDesignationService designationService)
        {
            _designationService = designationService;
        }
        [HttpPost]
        [Route("CreateDesignation")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> CreateDesignation([FromBody] Designation designation)
        {
            var response = await _designationService.CreateDesignation(designation);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        [Route("UpdateDesignation")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> UpdateDesignation([FromBody] Designation designation)
        {
            var response = await _designationService.UpdateDesignation(designation);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("DeleteDesignation")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> DeleteDesignation(int id)
        {
            var response = await _designationService.DeleteDesignation(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetAllDesignation")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetAllDesignation()
        {
            var response = await _designationService.GetAllDesignation();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("GetDesignationById")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetDesignationById(int id)
        {
            var response = await _designationService.GetDesignationById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
