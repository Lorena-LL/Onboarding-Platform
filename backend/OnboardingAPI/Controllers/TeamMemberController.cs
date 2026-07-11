using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Constants;
using OnboardingAPI.DTOs;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamMemberController : ControllerBase
    {
        private readonly ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamMemberDTO dto)
        {
            TeamMemberResponseDTO? result = await _teamMemberService.CreateAsync(dto);

            if (result == null)
                return BadRequest(ErrorMessages.UserOrTeamDoesNotExistOrUserPartOfTeam);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            TeamMemberResponseDTO? result = await _teamMemberService.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{userId}/colleagues")]
        public async Task<IActionResult> GetColleagues(Guid userId)
        {
            IEnumerable<TeamColleagueResponseDTO> result = await _teamMemberService.GetColleaguesAsync(userId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateTeamMemberDTO dto)
        {
            TeamMemberResponseDTO? result = await _teamMemberService.UpdateAsync(id, dto);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = await _teamMemberService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}