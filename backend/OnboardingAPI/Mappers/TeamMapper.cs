using OnboardingAPI.DTOs.Team;
using OnboardingAPI.Models;

namespace OnboardingAPI.Mappers
{
    public static class TeamMapper
    {
        public static TeamResponseDTO ToResponseDTO(Team team)
        {
            return new TeamResponseDTO(
                team.Id,
                team.LeadUserId,
                team.Name
            );
        }

        public static Team ToEntity(CreateTeamDTO dto)
        {
            return new Team
            {
                LeadUserId = dto.LeadUserId,
                Name = dto.Name
            };
        }
    }
}