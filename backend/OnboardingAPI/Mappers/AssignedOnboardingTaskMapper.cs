using OnboardingAPI.DTOs;
using OnboardingAPI.Models;
using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.Mappers
{
    public class AssignedOnboardingTaskMapper
    {
        public static AssignedOnboardingTaskResponseDTO ToResponseDTO(AssignedOnboardingTask assignedTask)
        {
            return new AssignedOnboardingTaskResponseDTO(
                assignedTask.Id,
                assignedTask.TaskId,
                assignedTask.UserId,
                assignedTask.AssignedAt,
                assignedTask.DueAt,
                assignedTask.CompletedAt,
                assignedTask.Status
            );
        }

        public static AssignedOnboardingTaskDetailedDTO ToDetailedDTO(AssignedOnboardingTask assignedTask)
        {
            return new AssignedOnboardingTaskDetailedDTO(
                assignedTask.Id,
                assignedTask.TaskId,
                assignedTask.Task.Name,
                assignedTask.Task.Category,
                assignedTask.Task.Description,
                assignedTask.UserId,
                assignedTask.AssignedAt,
                assignedTask.DueAt,
                assignedTask.CompletedAt,
                assignedTask.Status
            );
        }

        public static AssignedOnboardingTask ToEntity(CreateAssignedOnboardingTaskDTO dto)
        {
            return new AssignedOnboardingTask
            {
                TaskId = dto.TaskId,
                UserId = dto.UserId,
                AssignedAt = dto.AssignedAt,
                DueAt = dto.DueAt,
                Status = AssignedOnboardingTaskStatus.Active
            };
        }
    }
}