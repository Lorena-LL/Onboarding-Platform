using OnboardingAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models
{
    public class OnboardingTask
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public OnboardingTaskCategory Category { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}