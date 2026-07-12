using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Data;
using OnboardingAPI.DTOs.Profile;
using OnboardingAPI.Mappers;
using OnboardingAPI.Models;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Services
{
    public class ProfileService : IProfileService
    {
        private readonly AppDbContext _context;

        public ProfileService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProfileAllInfoResponseDTO?> CreateAsync(CreateProfileDTO dto)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
            if (user == null) return null;

            bool profileAlreadyExists = await _context.Profiles.AnyAsync(p => p.Id == dto.UserId);
            if (profileAlreadyExists) return null;

            Profile profile = ProfileMapper.ToEntity(dto);
            profile.User = user;

            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return ProfileMapper.ToAllInfoResponseDTO(profile);
        }

        public async Task<ProfileAllInfoResponseDTO?> GetByIdAsync(Guid id)
        {
            Profile? profile = await _context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null) return null;
            return ProfileMapper.ToAllInfoResponseDTO(profile);
        }

        public async Task<ProfileAllInfoResponseDTO?> UpdateAsync(Guid id, UpdateProfileDTO dto)
        {
            Profile? profile = await _context.Profiles
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (profile == null) return null;

            profile.FirstName = dto.FirstName;
            profile.LastName = dto.LastName;
            profile.Role = dto.Role;
            profile.HiredDate = dto.HiredDate;
            profile.BirthDate = dto.BirthDate;

            await _context.SaveChangesAsync();

            return ProfileMapper.ToAllInfoResponseDTO(profile);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Profile? profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == id);
            if (profile == null) return false;

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}