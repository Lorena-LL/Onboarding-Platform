using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Models;

namespace OnboardingAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<OnboardingTask> OnboardingTasks { get; set; }
        public DbSet<AssignedOnboardingTask> AssignedOnboardingTasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.Id);

            modelBuilder.Entity<Profile>()
                .Property(p => p.Role)
                .HasConversion<string>();

            modelBuilder.Entity<Team>()
               .HasOne(t => t.LeadUser)
               .WithMany(u => u.LedTeams)
               .HasForeignKey(t => t.LeadUserId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.Team)
                .WithMany(t => t.TeamMembers)
                .HasForeignKey(tm => tm.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TeamMember>()
                .HasOne(tm => tm.User)
                .WithMany(u => u.TeamMemberships)
                .HasForeignKey(tm => tm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TeamMember>()
                .HasIndex(tm => new { tm.TeamId, tm.UserId })
                .IsUnique();

            modelBuilder.Entity<OnboardingTask>()
                .Property(p => p.Category)
                .HasConversion<string>();

            modelBuilder.Entity<AssignedOnboardingTask>()
                .HasOne(a => a.Task)
                .WithMany()
                .HasForeignKey(a => a.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AssignedOnboardingTask>()
                .HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AssignedOnboardingTask>()
                .HasIndex(a => new { a.TaskId, a.UserId })
                .IsUnique();
        }
    }
}