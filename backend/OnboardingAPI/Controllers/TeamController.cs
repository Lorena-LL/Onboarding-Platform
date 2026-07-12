using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Constants;
using OnboardingAPI.DTOs.Team;
using OnboardingAPI.DTOs.TeamMember;

using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDTO dto)
        {
            TeamResponseDTO? result = await _teamService.CreateAsync(dto);

            if (result == null)
                return BadRequest(ErrorMessages.LeadAssignedDoesNotExist);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            TeamResponseDTO? result = await _teamService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{userId}/leads")]
        public async Task<IActionResult> GetLeads(Guid userId)
        {
            IEnumerable<TeamColleagueResponseDTO> result = await _teamService.GetLeadsAsync(userId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateTeamDTO dto)
        {
            TeamResponseDTO? result = await _teamService.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = await _teamService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}