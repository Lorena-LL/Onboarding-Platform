using OnboardingAPI.DTOs;

namespace OnboardingAPI.Services.Interfaces
{
    public interface ITeamMemberService
    {
        Task<TeamMemberResponseDTO?> CreateAsync(CreateTeamMemberDTO dto);
        Task<TeamMemberResponseDTO?> GetByIdAsync(Guid id);
        Task<TeamMemberResponseDTO?> UpdateAsync(Guid id, UpdateTeamMemberDTO dto);
        Task<bool> DeleteAsync(Guid id);
    }
}