namespace OnboardingAPI.DTOs.Team
{
    public record UpdateTeamDTO(
        Guid LeadUserId,
        string Name
    );
}