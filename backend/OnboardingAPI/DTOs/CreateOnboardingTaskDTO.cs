using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs
{
    public record CreateOnboardingTaskDTO(
        string Name,
        OnboardingTaskCategory Category,
        string Description
    );
}