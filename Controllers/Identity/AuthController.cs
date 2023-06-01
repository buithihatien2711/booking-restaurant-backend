using backend.DTOs.IdentityDTO;
using backend.DTOs.ResponseDTO;
using backend.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers.Identity
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
                if(string.IsNullOrEmpty(userLogin.Phone) || string.IsNullOrEmpty(userLogin.Password)) 
                {
                    return BadRequest(new ErrorResponse()
                        {
                            Success = false,
                            ErrorMessage = "Please provide both your phone and password"
                        }
                    );
                }
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