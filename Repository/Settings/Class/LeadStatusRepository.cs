using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Models.Demo;
using Models.Settings;
using MongoDB.Driver;
using Repository.Common;
using Repository.Settings.IClass;

namespace Repository.Settings.Class
{
   public class LeadStatusRepository : ILeadStatusRepository
    {
        private readonly IMongoCollection<LeadStatus> _collection;

        public LeadStatusRepository(MongoDbRepository context)
        {
            _collection = context.LeadStatus;
        }
        public async Task<IEnumerable<LeadStatus>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<LeadStatus> GetByIdAsync(int id)
        {
            return await _collection.Find(ls => ls.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(LeadStatus leadStatus)
        {
            await _collection.InsertOneAsync(leadStatus);
        }

        public async Task UpdateByIdAsync(LeadStatus model)
        {
            var filter = Builders<LeadStatus>.Filter.Eq("_id", model.Id);
            await _collection.ReplaceOneAsync(filter, model);
        }

        public async Task DeleteAsync(int id)
        {
            await _collection.DeleteOneAsync(ls => ls.Id == id);
        }
    }
}
