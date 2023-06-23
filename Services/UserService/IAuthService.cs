using backend.DTOs.IdentityDTO;

namespace backend.Services.UserService
{
    public interface IAuthService
    {
        string Login(UserLoginDto userLoginDto, int role);

        string Register(UserRegisterDto userRegisterDto);
    }
}