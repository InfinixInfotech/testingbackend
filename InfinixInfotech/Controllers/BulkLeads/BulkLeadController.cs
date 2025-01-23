using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.BulkLeads;
using Models.Leads;
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
        [HttpPut]
        [Route("UpdateLeadById")]
        public async Task<IActionResult> UpdateLeadById([FromBody] Lead model)
        {
            var response = await _bulkLeadService.UpdateLeadById(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }

        [HttpGet]
        [Route("GetAllCampaignNames")]
        public async Task<IActionResult> GetAllCampaignNames()
        {
            try
            {
                var response = await _bulkLeadService.GetAllCampaignNamesAsync();
                return StatusCode(response.Success ? 200 : 500, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetAllLeadsByEmployeeCode")]
        public async Task<IActionResult> GetAllLeadsByEmployeeCode(string employeeCode)
        {
            try
            {
                var response = await _bulkLeadService.GetAllLeadsByEmployeeCodeAsync(employeeCode);
                return StatusCode(response.Success ? 200 : 500, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }

    }
}
