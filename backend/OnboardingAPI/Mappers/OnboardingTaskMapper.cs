using OnboardingAPI.DTOs.OnboardingTask;
using OnboardingAPI.Models;

namespace OnboardingAPI.Mappers
{
    public class OnboardingTaskMapper
    {
        public static OnboardingTaskResponseDTO ToResponseDTO(OnboardingTask onboardingTask)
        {
            return new OnboardingTaskResponseDTO
            (
                onboardingTask.Id,
                onboardingTask.Name,
                onboardingTask.Category,
                onboardingTask.Description
            );
        }

        public static OnboardingTask ToEntity(CreateOnboardingTaskDTO dto)
        {
            return new OnboardingTask
            {
                Name = dto.Name,
                Category = dto.Category,
                Description = dto.Description
            };
        }
    }
}