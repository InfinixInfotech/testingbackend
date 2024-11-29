using Models.Settings;
using MongoDB.Driver;
using Repository.Common;
using Repository.Settings.IClass;

namespace Repository.Settings.Class
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IMongoCollection<Users> _collection;
        public UsersRepository(MongoDbRepository context)
        {
            _collection = context.Users;
        }
        public async Task AddUsers(Users users)
        {
            await _collection.InsertOneAsync(users);
        }
        public async Task<string> GeEmpCode(string mobile)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.MobileNumber, mobile);
            var user = await _collection.Find(filter).FirstOrDefaultAsync();

            return user?.EmployeeCode;
        }
        public async Task UpdateUsersById(Users model)
        {
            var filter = Builders<Users>.Filter.Eq("_id", model.Id);
            await _collection.ReplaceOneAsync(filter, model);
        }
        public async Task<List<Users>> GetAllUsers()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<Users> GetUserById(int id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
        public async Task<userresponseData> GetUserDetailsByUsername(string username)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.UserName, username);
            var projection = Builders<Users>.Projection.Expression(u => new userresponseData
            {
                EmpCode = u.EmployeeCode, 
                GroupName = u.GroupName, 
                FullName = u.FullName
            });

            var userDetails = await _collection.Find(filter).Project(projection).FirstOrDefaultAsync();

            return userDetails;
        }


        public async Task<Users> GetUserByUserNameAsync(string userName)
        {
            return await _collection.Find(user => user.UserName == userName).FirstOrDefaultAsync();
        }
        public async Task<List<Users>> GetAllUserDetailsByGroupName(string groupName)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.GroupName, groupName);
            return await _collection
                .Find(filter)
                .ToListAsync();
        }
        public async Task<List<EmployeeDetails>> GetAllEmployeeCodeEmployeeNameByGroupName(string groupName)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.GroupName, groupName);
            var employeeDetails = await _collection
                .Find(filter)
                .Project(user => new EmployeeDetails
                {
                    EmployeeCode = user.EmployeeCode, 
                    EmployeeName = user.FullName  
                })
                .ToListAsync();

            return employeeDetails;
        }


    }
}
