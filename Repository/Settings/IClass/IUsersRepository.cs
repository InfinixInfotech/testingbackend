using Models.Settings;

namespace Repository.Settings.IClass
{
    public interface IUsersRepository
    {
        Task AddUsers(Users users);
        Task<string> GeEmpCode(string mobile);
        Task UpdateUsersById(Users model);
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
    }
}
