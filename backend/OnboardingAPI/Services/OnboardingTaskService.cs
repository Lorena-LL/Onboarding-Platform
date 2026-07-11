using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Data;
using OnboardingAPI.DTOs;
using OnboardingAPI.Mappers;
using OnboardingAPI.Models;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Services
{
    public class OnboardingTaskService : IOnboardingTaskService
    {
        private readonly AppDbContext _context;

        public OnboardingTaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<OnboardingTaskResponseDTO?> CreateAsync(CreateOnboardingTaskDTO dto)
        {
            OnboardingTask onboardingTask = OnboardingTaskMapper.ToEntity(dto);

            _context.OnboardingTasks.Add(onboardingTask);
            await _context.SaveChangesAsync();

            return OnboardingTaskMapper.ToResponseDTO(onboardingTask);
        }

        public async Task<OnboardingTaskResponseDTO?> GetByIdAsync(Guid id)
        {
            OnboardingTask? onboardingTask = await _context.OnboardingTasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (onboardingTask == null) return null;
            return OnboardingTaskMapper.ToResponseDTO(onboardingTask);
        }

        public async Task<OnboardingTaskResponseDTO?> UpdateAsync(Guid id, UpdateOnboardingTaskDTO dto)
        {
            OnboardingTask? onboardingTask = await _context.OnboardingTasks
                .FirstOrDefaultAsync(t => t.Id == id);

            if (onboardingTask == null) return null;

            onboardingTask.Name = dto.Name;
            onboardingTask.Category = dto.Category;
            onboardingTask.Description = dto.Description;

            await _context.SaveChangesAsync();

            return OnboardingTaskMapper.ToResponseDTO(onboardingTask);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            OnboardingTask? onboardingTask = await _context.OnboardingTasks.FirstOrDefaultAsync(t => t.Id == id);
            if (onboardingTask == null) return false;

            _context.OnboardingTasks.Remove(onboardingTask);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}