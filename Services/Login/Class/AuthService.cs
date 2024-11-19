using Common;
using Models.Login;
using Repository.Login.IClass;
using Services.Login.IClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Login.Class
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtAcessToken _jwtAcesstoken;
        private readonly SequenceGenerator _sequenceGenerator;

        public AuthService(IUserRepository userRepository, JwtAcessToken jwtAcesstoken, SequenceGenerator sequenceGenerator)
        {
            _userRepository = userRepository;
            _jwtAcesstoken = jwtAcesstoken;
            _sequenceGenerator = sequenceGenerator;
        }
        public async Task<AuthResponse> LoginAsync(LoginData loginData)
        {
            var user = await _userRepository.GetUserByUserNameAsync(loginData.UserName);

            if (user == null)
            {
                return new AuthResponse
                {
                    Success = false,
                    Message = "Invalid username or password."
                };
            }
            var token = await _jwtAcesstoken.GenerateJWT(user.UserName);

            return new AuthResponse
            {
                Success = true,
                Token = token,
                Message = "Login successful."
            };
        }

        public async Task CreateUserAsync(User user)
        {
            user.Id = _sequenceGenerator.GetNextSequence("Demo_login", "Demologin_Sequence");
            await _userRepository.CreateUserAsync(user);
        }
    }
}
