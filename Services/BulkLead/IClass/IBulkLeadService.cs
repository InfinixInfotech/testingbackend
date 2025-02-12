﻿using Common;
using Models.BulkLeads;
using Models.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.BulkLead.IClass
{
    public  interface IBulkLeadService
    {
        Task<Response> BulkLeadUpload(_leads bulkLead);
        Task<Response> CustomeFetchLeads(string EmployeeCode, string CampaignName);
        Task<Response> GetLeadByEmployeeCode(string employeeCode, string CampaignName);
        Task<Response> UpdateLeadById(Lead model);
        Task<Response> GetAllCampaignNamesAsync();
        Task<Response> GetAllLeadsByEmployeeCodeAsync(string employeeCode);
    }
}
