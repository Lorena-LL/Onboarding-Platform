namespace OnboardingAPI.DTOs.AssignedOnboardingTask
{
    public record CreateAssignedOnboardingTaskDTO(
        Guid TaskId,
        Guid UserId,
        DateTime AssignedAt,
        DateTime DueAt
    );
}