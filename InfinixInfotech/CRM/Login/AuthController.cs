using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Login;
using Services.Login.IClass;

namespace InfinixInfotech.CRM.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


            [HttpPost("login")]
            public async Task<IActionResult> Login([FromBody] LoginData loginData)
            {
                var response = await _authService.LoginAsync(loginData);
                if (!response.Success)
                    return Unauthorized(new { message = response.Message });

                return Ok(new { token = response.Token, message = response.Message });
            }
        [HttpPost]
        [Route("CreateUserAsync")]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User data is required.");
            }

            await _authService.CreateUserAsync(user);
            return Ok("User Register Succesfully");
        }
    }
    
}
