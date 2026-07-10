using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public Profile? Profile { get; set; }

        public ICollection<Team> LedTeams { get; set; } = new List<Team>();
    }
}