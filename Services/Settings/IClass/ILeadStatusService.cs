using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Models.Settings;

namespace Services.Settings.IClass
{
    public interface ILeadStatusService
    {
        Task<Response> GetAllAsync();
        Task<Response> InsertAsync(LeadStatus leadStatus);
        Task<Response> UpdateAsync(int id, LeadStatus leadStatus);
        Task<Response> DeleteAsync(int id);
    }
}
