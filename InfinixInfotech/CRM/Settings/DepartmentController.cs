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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        [Route("CreateDepartmentAsync")]
        [Authorize(Policy ="admin")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> CreateDepartmentAsync([FromBody] Department department)
        {
            var response = await _departmentService.CreateDepartmentAsync(department);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        [Route("UpdateDepartmentAsync")]
        [Authorize(Policy = "admin")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> UpdateDepartmentAsync(int id, [FromBody] Department department)
        {
            var response = await _departmentService.UpdateDepartmentAsync(id, department);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("DeleteDepartmentAsync")]
        [Authorize(Policy = "admin")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> DeleteDepartmentAsync(int id)
        {
            var response = await _departmentService.DeleteDepartmentAsync(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetAllDepartmentAsync")]
        [Authorize(Policy = "admin")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> GetAllDepartmentAsync()
        {
            var response = await _departmentService.GetAllDepartmentAsync();
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpGet]
        [Route("GetDepartmentById")]
        [Authorize(Policy = "admin")]
        [Authorize(Policy = "user")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var response = await _departmentService.GetDepartmentById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
