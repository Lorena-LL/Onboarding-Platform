using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.AssignedOnboardingTask
{
    public record UpdateAssignedOnboardingTaskDTO(
        DateTime DueAt,
        DateTime? CompletedAt,
        AssignedOnboardingTaskStatus Status
    );
}