using Common;
using Models.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Leads.IClass
{
    public interface ILeadService
    {
        Task<Response> AddLead(Lead lead);
        Task<Response> GetLeadById(int id, string apiType, string accessType, string groupName);
        Task<Response> UpdateLeadById(Lead model);
        Task<Response> GetAllLead(string apiType, string accessType, string groupName);
        Task<Response> DeleteLeadById(int id, string apiType, string accessType, string groupName);
    }
}
