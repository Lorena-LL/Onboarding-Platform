using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Constants;
using OnboardingAPI.DTOs;
using OnboardingAPI.Services;

namespace OnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            AuthResponseDTO? result = await _authService.Register(dto);
            if (result == null)
                return BadRequest(ErrorMessages.EmailAlreadyExists);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            AuthResponseDTO? result = await _authService.Login(dto);
            if (result == null)
                return Unauthorized(ErrorMessages.EmailOrPasswordIncorrect);

            return Ok(result);
        }
    }
}