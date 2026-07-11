using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs
{
    public record UpdateOnboardingTaskDTO(
        string Name,
        OnboardingTaskCategory Category,
        string Description
    );
}