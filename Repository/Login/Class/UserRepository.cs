using Models.Login;
using MongoDB.Driver;
using Repository.Common;
using Repository.Login.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Login.Class
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _admincollection;

        public UserRepository(MongoDbRepository context)
        {
            _admincollection = context.Users;
        }
        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _admincollection.Find(user => user.UserName == userName).FirstOrDefaultAsync();
        }
        public async Task CreateUserAsync(User user)
        {
            await _admincollection.InsertOneAsync(user);
        }
    }
}
