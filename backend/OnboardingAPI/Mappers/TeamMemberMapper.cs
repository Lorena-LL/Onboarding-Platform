using OnboardingAPI.DTOs.TeamMember;
using OnboardingAPI.Models;

namespace OnboardingAPI.Mappers
{
    public static class TeamMemberMapper
    {
        public static TeamMemberResponseDTO ToResponseDTO(TeamMember tm)
        {
            return new TeamMemberResponseDTO(
                tm.Id,
                tm.UserId,
                tm.TeamId,
                tm.DateJoined
            );
        }

        public static TeamMember ToEntity(CreateTeamMemberDTO dto)
        {
            return new TeamMember
            {
                UserId = dto.UserId,
                TeamId = dto.TeamId,
                DateJoined = dto.DateJoined
            };
        }
    }
}