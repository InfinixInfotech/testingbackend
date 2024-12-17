using Models.Settings;

namespace Repository.Settings.IClass
{
    public interface IUsersRepository
    {
        Task AddUsers(Users users);
        Task<string> GeEmpCode(string mobile);
        Task UpdateUsersById(Users model);
        Task<List<Users>> GetAllUsers();
        Task<List<EmployeeDetails>> GetAllEmployeeCodeAndName();
        Task<Users> GetUserById(int id);
        Task<Users> GetUserByUserNameAsync(string userName);
        Task<userresponseData> GetUserDetailsByUsername(string username);
        Task<List<Users>> GetAllUserDetailsByGroupName(string groupName);
        Task<List<EmployeeDetails>> GetAllEmployeeCodeEmployeeNameByGroupName(string groupName);
        List<string> GetEmployeeCredentialsByGroupId(string groupId);
    }
}
