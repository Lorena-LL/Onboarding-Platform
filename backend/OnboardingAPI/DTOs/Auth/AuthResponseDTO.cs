namespace OnboardingAPI.DTOs.Auth
{
    public record AuthResponseDTO(
        Guid Id = default,
        string Email = "",
        string Token = ""
    );
}
