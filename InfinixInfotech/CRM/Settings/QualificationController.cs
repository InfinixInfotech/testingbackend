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
    public class QualificationController : ControllerBase
    {
        private readonly IQualificationService _service;
        public QualificationController(IQualificationService service) 
        {
            _service = service;
        }
        [HttpPost]
        [Route("InsertQualificationAsync")]
        [Authorize (Policy = "admin")]
        public async Task<IActionResult> InsertQualificationAsync([FromBody] Qualification qualification)
        {
            var response = await _service.InsertQualificationAsync(qualification);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateQualificationByIdAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> UpdateQualificationByIdAsync(int id, [FromBody] Qualification qualification)
        {
            var response = await _service.UpdateQualificationByIdAsync(id, qualification);
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteQualificationByIdAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> DeleteQualificationByIdAsync(int id)
        {
            var response = await _service.DeleteQualificationByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllQualificationAsync")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetAllQualificationAsync()
        {
            var response = await _service.GetAllQualificationAsync();
            return Ok(response);
        }
        [HttpGet]
        [Route("GetQualificationById")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetQualificationById(int id)
        {
            var response = await _service.GetQualificationById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
