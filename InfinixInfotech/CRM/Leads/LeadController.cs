using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Leads;
using Models.Settings;
using MongoDB.Driver;
using Services.Leads.IClass;

namespace InfinixInfotech.CRM.Leads
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;
        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }
        [HttpPost]
        [Route("AddLead")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> AddLead([FromBody] Lead model)
        {
            var response = await _leadService.AddLead(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetLeadById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetLeadById(int id)
        {
            var response = await _leadService.GetLeadById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpPut]
        [Route("UpdateLeadById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> UpdateLeadById([FromBody] Lead model)
        {
            var response = await _leadService.UpdateLeadById(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpDelete]
        [Route("DeleteLeadById")]
        [Authorize(Policy = "AdminOrUser")]

        public async Task<IActionResult> DeleteLeadById(int id)
        {
            var response = await _leadService.DeleteLeadById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetAllLead")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllLead()
        {
            var response = await _leadService.GetAllLead();
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
