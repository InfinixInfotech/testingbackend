using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Services.Settings.IClass;

namespace InfinixInfotech.CRM.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadSourceController : ControllerBase
    {
        public readonly ILeadSourceService _leadSource;
        public LeadSourceController(ILeadSourceService leadSourceService) 
        {
            _leadSource = leadSourceService;

        }
        [HttpGet]
        [Route("GetAllLeadSource")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> GetAllLeadSource()
        {
            var response = await _leadSource.GetAllAsync();
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Route("InsertLeadSource")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> InsertLeadSource([FromBody] LeadSource leadSource)
        {
            var response = await _leadSource.InsertAsync(leadSource);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        [Route("UpdateLeadSource")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> UpdateLeadSource([FromBody] LeadSource leadSource)
        {
            var response = await _leadSource.UpdateAsync(leadSource);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete]
        [Route("DeleteLeadSource")]
        [Authorize(Policy = ("admin"))]
        public async Task<IActionResult> DeleteLeadSource(int id)
        {
            var response = await _leadSource.DeleteAsync(id);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
