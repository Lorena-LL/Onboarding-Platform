namespace OnboardingAPI.DTOs.TeamMember
{
    public record CreateTeamMemberDTO(
        Guid UserId,
        Guid TeamId,
        DateTime DateJoined
    );
}