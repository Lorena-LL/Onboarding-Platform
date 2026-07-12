using OnboardingAPI.DTOs.AssignedOnboardingTask;

namespace OnboardingAPI.Services.Interfaces
{
    public interface IAssignedOnboardingTaskService
    {
        Task<AssignedOnboardingTaskResponseDTO?> CreateAsync(CreateAssignedOnboardingTaskDTO dto);
        Task<AssignedOnboardingTaskDetailedDTO?> GetByIdAsync(Guid id);
        Task<List<AssignedOnboardingTaskDetailedDTO>> GetAllActiveForUserAsync(Guid userId);
        Task<List<AssignedOnboardingTaskDetailedDTO>> GetAllCompletedForUserAsync(Guid userId);
        Task<AssignedOnboardingTaskResponseDTO?> UpdateAsync(Guid id, UpdateAssignedOnboardingTaskDTO dto);
        Task<bool> CompleteTaskAsync(Guid assignedTaskId, Guid userId);
        Task<bool> DeleteAsync(Guid id);
    }
}