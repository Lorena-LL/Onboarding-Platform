using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnboardingAPI.Models.Enums;

namespace OnboardingAPI.Models
{
    public class Profile
    {
        [Key]
        [ForeignKey(nameof(User))]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public Role Role { get; set; }

        [Required]
        public DateTime HiredDate { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public User User { get; set; } = null!;
    }
}