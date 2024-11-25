using Microsoft.AspNetCore.Mvc;
using Services.Login.IClass;

namespace InfinixInfotech.CRM.Common
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GetGroupName()
        {
            try
            {
                var empcode = _httpContextAccessor.HttpContext.Session.GetString("GroupName");
                if (string.IsNullOrEmpty(empcode))
                {
                    throw new Exception("Client ID not found in session.");
                }
                return empcode;
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
