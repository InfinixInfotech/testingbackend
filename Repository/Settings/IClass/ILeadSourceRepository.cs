using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Settings;

namespace Repository.Settings.IClass
{
    public interface ILeadSourceRepository
    {
        Task<IEnumerable<LeadSource>> GetAllAsync();
        Task<LeadSource> GetByIdAsync(int id);
        Task InsertAsync(LeadSource leadSource);
        Task UpdateAsync(LeadSource leadSource);
        Task DeleteAsync(int id);
       
    }
}
