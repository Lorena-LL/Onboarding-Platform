using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.OnboardingTask
{
    public record CreateOnboardingTaskDTO(
        string Name,
        OnboardingTaskCategory Category,
        string Description
    );
}