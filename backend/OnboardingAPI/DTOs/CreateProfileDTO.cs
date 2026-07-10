using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs
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