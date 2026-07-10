using Microsoft.EntityFrameworkCore;
using OnboardingAPI.Data;
using OnboardingAPI.DTOs;
using OnboardingAPI.Mappers;
using OnboardingAPI.Models;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Services
{
    public class TeamMemberService : ITeamMemberService
    {
        private readonly AppDbContext _context;

        public TeamMemberService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TeamMemberResponseDTO?> CreateAsync(CreateTeamMemberDTO dto)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == dto.UserId);
            if (user == null)
                return null;

            Team? team = await _context.Teams.FirstOrDefaultAsync(t => t.Id == dto.TeamId);
            if (team == null)
                return null;

            bool alreadyMember = await _context.TeamMembers
                .AnyAsync(tm => tm.UserId == dto.UserId && tm.TeamId == dto.TeamId);

            if (alreadyMember)
                return null;

            TeamMember teamMember = TeamMemberMapper.ToEntity(dto);
            teamMember.User = user;
            teamMember.Team = team;

            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            return TeamMemberMapper.ToResponseDTO(teamMember);
        }

        public async Task<TeamMemberResponseDTO?> GetByIdAsync(Guid id)
        {
            TeamMember? teamMember = await _context.TeamMembers
                .Include(tm => tm.User)
                .Include(tm => tm.Team)
                .FirstOrDefaultAsync(tm => tm.Id == id);

            if (teamMember == null)
                return null;

            return TeamMemberMapper.ToResponseDTO(teamMember);
        }

        public async Task<TeamMemberResponseDTO?> UpdateAsync(Guid id, UpdateTeamMemberDTO dto)
        {
            TeamMember? teamMember = await _context.TeamMembers
                .Include(tm => tm.User)
                .Include(tm => tm.Team)
                .FirstOrDefaultAsync(tm => tm.Id == id);

            if (teamMember == null)
                return null;

            teamMember.DateJoined = dto.DateJoined;

            await _context.SaveChangesAsync();

            return TeamMemberMapper.ToResponseDTO(teamMember);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            TeamMember? teamMember = await _context.TeamMembers
                .FirstOrDefaultAsync(tm => tm.Id == id);

            if (teamMember == null)
                return false;

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}