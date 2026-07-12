using OnboardingAPI.DTOs.Profile;
using OnboardingAPI.Models;

namespace OnboardingAPI.Mappers
{
    public static class ProfileMapper
    {
        public static ProfileAllInfoResponseDTO ToAllInfoResponseDTO(Profile profile)
        {
            return new ProfileAllInfoResponseDTO
            (
                profile.Id,
                profile.User.Email,
                profile.FirstName,
                profile.LastName,
                profile.Role,
                profile.HiredDate,
                profile.BirthDate
            );
        }

        public static Profile ToEntity(CreateProfileDTO dto)
        {
            return new Profile
            {
                Id = dto.UserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Role = dto.Role,
                HiredDate = dto.HiredDate,
                BirthDate = dto.BirthDate
            };
        }
    }
}