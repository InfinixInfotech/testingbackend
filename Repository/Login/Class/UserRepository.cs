using Models.Demo;
using Models.Login;
using MongoDB.Driver;
using Repository.Common;
using Repository.Login.IClass;

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
