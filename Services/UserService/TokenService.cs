using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using backend.DTOs.IdentityDTO;
using Microsoft.IdentityModel.Tokens;

namespace backend.Services.UserService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string CreateToken(UserTokenDto userTokenDto)
        {
            var claims = new List<Claim>()
            {
                new Claim("Fullname", userTokenDto.Fullname),
                new Claim("Phone", userTokenDto.Phone),
                new Claim(JwtRegisteredClaimNames.Email, userTokenDto.Email),
                new Claim(JwtRegisteredClaimNames.Sub, userTokenDto.Id.ToString()),
            };
 
            var symmetricKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(
                    symmetricKey, SecurityAlgorithms.HmacSha512Signature)
            };
 
            var tokenHandler = new JwtSecurityTokenHandler();
 
            var token = tokenHandler.CreateToken(tokenDescriptor);
 
            return tokenHandler.WriteToken(token);
        }
    }
}