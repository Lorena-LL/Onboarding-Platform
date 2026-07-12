using OnboardingAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingAPI.Models
{
    public class AssignedOnboardingTask
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public OnboardingTask Task { get; set; } = null!;

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; } = null!;

        [Required]
        public DateTime AssignedAt { get; set; }

        [Required]
        public DateTime DueAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        [Required]
        public AssignedOnboardingTaskStatus Status { get; set; }
    }
}