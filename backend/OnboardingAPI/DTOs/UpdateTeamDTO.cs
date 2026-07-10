namespace OnboardingAPI.DTOs
{
    public record UpdateTeamDTO(
        Guid LeadUserId,
        string Name
    );
}