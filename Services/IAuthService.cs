using backend.DTOs;

namespace backend.Services
{
    public interface IAuthService
    {
        string Login(UserLoginDto userLoginDto);

        string Register(UserRegisterDto userRegisterDto);
    }
}