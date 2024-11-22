using Models.Demo;
using Models.Leads;
using Models.Settings;
using MongoDB.Driver;
using Repository.Common;
using Repository.Leads.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Leads.Class
{
    public class LeadRepository : ILeadRepository
    {
        private readonly IMongoCollection<Lead> _collection;

        public LeadRepository(MongoDbRepository context)
        {
            _collection = context.Lead;
        }
        public async Task AddLead(Lead lead)
        {
            await _collection.InsertOneAsync(lead);
        }
        public async Task<Lead> GetLeadById(int id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
        public async Task UpdateLeadById(Lead model)
        {
            var filter = Builders<Lead>.Filter.Eq("_id", model.Id);
            await _collection.ReplaceOneAsync(filter, model);
        }
        public async Task<List<Lead>> GetAllLead()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<bool> DeleteLeadById(int id)
        {
            var result = await _collection.DeleteOneAsync(user => user.Id == id);
            return result.DeletedCount > 0;
        }

    }
}
