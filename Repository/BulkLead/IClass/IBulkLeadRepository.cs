using Models.BulkLeads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.BulkLead.IClass
{
    public interface IBulkLeadRepository
    {
        Task AddBulkLeads(_BulkLead lead);
        Task<bool> GetByCampaignName(string CampaignName);
        Task<bool> AddLeadToCampaign(string campaignName, _BulkLead.LeadDetail newLeadDetail);
        Task<List<_BulkLead.LeadDetail>> GetTop5LeadsByCampaignNameAsync(string campaignName, int customratio);
    }
}
