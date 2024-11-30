using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Settings;

namespace Repository.Settings.IClass
{
    public interface ILeadStatusRepository
    {
        Task<IEnumerable<LeadStatus>> GetAllAsync();
        Task<LeadStatus> GetByIdAsync(int id);
        Task InsertAsync(LeadStatus leadStatus);
        Task UpdateByIdAsync(LeadStatus leadStatus);
        Task DeleteAsync(int id);
    }
}
