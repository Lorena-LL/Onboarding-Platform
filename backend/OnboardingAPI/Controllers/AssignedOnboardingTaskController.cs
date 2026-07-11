using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Constants;
using OnboardingAPI.DTOs;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignedOnboardingTaskController : ControllerBase
    {
        private readonly IAssignedOnboardingTaskService _assignedTaskService;

        public AssignedOnboardingTaskController(IAssignedOnboardingTaskService assignedTaskService)
        {
            _assignedTaskService = assignedTaskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAssignedOnboardingTaskDTO dto)
        {
            AssignedOnboardingTaskResponseDTO? result = await _assignedTaskService.CreateAsync(dto);
            if (result == null)
                return BadRequest(ErrorMessages.TaskOrUserDoesNotExist);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            AssignedOnboardingTaskResponseDTO? result = await _assignedTaskService.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllForUser(Guid userId)
        {
            List<AssignedOnboardingTaskDetailedDTO> result = await _assignedTaskService.GetAllForUserAsync(userId);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateAssignedOnboardingTaskDTO dto)
        {
            AssignedOnboardingTaskResponseDTO? result = await _assignedTaskService.UpdateAsync(id, dto);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = await _assignedTaskService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}