 using InfinixInfotech.CRM.Common;
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
        private readonly HomeController _homeController;
        public LeadController(ILeadService leadService, HomeController homeController)
        {
            _leadService = leadService;
            _homeController = homeController;
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
        public async Task<IActionResult> GetLeadById(int id, string apiType, string accessType,string groupName)
        {
            var response = await _leadService.GetLeadById(id,apiType,accessType, groupName);
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

        public async Task<IActionResult> DeleteLeadById(int id, string apiType, string accessType, string groupName)
        {
            var response = await _leadService.DeleteLeadById(id, apiType, accessType, groupName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetAllLead")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllLead(string apiType, string accessType, string groupName)
        {
            var response = await _leadService.GetAllLead(apiType,accessType, groupName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
