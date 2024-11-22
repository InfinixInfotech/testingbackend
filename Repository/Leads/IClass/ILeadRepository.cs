using Models.Leads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Leads.IClass
{
    public interface ILeadRepository
    {
        Task AddLead(Lead lead);
        Task<Lead> GetLeadById(int id);
        Task UpdateLeadById(Lead model);
        Task<List<Lead>> GetAllLead();
        Task<bool> DeleteLeadById(int id);
    }
}
