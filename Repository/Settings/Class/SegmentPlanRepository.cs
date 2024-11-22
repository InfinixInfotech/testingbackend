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
    public class SegmentPlanRepository : ISegmentPlanRepository
    {
        private readonly IMongoCollection<SegmentPlan> _collection;
        public SegmentPlanRepository(MongoDbRepository context)
        {
            _collection = context.SegmentPlan;
        }
        public async Task InsertSegmentPlanAsync(SegmentPlan segmentPlan)
        {
            await _collection.InsertOneAsync(segmentPlan);
        }

        public async Task UpdateSegmentPlanByIdAsync(int id, SegmentPlan segmentPlan)
        {
            var filter = Builders<SegmentPlan>.Filter.Eq(x => x.Id, id);
            await _collection.ReplaceOneAsync(filter, segmentPlan);
        }

        public async Task DeleteSegmentPlanByIdAsync(int id)
        {
            var filter = Builders<SegmentPlan>.Filter.Eq(x => x.Id, id);
            await _collection.DeleteOneAsync(filter);
        }

        public async Task<List<SegmentPlan>> GetAllSegmentPlanAsync()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }
        public async Task<SegmentPlan> GetSegmentById(int id)
        {
            return await _collection.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
    }
}
