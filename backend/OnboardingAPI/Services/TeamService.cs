using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Data;
using OnboardingAPI.DTOs;
using OnboardingAPI.Mappers;
using OnboardingAPI.Models;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Services
{
    public class TeamService : ITeamService
    {
        private readonly AppDbContext _context;

        public TeamService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TeamResponseDTO?> CreateAsync(CreateTeamDTO dto)
        {
            User? lead = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.LeadUserId);
            if (lead == null)
                return null;

            Team team = TeamMapper.ToEntity(dto);
            team.LeadUser = lead;

            _context.Teams.Add(team);
            await _context.SaveChangesAsync();

            return TeamMapper.ToResponseDTO(team);
        }

        public async Task<TeamResponseDTO?> GetByIdAsync(Guid id)
        {
            Team? team = await _context.Teams
                .Include(t => t.LeadUser)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (team == null)
                return null;

            return TeamMapper.ToResponseDTO(team);
        }

        public async Task<IEnumerable<TeamColleagueResponseDTO>> GetLeadsAsync(Guid userId)
        {
            List<Guid> teamIds = await _context.TeamMembers
                .Where(tm => tm.UserId == userId)
                .Select(tm => tm.TeamId)
                .ToListAsync();

            List<TeamColleagueResponseDTO> leads = await (
                from team in _context.Teams
                join user in _context.Users
                    on team.LeadUserId equals user.Id
                join profile in _context.Profiles
                    on user.Id equals profile.Id
                where teamIds.Contains(team.Id)
                      && team.LeadUserId != userId
                select new TeamColleagueResponseDTO(
                    team.Id,
                    team.Name,
                    user.Id,
                    profile.FirstName,
                    profile.LastName,
                    user.Email,
                    profile.Role
                )
            ).ToListAsync();

            return leads;
        }

        public async Task<TeamResponseDTO?> UpdateAsync(Guid id, UpdateTeamDTO dto)
        {
            Team? team = await _context.Teams
                .Include(t => t.LeadUser)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (team == null)
                return null;

            User? lead = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.LeadUserId);
            if (lead == null)
                return null;

            team.LeadUserId = dto.LeadUserId;
            team.Name = dto.Name;

            await _context.SaveChangesAsync();

            return TeamMapper.ToResponseDTO(team);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Team? team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == id);

            if (team == null)
                return false;

            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}