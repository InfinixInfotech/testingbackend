using Common;
using Models.Login;
using Repository.Login.IClass;
using Repository.Settings.IClass;
using Services.Login.IClass;

namespace Services.Login.Class
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository _userRepository;
        private readonly IGroupsRepository _groupsRepository;
        private readonly JwtAcessToken _jwtAcesstoken;

        public AuthService(IUsersRepository userRepository, JwtAcessToken jwtAcesstoken, IGroupsRepository groupsRepository)
        {
            _userRepository = userRepository;
            _jwtAcesstoken = jwtAcesstoken;
            _groupsRepository = groupsRepository;
        }
        public async Task<AuthResponse> LoginAsync(LoginData loginData)
        {
            var username = await _userRepository.GetUserByUserNameAsync(loginData.UserName,loginData.Password);

            if (username.UserName == null && username.Password == null)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Invalid username or password.",  
                    Error = "UnAuthorize Users"
                };
            }
            var userDetails = await _userRepository.GetUserDetailsByUsername(loginData.UserName);
           // var getGroupData = await _groupsRepository.GetGroupsByGroupName(userDetails.GroupName);
            var tokenRole = userDetails.FullName == "Admin" ? "admin" : "user";
            var token = await _jwtAcesstoken.GenerateJWT(tokenRole);
            return new AuthResponse
            {
                Success = true,
                Token = token,
                Message = "Login successful.",
                EmployeeCode = userDetails.EmpCode,
                GroupName = userDetails.GroupName,
               // Data = getGroupData,
                UserName = userDetails.FullName,
            };
        }

        //public async Task CreateUserAsync(User user)
        //{
        //    user.Id = _sequenceGenerator.GetNextSequence("Demo_login", "Demologin_Sequence");
        //    await _userRepository.CreateUserAsync(user);
        //}
    }
}
