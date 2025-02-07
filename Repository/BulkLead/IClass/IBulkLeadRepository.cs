﻿using Models.BulkLeads;
using Models.Leads;
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
        Task<List<_BulkLead.LeadDetail>> UpdateTopLeadsByCampaignNameAsync(string campaignName, int customratio, string employeeCode);
        Task<List<_BulkLead.LeadDetail>> GetLeadsByEmployeeCodeAndCampaignAsync(string employeeCode, string campaignName);
        Task<bool> UpdateLeadById(Lead model);
        Task<List<string>> GetAllCampaignNamesAsync();
        Task<List<_BulkLead.LeadDetail>> GetAllLeadsByEmployeeCodeAsync(string employeeCode);
    }
}
