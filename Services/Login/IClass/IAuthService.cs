using Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Login.IClass
{
    public interface IAuthService
    {
        Task<AuthResponse> LoginAsync(LoginData loginData);
        Task CreateUserAsync(User user);
    }
}
