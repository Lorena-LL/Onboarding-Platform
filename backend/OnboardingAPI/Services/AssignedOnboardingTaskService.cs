using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Data;
using OnboardingAPI.DTOs;
using OnboardingAPI.Mappers;
using OnboardingAPI.Models;
using OnboardingAPI.Models.Enums;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Services
{
    public class AssignedOnboardingTaskService : IAssignedOnboardingTaskService
    {
        private readonly AppDbContext _context;

        public AssignedOnboardingTaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AssignedOnboardingTaskResponseDTO?> CreateAsync(CreateAssignedOnboardingTaskDTO dto)
        {
            bool taskExists = await _context.OnboardingTasks.AnyAsync(t => t.Id == dto.TaskId);
            if (!taskExists) return null;

            bool userExists = await _context.Users.AnyAsync(u => u.Id == dto.UserId);
            if (!userExists) return null;

            AssignedOnboardingTask assignedTask = AssignedOnboardingTaskMapper.ToEntity(dto);
            _context.AssignedOnboardingTasks.Add(assignedTask);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return null;
            }

            return AssignedOnboardingTaskMapper.ToResponseDTO(assignedTask);
        }

        public async Task<AssignedOnboardingTaskResponseDTO?> GetByIdAsync(Guid id)
        {
            AssignedOnboardingTask? assignedTask = await _context.AssignedOnboardingTasks
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignedTask == null) return null;

            return AssignedOnboardingTaskMapper.ToResponseDTO(assignedTask);
        }

        public async Task<List<AssignedOnboardingTaskDetailedDTO>> GetAllActiveForUserAsync(Guid userId)
        {
            List<AssignedOnboardingTask> activeAssignedTasks = await _context.AssignedOnboardingTasks
                .Include(a => a.Task)
                .Where(a => a.UserId == userId && a.Status == AssignedOnboardingTaskStatus.Active)
                .OrderBy(a => a.DueAt)
                .ToListAsync();

            return activeAssignedTasks
                .Select(AssignedOnboardingTaskMapper.ToDetailedDTO)
                .ToList();
        }

        public async Task<List<AssignedOnboardingTaskDetailedDTO>> GetAllCompletedForUserAsync(Guid userId)
        {
            List<AssignedOnboardingTask> completedAssignedTasks = await _context.AssignedOnboardingTasks
                .Include(a => a.Task)
                .Where(a => a.UserId == userId && a.Status == AssignedOnboardingTaskStatus.Completed)
                .OrderBy(a => a.DueAt)
                .ToListAsync();

            return completedAssignedTasks
                .Select(AssignedOnboardingTaskMapper.ToDetailedDTO)
                .ToList();
        }

        public async Task<AssignedOnboardingTaskResponseDTO?> UpdateAsync(Guid id, UpdateAssignedOnboardingTaskDTO dto)
        {
            AssignedOnboardingTask? assignedTask = await _context.AssignedOnboardingTasks
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignedTask == null) return null;

            assignedTask.DueAt = dto.DueAt;
            assignedTask.CompletedAt = dto.CompletedAt;
            assignedTask.Status = dto.Status;

            await _context.SaveChangesAsync();

            return AssignedOnboardingTaskMapper.ToResponseDTO(assignedTask);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            AssignedOnboardingTask? assignedTask = await _context.AssignedOnboardingTasks
                .FirstOrDefaultAsync(a => a.Id == id);

            if (assignedTask == null) return false;

            _context.AssignedOnboardingTasks.Remove(assignedTask);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}