using OnboardingAPI.DTOs;

namespace OnboardingAPI.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDTO?> Register(RegisterDTO dto);
        Task<AuthResponseDTO?> Login(LoginDTO dto);
    }
}