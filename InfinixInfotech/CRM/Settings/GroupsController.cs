using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Services.Settings.IClass;

namespace InfinixInfotech.CRM.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupsService _groupsService;
        public GroupsController(IGroupsService groupsService) 
        {
            _groupsService = groupsService;
        }
        [HttpPost]
        [Route("InsertGroups")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> InsertGroups([FromBody] Groups model)
        {
            var response = await _groupsService.InsertAsync(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }

        [HttpPut]
        [Route("UpdateByIdGroups")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> UpdateByIdGroups(int id, [FromBody] Groups model)
        {
            var response = await _groupsService.UpdateByIdAsync(id, model);
            return StatusCode(response.Success ? 200 : 500, response);
        }

        [HttpDelete]
        [Route("DeleteByIdGroups")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> DeleteByIdGroups(int id)
        {
            var response = await _groupsService.DeleteByIdAsync(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }

        [HttpGet]
        [Route("GetAllGroups")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetAllGroups()
        {
            var response = await _groupsService.GetAllAsync();
            return StatusCode(response.Success ? 200 : 500, response);
        }
    }
}
