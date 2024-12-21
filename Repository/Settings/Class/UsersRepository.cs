using Models.Login;
using Models.Settings;
using MongoDB.Driver;
using Repository.Common;
using Repository.Settings.IClass;
using System.Text.RegularExpressions;

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
       
        public List<string> GetEmployeeCredentialsByGroupId(string groupId)
        {
            var filter = Builders<Users>.Filter.Eq(e => e.GroupId, groupId);
            var employees = _collection.Find(filter).ToList();
            return employees.Select(e => e.EmployeeCode).ToList();
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


        public async Task<Users> GetUserByUserNameAsync(string userName, string password)
        {
            var filter = Builders<Users>.Filter.And(
                Builders<Users>.Filter.Eq(user => user.UserName, userName),
                Builders<Users>.Filter.Eq(user => user.Password, password)
            );

            return await _collection.Find(filter).FirstOrDefaultAsync();
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
        public async Task<List<EmployeeDetails>> GetAllEmployeeCodeAndName()
        {
            var employeeDetails = await _collection
             .Find(_ => true) // No filter, fetch all records
             .Project(user => new EmployeeDetails
             {
                 EmployeeCode = user.EmployeeCode, // Employee code
                 EmployeeName = user.FullName     // Full name
             })
             .ToListAsync();

            return employeeDetails;
        }
        public async Task<string> GetCustomFetchRatioByEmpCode(string empCode)
        {
            var user = await _collection
                .Find(user => user.EmployeeCode == empCode)
                .FirstOrDefaultAsync();
            return user?.CustomFetchRatio;
        }
        public async Task<string> GetFetchDateByEmployeeCode(string empCode)
        {
            var user = await _collection
                .Find(u => u.EmployeeCode == empCode)
                .FirstOrDefaultAsync();
            if (user?.FetchedLeads == null || !user.FetchedLeads.Any())
            {
                return null; 
            }
            return user.FetchedLeads
                .OrderByDescending(lead => lead.FetchedDate) 
                .FirstOrDefault()?.FetchedDate;             

        }
        public async Task<Users> GetUserByEmployeeCodeAsync(string employeeCode)
        {
            return await _collection
                .Find(user => user.EmployeeCode == employeeCode)
                .FirstOrDefaultAsync();
        }
        public async Task UpdateUserAsync(Users user)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.EmployeeCode, user.EmployeeCode);
            await _collection.ReplaceOneAsync(filter, user);
        }
        public async Task<int> GetTotalFetchedLeadsByDateAsync(string employeeCode, string currentDate)
        {
            var user = await _collection
                .Find(u => u.EmployeeCode == employeeCode)
                .FirstOrDefaultAsync();

            if (user == null || user.FetchedLeads == null)
            {
                return 0; 
            }
            var fetchedLeadsForDate = user.FetchedLeads.FirstOrDefault(f => f.FetchedDate == currentDate);
            return fetchedLeadsForDate?.TotalFetchedLeads ?? 0;
        }
        public async Task UpdateTotalFetchedLeadsAsync(string employeeCode, string currentDate, int newTotalFetchedLeads)
        {
            var filter = Builders<Users>.Filter.And(
                Builders<Users>.Filter.Eq(u => u.EmployeeCode, employeeCode),
                Builders<Users>.Filter.ElemMatch(u => u.FetchedLeads, f => f.FetchedDate == currentDate)
            );

            // Update definition to update the TotalFetchedLeads field for the matching entry in the FetchedLeads array
            var update = Builders<Users>.Update.Set(
                "FetchedLeads.$.TotalFetchedLeads", newTotalFetchedLeads
            );

            // Perform the update operation
            var result = await _collection.UpdateOneAsync(filter, update);

            // Check if the update was successful
            if (result.ModifiedCount == 0)
            {
                throw new InvalidOperationException("Failed to update TotalFetchedLeads. Record not found or already up-to-date.");
            }
        }
        public async Task AddFetchedLeadAsync(string employeeCode, FetchedLeads newFetchedLead)
        {
            var filter = Builders<Users>.Filter.Eq(u => u.EmployeeCode, employeeCode);
            var update = Builders<Users>.Update.Push(u => u.FetchedLeads, newFetchedLead);
            var result = await _collection.UpdateOneAsync(filter, update);

            if (result.ModifiedCount == 0)
            {
                throw new InvalidOperationException("Failed to add new fetched lead. User not found.");
            }
        }

    }
}
