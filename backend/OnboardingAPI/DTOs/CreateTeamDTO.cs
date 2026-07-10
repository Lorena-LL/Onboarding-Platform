namespace OnboardingAPI.DTOs
{
    public record CreateTeamDTO(
        Guid LeadUserId,
        string Name
    );
}