using OnboardingAPI.DTOs;

namespace OnboardingAPI.Services.Interfaces
{
    public interface IAssignedOnboardingTaskService
    {
        Task<AssignedOnboardingTaskResponseDTO?> CreateAsync(CreateAssignedOnboardingTaskDTO dto);
        Task<AssignedOnboardingTaskResponseDTO?> GetByIdAsync(Guid id);
        Task<List<AssignedOnboardingTaskDetailedDTO>> GetAllForUserAsync(Guid userId);
        Task<AssignedOnboardingTaskResponseDTO?> UpdateAsync(Guid id, UpdateAssignedOnboardingTaskDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}