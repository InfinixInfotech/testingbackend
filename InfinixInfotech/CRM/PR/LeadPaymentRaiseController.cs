using InfinixInfotech.CRM.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Leads;
using Models.PR;
using Services.PR.IClass;

namespace InfinixInfotech.CRM.PR
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadPaymentRaiseController : ControllerBase
    {
        private readonly IPaymentRaiseService _paymentRaise;
        private readonly HomeController _homeController;
        public LeadPaymentRaiseController(IPaymentRaiseService paymentRaise, HomeController homeController)
        {
            _paymentRaise = paymentRaise;
            _homeController = homeController;
        }
        [HttpPost]
        [Route("AddLeadPR")]
        [Authorize(Policy = "AdminOrUser")]
       
        public async Task<IActionResult> AddLeadPR([FromBody] PaymentRaise model)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _paymentRaise.LeadPR(model, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetLeadPRById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetLeadPRById(int id, string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _paymentRaise.GetLeadPRById(id, apiType, accessType, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpPut]
        [Route("UpdateLeadPRById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> UpdateLeadPRById([FromBody] PaymentRaise model)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _paymentRaise.UpdateLeadPRById(model, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpDelete]
        [Route("DeleteLeadPRById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> DeleteLeadPRById(int id, string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _paymentRaise.DeleteLeadPRById(id, apiType, accessType, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetAllLeadPR")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllLeadPR(string apiType, string accessType)
        {
            var grpName = await _homeController.GetGroupName();
            var response = await _paymentRaise.GetAllLeadPR(apiType, accessType, grpName);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
