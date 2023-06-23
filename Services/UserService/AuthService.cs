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

        public string Login(UserLoginDto user, int role)
        {
            var currentUser = _userRepository.GetUserByPhone(user.Phone);
            if(currentUser == null) {
                throw new BadHttpRequestException("Invalid phone number");
            }

            using var hmac = new HMACSHA512(currentUser.PasswordSalt);
            var passwordBytes = hmac.ComputeHash(
                Encoding.UTF8.GetBytes(user.Password)
            );
            for (int i = 1; i < currentUser.PasswordHash.Length ; i++)
            {
                if(currentUser.PasswordHash[i] != passwordBytes[i])
                {
                    throw new UnauthorizedAccessException("Invalid password");
                }
            }

            if(currentUser.RoleId != role) {
                throw new UnauthorizedAccessException("Invalid phone or password");
            }

            return _tokenService.CreateToken(new UserTokenDto() 
            {
                Id = currentUser.Id,
                Fullname = currentUser.Fullname,
                Phone = currentUser.Phone,
                Email = currentUser.Email
            });
        }

        public string Register(UserRegisterDto user)
        {
            if(user.Password != user.ConfirmPassword) {
                throw new BadHttpRequestException("Password and Confirm Password do not match.");
            }

            if(_userRepository.GetUserByPhone(user.Phone) != null) {
                throw new BadHttpRequestException("Phone is existed");
            }

            if(_userRepository.GetUserByEmail(user.Email) != null) {
                throw new BadHttpRequestException("Email is existed");
            }

            using var hmac = new HMACSHA512();
            var passwordBytes = Encoding.UTF8.GetBytes(user.Password);
            
            var newUser = new User
            {
                Id = new Guid(),
                Fullname = user.Fullname,
                Phone = user.Phone,
                PasswordSalt = hmac.Key,
                PasswordHash = hmac.ComputeHash(passwordBytes),
                Email = user.Email,
                CreateAt = DateTime.Now,
                UpdateAt = DateTime.Now,


                // User register
                RoleId = user.Role
            };
            
            _userRepository.CreateUser(newUser);
            _userRepository.IsSaveChange();
            return _tokenService.CreateToken(new UserTokenDto() 
            {
                Id = newUser.Id,
                Fullname = newUser.Fullname,
                Phone = newUser.Phone,
                Email = newUser.Email
            });
        }
    }
}