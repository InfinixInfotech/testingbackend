using Common;
using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Settings.IClass
{
    public interface IGroupsService
    {
        Task<Response> InsertAsync(Groups model);
        Task<Response> UpdateByIdAsync(Groups model);
        Task<Response> DeleteByIdAsync(int id);
        Task<Response> GetAllAsync();
        Task<Response> GetGroupsById(int id);
    }
}
