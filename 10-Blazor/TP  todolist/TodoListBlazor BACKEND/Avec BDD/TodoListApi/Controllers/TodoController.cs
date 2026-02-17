using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TodoListApi.DTOs;
using TodoListApi.Services;

namespace TodoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _service;

        public TodoController(ITodoService service)
        {
            _service = service;
        }

        // GET api/todos
        // GET api/todos?completed=true
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<TodoItemDto>>> GetAll([FromQuery] bool? completed)
        {
            var userId = GetUserId();

            if (completed.HasValue)
            {
                return Ok(await _service.GetByStatusAsync(userId, completed.Value));
            }
            return Ok(await _service.GetAllAsync(userId));
        }

        // GET api/todos/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDto>> GetById([FromRoute] int id)
        {
            var userId = GetUserId();
            var item = await _service.GetByIdAsync(userId, id);
            return Ok(item);
        }

        // POST api/todos
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TodoItemDto>> Create([FromBody] TodoItemCreateDto dto)
        {
            var userId = GetUserId();
            var created = await _service.CreateAsync(userId, dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/todos/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TodoItemUpdateDto dto)
        {
            var userId = GetUserId();
            await _service.UpdateAsync(userId, id, dto);
            return NoContent();
        }

        // PATCH api/todos/5/complete
        [Authorize]
        [HttpPatch("{id}/complete")]
        public async Task<IActionResult> MarkAsComplete([FromRoute] int id)
        {
            var userId = GetUserId();
            await _service.MarkAsCompleteAsync(userId, id);
            return NoContent();
        }

        // DELETE api/todos/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var userId = GetUserId();
            await _service.DeleteAsync(userId, id);
            return NoContent();
        }

        private int GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                              ?? User.FindFirst("sub")?.Value; // si tu utilises sub (JWT standard)

            if (string.IsNullOrWhiteSpace(userIdClaim) || !int.TryParse(userIdClaim, out var userId))
                throw new UnauthorizedAccessException("UserId introuvable dans le token.");

            return userId;
        }
    }
}
