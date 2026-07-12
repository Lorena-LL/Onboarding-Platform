namespace OnboardingAPI.DTOs.Auth
{
    public record RegisterDTO(
        string Email = "",
        string Password = ""
    );
}