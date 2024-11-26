using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Common;
using Models.Leads;
using Models.Settings;
using Models.SO;
using MongoDB.Driver;
using Repository.Common;
using Repository.SO.IClass;

namespace Repository.SO.Class
{
    public class SORepository : ISORepository
    {
        private readonly IMongoCollection<So> _collection;

        public SORepository(MongoDbRepository context)
        {
            _collection = context.So;
        }
        public async Task<IEnumerable<So>> GetAllSO()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<So> GetByIdAsync(int id)
        {
            return await _collection.Find(ls => ls.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertSO(So so)
        {
            await _collection.InsertOneAsync(so);
        }

        public async Task UpdateSO(So model)
        {
            var filter = Builders<So>.Filter.Eq("_id", model.Id);
            await _collection.ReplaceOneAsync(filter, model);
        }

        public async Task DeleteSO(int id)
        {
            await _collection.DeleteOneAsync(ls => ls.Id == id);
        }

    }
}
