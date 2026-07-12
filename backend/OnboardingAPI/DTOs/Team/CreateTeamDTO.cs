namespace OnboardingAPI.DTOs.Team
{
    public record CreateTeamDTO(
        Guid LeadUserId,
        string Name
    );
}