using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Services.Settings.Class;
using Services.Settings.IClass;

namespace InfinixInfotech.CRM.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadStatusController : ControllerBase
    {
        private readonly ILeadStatusService _leadStatusService;
       public LeadStatusController(ILeadStatusService LeadStatusService) 
        {
            _leadStatusService = LeadStatusService; 
        
        
        }
        [HttpGet]
        [Route("GetAllLeadStatus")]
        [Authorize(Policy =("admin"))]
        public async Task<IActionResult> GetAllLeadStatus()
        {
            var response = await _leadStatusService.GetAllAsync();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Route("InsertLeadStatus")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> InsertLeadStatus([FromForm] LeadStatus leadStatus)
        {
            var response = await _leadStatusService.InsertAsync(leadStatus);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("UpdateLeadStatus")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> UpdateLeadStatus([FromForm] LeadStatus leadStatus)
        {
            var response = await _leadStatusService.UpdateAsync(leadStatus);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("DeleteLeadStatus")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> DeleteLeadStatus(int id)
        {
            var response = await _leadStatusService.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
        [HttpGet]
        [Route("GetLeadStatusById")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> GetLeadStatusById(int id)
        {
            var response = await _leadStatusService.GetLeadStatusById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }

    }
}
