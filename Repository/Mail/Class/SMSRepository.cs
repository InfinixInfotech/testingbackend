using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Leads;
using Models.Mail;
using MongoDB.Driver;
using Repository.Common;
using Repository.Mail.IClass;

namespace Repository.Mail.Class
{
    public class SMSRepository : ISMSRepository
    {
        private readonly IMongoCollection<Email> _collection;

        public SMSRepository(MongoDbRepository context)
        {
            _collection = context.Email;
        }
        public async Task AddSMS(Email sMS)
        {
            await _collection.InsertOneAsync(sMS);
        }
        public async Task<Email> GetSMSById(int id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
        public async Task UpdateSMSById(Email model)
        {
            var filter = Builders<Email>.Filter.Eq("_id", model.Id);
            await _collection.ReplaceOneAsync(filter, model);
        }
        public async Task<List<Email>> GetAllSMS()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<bool> DeleteSMSById(int id)
        {
            var result = await _collection.DeleteOneAsync(user => user.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
