using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Settings;
using Services.Settings.Class;
using Services.Settings.IClass;

namespace InfinixInfotech.CRM.Settings
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService) 
        { 
            _usersService = usersService;
        }

        [HttpPost]
        [Route("AddUsers")]
        //[Authorize(Policy = "admin")]
        public async Task<IActionResult> AddUsers([FromBody] Users model)
        {
            var response = await _usersService.AddUsers(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpPut]
        [Route("UpdateUsersById")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> UpdateUsersById([FromBody] Users model)
        {
            var response = await _usersService.UpdateUsersById(model);
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetAllUsers")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _usersService.GetAllUsers();
            return StatusCode(response.Success ? 200 : 500, response);
        }
        [HttpGet]
        [Route("GetUserById")]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = await _usersService.GetUserById(id);
            return StatusCode(response.Success ? 200 : 500, response);
        }

    }
}
