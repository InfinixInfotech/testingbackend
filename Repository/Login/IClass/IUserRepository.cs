using Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Login.IClass
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAsync(string userName);
        Task CreateUserAsync(User user);
    }
}
