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
        Task<Users> GetUserByUserNameAsync(string userName, string Password);
        Task<userresponseData> GetUserDetailsByUsername(string username);
        Task<List<Users>> GetAllUserDetailsByGroupName(string groupName);
        Task<List<EmployeeDetails>> GetAllEmployeeCodeEmployeeNameByGroupName(string groupName);
        List<string> GetEmployeeCredentialsByGroupId(string groupId);
        Task<string> GetCustomFetchRatioByEmpCode(string empCode);
        Task<string> GetFetchDateByEmployeeCode(string empCode);
        Task<Users> GetUserByEmployeeCodeAsync(string employeeCode);
        Task UpdateUserAsync(Users user);
        Task<int> GetTotalFetchedLeadsByDateAsync(string employeeCode, string currentDate);
        Task UpdateTotalFetchedLeadsAsync(string employeeCode, string currentDate, int newTotalFetchedLeads);
        Task AddFetchedLeadAsync(string employeeCode, FetchedLeads newFetchedLead);
    }
}
