namespace OnboardingAPI.DTOs.TeamMember
{
    public record TeamMemberResponseDTO(
        Guid Id,
        Guid UserId,
        Guid TeamId,
        DateTime DateJoined
    );
}