using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs
{
    public record UpdateProfileDTO(
        string FirstName,
        string LastName,
        Role Role,
        DateTime HiredDate,
        DateTime BirthDate
    );
}