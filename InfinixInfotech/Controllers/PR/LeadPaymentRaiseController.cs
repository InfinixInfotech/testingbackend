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
        public LeadPaymentRaiseController(IPaymentRaiseService paymentRaise)
        {
            _paymentRaise = paymentRaise;
        }
        [HttpPost]
        [Route("AddLeadPR")]
        [Authorize(Policy = "AdminOrUser")]
       
        public async Task<IActionResult> AddLeadPR([FromBody] PaymentRaise model)
        {
            var response = await _paymentRaise.LeadPR(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetLeadPRById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetLeadPRById(int id)
        {
            var response = await _paymentRaise.GetLeadPRById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpPut]
        [Route("UpdateLeadPRById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> UpdateLeadPRById([FromBody] PaymentRaise model)
        {
            var response = await _paymentRaise.UpdateLeadPRById(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpDelete]
        [Route("DeleteLeadPRById")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> DeleteLeadPRById(int id)
        {
            var response = await _paymentRaise.DeleteLeadPRById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetAllLeadPR")]
        [Authorize(Policy = "AdminOrUser")]
        public async Task<IActionResult> GetAllLeadPR()
        {
            var response = await _paymentRaise.GetAllLeadPR();
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
