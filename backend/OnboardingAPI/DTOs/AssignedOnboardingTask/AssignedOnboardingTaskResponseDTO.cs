using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.AssignedOnboardingTask
{
    public record AssignedOnboardingTaskResponseDTO(
        Guid Id,
        Guid TaskId,
        Guid UserId,
        DateTime AssignedAt,
        DateTime DueAt,
        DateTime? CompletedAt,
        AssignedOnboardingTaskStatus Status
    );
}