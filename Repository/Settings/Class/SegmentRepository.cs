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
    public class SegmentRepository : ISegmentRepository
    {
        private readonly IMongoCollection<Segment> _collection;
        public SegmentRepository(MongoDbRepository context)
        {
            _collection = context.Segment;
        }
        public async Task InsertSegmentAsync(Segment entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        public async Task UpdateSegmentByIdAsync(Segment entity)
        {
            var filter = Builders<Segment>.Filter.Eq(s => s.Id, entity.Id);
            await _collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteSegmentByIdAsync(int id)
        {
            var filter = Builders<Segment>.Filter.Eq(s => s.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<List<Segment>> GetAllSegmentAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<Segment> GetSegmentById(int id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
    }
}
