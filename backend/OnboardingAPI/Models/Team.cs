using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnboardingAPI.Models
{
    public class Team
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid LeadUserId { get; set; }

        [ForeignKey(nameof(LeadUserId))]
        public User LeadUser { get; set; } = null!;

        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();
    }
}