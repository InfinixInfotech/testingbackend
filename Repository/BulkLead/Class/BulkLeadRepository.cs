using Models.BulkLeads;
using Models.Leads;
using Models.Mail;
using Models.Settings;
using MongoDB.Driver;
using Repository.BulkLead.IClass;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BulkLead.Class
{
    public class BulkLeadRepository : IBulkLeadRepository
    {
        private readonly IMongoCollection<_BulkLead> _collection;
        public BulkLeadRepository(MongoDbRepository context)
        {
            _collection = context.BulkLead;
        }
        public async Task AddBulkLeads(_BulkLead lead)
        {
            await _collection.InsertOneAsync(lead);
        }
        public async Task<bool> GetByCampaignName(string CampaignName)
        {
            var result = await _collection.Find(user => user.CampaignName == CampaignName).FirstOrDefaultAsync();
            return result != null;
        }
        public async Task<bool> AddLeadToCampaign(string campaignName, _BulkLead.LeadDetail newLeadDetail)
        {
            var filter = Builders<_BulkLead>.Filter.Eq(b => b.CampaignName, campaignName);
            var update = Builders<_BulkLead>.Update.Push(b => b.Leads, newLeadDetail);

            var result = await _collection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }
        public async Task<List<_BulkLead.LeadDetail>> GetTop5LeadsByCampaignNameAsync(string campaignName, int customratio)
        {
            var filter = Builders<_BulkLead>.Filter.Eq(b => b.CampaignName, campaignName);
            var projection = Builders<_BulkLead>.Projection.Expression(b =>
                b.Leads.Where(ld => ld.Lead.AssignedTo == null).Take(customratio).ToList()
            );

            var result = await _collection
                .Find(filter)
                .Project(projection)
                .FirstOrDefaultAsync();

            return result ?? new List<_BulkLead.LeadDetail>();
        }

    }
}
