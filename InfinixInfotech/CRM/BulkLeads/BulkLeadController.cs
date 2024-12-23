using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BulkLeads;
using Services.BulkLead.IClass;
using Services.SO.Class;

namespace InfinixInfotech.CRM.BulkLeads
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkLeadController : ControllerBase
    {
        private readonly IBulkLeadService _bulkLeadService;
        public BulkLeadController(IBulkLeadService bulkLeadService)
        {
            _bulkLeadService = bulkLeadService;
        }
        [HttpPost]
        [Route("UploadBulkLead")]
        public async Task<IActionResult> UploadBulkLead([FromForm] _leads bulkLeads)
        {
            var response = await _bulkLeadService.BulkLeadUpload(bulkLeads);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("CustomeFetchLeads")]
        public async Task<IActionResult> CustomeFetchLeads(string  EmployeeCode, string CampaignName)
        {
            var response = await _bulkLeadService.CustomeFetchLeads(EmployeeCode, CampaignName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetLeadByEmployeeCode")]
        public async Task<IActionResult> GetLeadByEmployeeCode(string EmployeeCode, string CampaignName)
        {
            var response = await _bulkLeadService.GetLeadByEmployeeCode(EmployeeCode, CampaignName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
