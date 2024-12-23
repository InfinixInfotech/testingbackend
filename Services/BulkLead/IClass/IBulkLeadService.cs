using Common;
using Models.BulkLeads;
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
    }
}
