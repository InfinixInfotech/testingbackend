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
        public async Task<List<_BulkLead.LeadDetail>> UpdateTopLeadsByCampaignNameAsync(string campaignName, int customratio, string employeeCode)
        {
            var filter = Builders<_BulkLead>.Filter.Eq(b => b.CampaignName, campaignName);
            var bulkLead = await _collection.Find(filter).FirstOrDefaultAsync();

            if (bulkLead == null || bulkLead.Leads == null)
                return new List<_BulkLead.LeadDetail>();
            var leadsToUpdate = bulkLead.Leads
                .Where(ld => ld.Lead.EmployeeCode == null)
                .Take(customratio)
                .ToList();

            if (!leadsToUpdate.Any())
                return new List<_BulkLead.LeadDetail>();
            foreach (var leadDetail in leadsToUpdate)
            {
                leadDetail.Lead.EmployeeCode = employeeCode;
            }
            var updateDefinition = Builders<_BulkLead>.Update.Set(b => b.Leads, bulkLead.Leads);

            await _collection.UpdateOneAsync(filter, updateDefinition);
            await _collection.UpdateOneAsync(filter, updateDefinition);
            return leadsToUpdate;
        }

        public async Task<List<_BulkLead.LeadDetail>> GetLeadsByEmployeeCodeAsync(string employeeCode)
        {
            var filter = Builders<_BulkLead>.Filter.ElemMatch(b => b.Leads, lead => lead.Lead.EmployeeCode == employeeCode);
            var bulkLeads = await _collection.Find(filter).ToListAsync();
            var leads = bulkLeads
                .SelectMany(b => b.Leads)
                .Where(ld => ld.Lead.EmployeeCode == employeeCode)
                .ToList();

            return leads;
        }

    }
}
