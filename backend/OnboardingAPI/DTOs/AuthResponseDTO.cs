namespace OnboardingAPI.DTOs
{
    public record AuthResponseDTO(Guid Id = default, string Email = "", string Token = "");
}
