using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Settings;
using MongoDB.Driver;
using Repository.Common;
using Repository.Settings.IClass;

namespace Repository.Settings.Class
{
    public class LeadSourceRepository : ILeadSourceRepository
    {
        private readonly IMongoCollection<LeadSource> _collection;

        public LeadSourceRepository(MongoDbRepository context)
        {
            _collection = context.LeadSource;


        }
        public async Task<IEnumerable<LeadSource>> GetAllAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<LeadSource> GetByIdAsync(int id)
        {
            return await _collection.Find(ls => ls.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(LeadSource leadSource)
        {
            await _collection.InsertOneAsync(leadSource);
        }

        public async Task UpdateAsync(LeadSource leadSource)
        {
            await _collection.ReplaceOneAsync(ls => ls.Id == leadSource.Id, leadSource);
        }

        public async Task DeleteAsync(int id)
        {
            await _collection.DeleteOneAsync(ls => ls.Id == id);
        }

    }
}
