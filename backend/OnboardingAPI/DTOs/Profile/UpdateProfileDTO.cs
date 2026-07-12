using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.Profile
{
    public record UpdateProfileDTO(
        string FirstName,
        string LastName,
        Role Role,
        DateTime HiredDate,
        DateTime BirthDate
    );
}