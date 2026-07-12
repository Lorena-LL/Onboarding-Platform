using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs.Profile
{
    public record ProfileAllInfoResponseDTO(
        Guid Id,
        string Email,
        string FirstName,
        string LastName,
        Role Role,
        DateTime HiredDate,
        DateTime BirthDate
    );
}