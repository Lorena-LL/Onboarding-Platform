using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.Constants;
using OnboardingAPI.DTOs.AssignedOnboardingTask;
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
            AssignedOnboardingTaskDetailedDTO? result = await _assignedTaskService.GetByIdAsync(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("user/{userId}/active")]
        public async Task<IActionResult> GetAllActiveForUser(Guid userId)
        {
            List<AssignedOnboardingTaskDetailedDTO> result = await _assignedTaskService.GetAllActiveForUserAsync(userId);
            return Ok(result);
        }

        [HttpGet("user/{userId}/completed")]
        public async Task<IActionResult> GetAllCompletedForUser(Guid userId)
        {
            List<AssignedOnboardingTaskDetailedDTO> result = await _assignedTaskService.GetAllCompletedForUserAsync(userId);
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

        [HttpPatch("{assignedTaskId}/complete/user/{userId}")]
        public async Task<IActionResult> CompleteTask(Guid assignedTaskId, Guid userId)
        {
            bool completed = await _assignedTaskService.CompleteTaskAsync(assignedTaskId, userId);

            if (!completed)
                return NotFound();

            return NoContent();
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