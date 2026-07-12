namespace OnboardingAPI.DTOs.Auth
{
    public record LoginDTO(
        string Email = "",
        string Password = ""
    );
}