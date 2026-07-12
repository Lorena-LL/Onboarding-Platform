using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.OnboardingTask
{
    public record OnboardingTaskResponseDTO(
        Guid Id,
        string Name,
        OnboardingTaskCategory Category,
        string Description
    );
}