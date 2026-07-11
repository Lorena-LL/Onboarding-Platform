using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs
{
    public record UpdateAssignedOnboardingTaskDTO(
        DateTime DueAt,
        DateTime? CompletedAt,
        AssignedOnboardingTaskStatus Status
    );
}