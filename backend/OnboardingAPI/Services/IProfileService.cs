using OnboardingAPI.DTOs;

namespace OnboardingAPI.Services
{
    public interface IProfileService
    {
        Task<ProfileAllInfoResponseDTO?> CreateAsync(CreateProfileDTO dto);
        Task<ProfileAllInfoResponseDTO?> GetByIdAsync(Guid id);
        Task<ProfileAllInfoResponseDTO?> UpdateAsync(Guid id, UpdateProfileDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}