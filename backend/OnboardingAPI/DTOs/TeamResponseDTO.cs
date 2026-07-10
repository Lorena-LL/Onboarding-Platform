namespace OnboardingAPI.DTOs
{
    public record TeamResponseDTO(
        Guid Id,
        Guid LeadUserId,
        string Name
    );
}