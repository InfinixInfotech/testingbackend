using InfinixInfotech.CRM.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Leads;
using Models.Mail;
using Services.Leads.Class;
using Services.Leads.IClass;
using Services.Mail.IClass;
using Services.Settings.IClass;
using Services.SO.IClass;

namespace InfinixInfotech.CRM.Mail
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ISMSService _sMSService;
        private readonly IUsersService _usersService;
        private readonly IGroupsService _groupsService;
        public SMSController(ISMSService sMSService, IUsersService usersService,IGroupsService groupsService)
        {
            _sMSService = sMSService;
            _usersService = usersService;
            _groupsService = groupsService;
        }
        [HttpPost]
        [Route("AddSMS")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> AddSMS([FromForm] SMS model)
        {
            
            var response = await _sMSService.AddSMS(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetSMSById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetSMSById(int id)
        {
            var response = await _sMSService.GetSMSById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpPut]
        [Route("UpdateSMSById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> UpdateSMSById([FromForm] Email model)
        {

            var response = await _sMSService.UpdateSMSById(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpDelete]
        [Route("DeleteSMSById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> DeleteSMSById(int id)
        {
            var response = await _sMSService.DeleteSMSById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetAllSMS")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllSMS ()
        {
            var response = await _sMSService.GetAllSMS();
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet("GetAllSMSByEmployeeCode")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllSMSByEmployeeCode(string employeeCode)
        {
            var response = await _sMSService.GetAllSMSByEmployeeCode(employeeCode);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpGet("GetAllSMSByisImportant")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllSMSByisImportant(bool isimportant)
        {
            var response = await _sMSService.GetAllSMSByisImportant(isimportant);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
        [HttpGet]
        [Route("GetAllEmployeeCodeAndName")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllEmployeeCodeAndName()
        {
            var response = await _usersService.GetAllEmployeeCodeAndName();
            return StatusCode(response.Success ? 200 : 500, response);
        } 
        [HttpGet]
        [Route("GetAllGroupNameAndID")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllGroupNameAndID()
        {
            var response = await _groupsService.GetAllGroupNameAndID();
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
