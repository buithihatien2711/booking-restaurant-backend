using backend.DTOs;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            
        }

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userRegister)
        {
            try
            {
                string token = _authService.Register(userRegister);
                return Ok(new SuccessResponse<string>()
                {
                    Success = true,
                    Message = "Register success",
                    Data = token
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }

        [HttpPost("login")]
        public ActionResult Login(UserLoginDto userLogin)
        {
            try
            {
                string token = _authService.Login(userLogin);
                return Ok(new SuccessResponse<string>()
                {
                    Success = true,
                    Message = "Login success",
                    Data = token
                });
            }
            catch (System.Exception ex)
            {
                return Unauthorized(new ErrorResponse()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                });
            }
        }
    }
}