using Common;
using Models.Settings;

namespace Services.Settings.IClass
{
    public interface IUsersService
    {
        Task<Response> AddUsers(Users users);
        Task<Response> UpdateUsersById(Users model);
        Task<Response> GetAllUsers();
        Task<Response> GetUserById(int id);
        Task<Response> GetAllEmployeeCodeAndName();
        Task<Response> UploadBulkUser(BulkUser user);
    }
}
