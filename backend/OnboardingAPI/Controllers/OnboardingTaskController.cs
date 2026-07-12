using Microsoft.AspNetCore.Mvc;
using OnboardingAPI.DTOs.OnboardingTask;
using OnboardingAPI.Services.Interfaces;

namespace OnboardingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OnboardingTaskController : ControllerBase
    {
        private readonly IOnboardingTaskService _taskService;

        public OnboardingTaskController(IOnboardingTaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOnboardingTaskDTO dto)
        {
            OnboardingTaskResponseDTO? result = await _taskService.CreateAsync(dto);
            if (result == null)
                return BadRequest();

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            OnboardingTaskResponseDTO? result = await _taskService.GetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateOnboardingTaskDTO dto)
        {
            OnboardingTaskResponseDTO? result = await _taskService.UpdateAsync(id, dto);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = await _taskService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}