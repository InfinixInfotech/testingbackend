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
        Task UpdateByIdAsync(Groups model);
        Task DeleteByIdAsync(int id);
        Task<List<Groups>> GetAllAsync();
        Task<Groups> GetGroupsById(int id);
        Task<Groups> GetGroupsByGroupName(string groupName);
        Task<bool?> GetAccessKey(string apiType, string accessType,string groupName);
        Task<string> GetGroupIdByGroupName(string groupName);
        Task<string> GetByGroupNameGroupId(string groupId);
        Task<List<GroupDetails>> GetAllGroupNameAndID();
    }
}
