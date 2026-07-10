namespace OnboardingAPI.DTOs
{
    public record TeamMemberResponseDTO(
        Guid Id,
        Guid UserId,
        Guid TeamId,
        DateTime DateJoined
    );
}