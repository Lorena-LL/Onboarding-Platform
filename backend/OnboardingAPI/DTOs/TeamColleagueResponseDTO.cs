using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.DTOs
{
    public record TeamColleagueResponseDTO(
        Guid TeamId,
        string TeamName,
        Guid UserId,
        string FirstName,
        string LastName,
        string Email,
        Role Role
    );
}