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
        }
    }
}