using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Models.Settings;

namespace Services.Settings.IClass
{
    public interface ILeadSourceService
    {
        Task<Response> GetAllAsync();
        Task<Response> InsertAsync(LeadSource leadSource);
        Task<Response> UpdateAsync(LeadSource leadSource);
        Task<Response> DeleteAsync(int id);
        Task<Response> GetLeadSourceById(int id);
    }
}
