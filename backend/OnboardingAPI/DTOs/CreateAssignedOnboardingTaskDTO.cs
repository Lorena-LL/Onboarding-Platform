namespace OnboardingAPI.DTOs
{
    public record CreateAssignedOnboardingTaskDTO(
        Guid TaskId,
        Guid UserId,
        DateTime AssignedAt,
        DateTime DueAt
    );
}