using System.Security.Cryptography;
using System.Text;
using backend.Data.Entities;
using backend.Data.Repository.UserRepository;
using backend.DTOs.IdentityDTO;

namespace backend.Services.UserService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public string Login(UserLoginDto userLoginDto)
        {
            var currentUser = _userRepository.GetUserByPhone(userLoginDto.Phone);
            if(currentUser == null) {
                throw new BadHttpRequestException("Invalid phone number");
            }

            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(userLoginDto.Password)
            );
            for (int i = 1; i < currentUser.PasswordHash.Length ; i++)
            {
                if(currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    throw new UnauthorizedAccessException("Invalid password");
                }
            }

            return _tokenService.CreateToken(new UserTokenDto() 
            {
                Fullname = currentUser.Fullname,
                Phone = currentUser.Phone,
                Email = currentUser.Email
            });
        }

        public string Register(UserRegisterDto userRegisterDto)
        {
            if(userRegisterDto.Password != userRegisterDto.ConfirmPassword) {
                throw new BadHttpRequestException("Password and Confirm Password do not match.");
            }

            if(_userRepository.GetUserByPhone(userRegisterDto.Phone) != null) {
                throw new BadHttpRequestException("Phone is existed");
            }

            if(_userRepository.GetUserByPhone(userRegisterDto.Email) != null) {
                throw new BadHttpRequestException("Email is existed");
            }

            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(userRegisterDto.Password);
            
            var newUser = new User
            {
                Id = new Guid(),
                Fullname = userRegisterDto.Fullname,
                Phone = userRegisterDto.Phone,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(passwordBytes),
                Email = userRegisterDto.Email,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,


                // User register
                RoleId = 3
            };
            
            _userRepository.CreateUser(newUser);
            _userRepository.IsSaveChange();
            return _tokenService.CreateToken(new UserTokenDto() 
            {
                Fullname = newUser.Fullname,
                Phone = newUser.Phone,
                Email = newUser.Email
            });
        }
    }
}