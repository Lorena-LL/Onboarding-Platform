using OnboardingAPI.DTOs;

namespace OnboardingAPI.Services.Interfaces
{
    public interface IOnboardingTaskService
    {
        Task<OnboardingTaskResponseDTO?> CreateAsync(CreateOnboardingTaskDTO dto);
        Task<OnboardingTaskResponseDTO?> GetByIdAsync(Guid id);
        Task<OnboardingTaskResponseDTO?> UpdateAsync(Guid id, UpdateOnboardingTaskDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}