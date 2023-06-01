using backend.DTOs.IdentityDTO;

namespace backend.Services.UserService
{
    public interface ITokenService
    {
        string CreateToken(UserTokenDto userTokenDto);
    }
}