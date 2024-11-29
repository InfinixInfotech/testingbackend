using InfinixInfotech.CRM.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Leads;
using Models.Mail;
using Services.Leads.Class;
using Services.Leads.IClass;
using Services.Mail.IClass;
using Services.SO.IClass;

namespace InfinixInfotech.CRM.Mail
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _sMSService;
        private readonly HomeController _homeController;
        public SMSController(ISMSService sMSService, HomeController homeController)
        {
            _sMSService = sMSService;
            _homeController = homeController;

        }
        [HttpPost]
        [Route("AddSMS")]
        public async Task<IActionResult> AddSMS([FromForm] SMS model)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sMSService.AddSMS(model, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetSMSById")]
        public async Task<IActionResult> GetSMSById(int id, string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sMSService.GetSMSById(id, apiType, accessType, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpPut]
        [Route("UpdateSMSById")]
        public async Task<IActionResult> UpdateSMSById([FromForm] Email model)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sMSService.UpdateSMSById(model, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpDelete]
        [Route("DeleteSMSById")]
        public async Task<IActionResult> DeleteSMSById(int id, string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sMSService.DeleteSMSById(id, apiType, accessType, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetAllSMS")]
        public async Task<IActionResult> GetAllSMS (string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _sMSService.GetAllSMS(apiType, accessType, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
