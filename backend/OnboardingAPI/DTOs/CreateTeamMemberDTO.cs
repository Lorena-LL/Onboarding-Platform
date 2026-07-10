namespace OnboardingAPI.DTOs
{
    public record CreateTeamMemberDTO(
        Guid UserId,
        Guid TeamId,
        DateTime DateJoined
    );
}