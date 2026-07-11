using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs
{
    public record AssignedOnboardingTaskDetailedDTO(
        Guid Id,
        Guid TaskId,
        string TaskName,
        OnboardingTaskCategory TaskCategory,
        string TaskDescription,
        Guid UserId,
        DateTime AssignedAt,
        DateTime DueAt,
        DateTime? CompletedAt,
        AssignedOnboardingTaskStatus Status
    );
}