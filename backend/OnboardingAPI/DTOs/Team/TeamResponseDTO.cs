namespace OnboardingAPI.DTOs.Team
{
    public record TeamResponseDTO(
        Guid Id,
        Guid LeadUserId,
        string Name
    );
}