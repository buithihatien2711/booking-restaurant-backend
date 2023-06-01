using backend.DTOs.IdentityDTO;

namespace backend.Services.UserService
{
    public interface IAuthService
    {
        string Login(UserLoginDto userLoginDto);

        string Register(UserRegisterDto userRegisterDto);
    }
}