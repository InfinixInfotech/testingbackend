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
    public class QualificationRepository : IQualificationRepository
    {
        private readonly IMongoCollection<Qualification> _collection;
        public QualificationRepository(MongoDbRepository context)
        {
            _collection = context.Qualification;
        }
        public async Task InsertQualificationAsync(Qualification qualification)
        {
            await _collection.InsertOneAsync(qualification);
        }

        public async Task UpdateQualificationByIdAsync(int id, Qualification qualification)
        {
            await _collection.ReplaceOneAsync(q => q.Id == id, qualification);
        }

        public async Task DeleteQualificationByIdAsync(int id)
        {
            await _collection.DeleteOneAsync(q => q.Id == id);
        }

        public async Task<List<Qualification>> GetAllQualificationAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<Qualification> GetQualificationById(int id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
    }
}
