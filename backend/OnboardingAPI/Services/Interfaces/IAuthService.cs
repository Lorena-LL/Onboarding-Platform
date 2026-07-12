using OnboardingAPI.DTOs.Auth;

namespace OnboardingAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO?> Register(RegisterDTO dto);
        Task<AuthResponseDTO?> Login(LoginDTO dto);
    }
}