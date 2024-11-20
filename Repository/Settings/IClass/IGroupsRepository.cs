using Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Settings.IClass
{
    public interface IGroupsRepository
    {
        Task InsertAsync(Groups model);
        Task UpdateByIdAsync(int id, Groups model);
        Task DeleteByIdAsync(int id);
        Task<List<Groups>> GetAllAsync();
    }
}
