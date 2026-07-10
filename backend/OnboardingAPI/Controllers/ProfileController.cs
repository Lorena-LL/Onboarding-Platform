using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Constants;
using OnboardingAPI.DTOs;
using OnboardingAPI.Services;

namespace OnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProfileDTO dto)
        {
            ProfileAllInfoResponseDTO? result = await _profileService.CreateAsync(dto);
            if (result == null)
                return BadRequest(ErrorMessages.UserAlreadyExistsOrHasProfile);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            ProfileAllInfoResponseDTO? result = await _profileService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProfileDTO dto)
        {
            ProfileAllInfoResponseDTO? result = await _profileService.UpdateAsync(id, dto);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = await _profileService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}