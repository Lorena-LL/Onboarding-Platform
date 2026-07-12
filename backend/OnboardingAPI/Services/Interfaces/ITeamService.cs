using OnboardingAPI.DTOs.Team;
using OnboardingAPI.DTOs.TeamMember;

namespace OnboardingAPI.Services.Interfaces
{
    public interface ITeamService
    {
        Task<TeamResponseDTO?> CreateAsync(CreateTeamDTO dto);
        Task<TeamResponseDTO?> GetByIdAsync(Guid id);
        Task<IEnumerable<TeamColleagueResponseDTO>> GetLeadsAsync(Guid userId);
        Task<TeamResponseDTO?> UpdateAsync(Guid id, UpdateTeamDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}