using Common;
using DnsClient;
using Models.Settings;
using Repository.Settings.Class;
using Repository.Settings.IClass;
using Services.Settings.IClass;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Services.Settings.Class
{
    public class UsersService : IUsersService
    {
        private readonly IGroupsRepository _groupsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly SequenceGenerator _sequenceGenerator;
        public UsersService(IUsersRepository usersRepository, SequenceGenerator sequenceGenerator, IGroupsRepository groupsRepository)
        {
            _usersRepository = usersRepository;   
            _sequenceGenerator = sequenceGenerator;
            _groupsRepository = groupsRepository;
        }
        public async Task<Response> AddUsers(Users users)
        {
            try
            {
                var Emp = await _usersRepository.GeEmpCode(users.MobileNumber);
                if (Emp != null)
                {
                    return new Response
                    {
                        Success = true,
                        Message = "User already exist",
                        Data = Emp,
                    };
                }
                users.GroupId = await _groupsRepository.GetGroupIdByGroupName(users.GroupName);                
                var id = _sequenceGenerator.GetNextSequence("Demo_users", "Demousers_Sequence");
                users.Id = id;
                var splitValue = GenerateSplitValue(users);
                var seq = $"INF{splitValue}{id:D2}";
                users.EmployeeCode = seq ;
                users.UserName = seq;
                await _usersRepository.AddUsers(users);
                return new Response { Success = true, Message = "Users added successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        private string GenerateSplitValue(Users users)
        {
            string firstName = users.FullName?.Split(' ')[0].ToLower();
            string abc = firstName.ToUpper();
            string dayPart = users.DateOfBirth.ToString("dd");
            return $"{abc}{dayPart}";
        }

        public async Task<Response> UpdateUsersById(Users model)
        {
            try
            {
                await _usersRepository.UpdateUsersById(model);
                return new Response { Success = true, Message = "=Users updated successfully" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
        public async Task<Response> GetAllUsers()
        {
            try
            {
                var users = await _usersRepository.GetAllUsers();

                // Map Users to GetUsers
                var data = users.Select(user => new GetUsers
                {
                    FullName = user.FullName,
                    EmployeeCode = user.EmployeeCode,
                    MobileNumber = user.MobileNumber,
                    UserName = user.UserName,
                    Password = user.Password,
                    ReportingTo = user.ReportingTo,
                    GroupName = user.GroupName,
                    DepartmentName = user.DepartmentName,
                    DesignationName = user.DesignationName,
                    QualificationName = user.QualificationName,
                    Extension = user.Extension,
                    DateOfBirth = user.DateOfBirth,
                    DateOfJoining = user.DateOfJoining
                }).ToList();

                return new Response { Success = true, Data = data };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }

        public async Task<Response> GetUserById(int id)
        {
            try
            {
                var user = await _usersRepository.GetUserById(id);
                if (user == null)
                {
                    return new Response { Success = false, Error = "User not found." };
                }
                return new Response { Success = true, Data = user };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Error = ex.Message };
            }
        }
    }
}
