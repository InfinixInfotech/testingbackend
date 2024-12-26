using Models.BulkLeads;
using Models.Leads;
using Models.Mail;
using Models.Settings;
using MongoDB.Bson;
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
                leadDetail.Lead.AssignedTo = employeeCode;
            }
            var updateDefinition = Builders<_BulkLead>.Update.Set(b => b.Leads, bulkLead.Leads);

            await _collection.UpdateOneAsync(filter, updateDefinition);
            await _collection.UpdateOneAsync(filter, updateDefinition);
            return leadsToUpdate;
        }

        public async Task<List<_BulkLead.LeadDetail>> GetLeadsByEmployeeCodeAndCampaignAsync(string employeeCode, string campaignName)
        {
            var filter = Builders<_BulkLead>.Filter.And(
                Builders<_BulkLead>.Filter.ElemMatch(
                    b => b.Leads,
                    lead => lead.Lead.EmployeeCode == employeeCode && lead.Lead.CampaignName == campaignName
                )
            );
            var bulkLeads = await _collection.Find(filter).ToListAsync();
            var leads = bulkLeads
                .SelectMany(b => b.Leads)
                .Where(ld => ld.Lead.EmployeeCode == employeeCode && ld.Lead.CampaignName == campaignName)
                .ToList();

            return leads;
        }

        public async Task<bool> UpdateLeadById(Lead model)
        {
            // Filter to find the document containing the specific LeadId in the Leads array
            var filter = Builders<_BulkLead>.Filter.ElemMatch(b => b.Leads, l => l.Lead.LeadId == model.LeadId);

            // Update the matching Lead object inside the Leads array using the positional operator $
            var updateDefinition = Builders<_BulkLead>.Update.Set("Leads.$.Lead", model);

            // Perform the update
            var result = await _collection.UpdateOneAsync(filter, updateDefinition);

            // Return success based on the number of modified documents
            return result.ModifiedCount > 0;
        }

        public async Task<List<string>> GetAllCampaignNamesAsync()
        {
            // Use a projection to retrieve only the CampaignName field
            var projection = Builders<_BulkLead>.Projection.Include(b => b.CampaignName);

            // Query the collection to get the campaign names
            var campaigns = await _collection.Find(Builders<_BulkLead>.Filter.Empty)
                                              .Project(projection)
                                              .ToListAsync();

            // Safely extract campaign names and filter out null or empty values
            return campaigns
                .Select(c => c.GetValue("CampaignName", BsonNull.Value))
                .Where(c => c != BsonNull.Value && !string.IsNullOrWhiteSpace(c.AsString))
                .Select(c => c.AsString)
                .Distinct()
                .ToList();
        }

        public async Task<List<_BulkLead.LeadDetail>> GetAllLeadsByEmployeeCodeAsync(string employeeCode)
        {
            // Filter to match documents containing leads with the specified employee code
            var filter = Builders<_BulkLead>.Filter.ElemMatch(
                b => b.Leads,
                lead => lead.Lead.EmployeeCode == employeeCode
            );

            // Find all matching documents
            var bulkLeads = await _collection.Find(filter).ToListAsync();

            // Extract and return the leads that match the employee code
            var leads = bulkLeads
                .SelectMany(b => b.Leads)
                .Where(ld => ld.Lead.EmployeeCode == employeeCode)
                .ToList();

            return leads;
        }

    }
}
