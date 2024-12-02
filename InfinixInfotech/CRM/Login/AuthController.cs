using Microsoft.AspNetCore.Authorization;
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
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LoginData loginData)
        {
            var response = await _authService.LoginAsync(loginData);
            
            HttpContext.Session.SetString("EmployeeCode", response.EmployeeCode);
            HttpContext.Session.SetString("GroupName", response.GroupName);
            if (!response.Success)
                return Unauthorized(new { message = response.Message });

            return Ok(new { response });
        }
     
    }
}

