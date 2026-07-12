using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.OnboardingTask
{
    public record UpdateOnboardingTaskDTO(
        string Name,
        OnboardingTaskCategory Category,
        string Description
    );
}