using Models.Login;
using Models.Settings;
using MongoDB.Driver;
using Repository.Common;
using Repository.Settings.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.Class
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly IMongoCollection<Groups> _admincollection;
        public GroupsRepository(MongoDbRepository context) 
        {
            _admincollection = context.Groups;
        }
        public async Task InsertAsync(Groups model)
        {
            await _admincollection.InsertOneAsync(model);
        }

        public async Task UpdateByIdAsync(Groups model)
        {
            var filter = Builders<Groups>.Filter.Eq("_id", model.Id);
            await _admincollection.ReplaceOneAsync(filter, model);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var filter = Builders<Groups>.Filter.Eq("_id", id);
            await _admincollection.DeleteOneAsync(filter);
        }

        public async Task<List<Groups>> GetAllAsync()
        {
            return await _admincollection.Find(_ => true).ToListAsync();
        }
        public async Task<Groups> GetGroupsById(int id)
        {
            return await _admincollection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
    }
}
