using Models.Leads;
using Models.Login;
using Models.PR;
using MongoDB.Driver;
using Repository.Common;
using Repository.PR.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.PR.Class
{
    public class PaymentRaiseRepository : IPaymentRaiseRepository
    {
        private readonly IMongoCollection<PaymentRaise> _collection;

        public PaymentRaiseRepository(MongoDbRepository context)
        {
            _collection = context.PaymentRaise;
        }
        public async Task LeadPR(PaymentRaise model)
        {
            await _collection.InsertOneAsync(model);
        }
        public async Task<PaymentRaise> GetLeadPRById(int id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
        public async Task UpdateLeadPRById(PaymentRaise model)
        {
            var filter = Builders<PaymentRaise>.Filter.Eq("_id", model.Id);
            await _collection.ReplaceOneAsync(filter, model);
        }
        public async Task<List<PaymentRaise>> GetAllLeadPR()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<bool> DeleteLeadPRById(int id)
        {
            var result = await _collection.DeleteOneAsync(user => user.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
