namespace OnboardingAPI.DTOs
{
    public record LoginDTO(
        string Email = "", 
        string Password = ""
    );
}