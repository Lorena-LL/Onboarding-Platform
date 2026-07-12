using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.Profile
{
    public record CreateProfileDTO(
        Guid UserId,
        string FirstName,
        string LastName,
        Role Role,
        DateTime HiredDate,
        DateTime BirthDate
    );
}