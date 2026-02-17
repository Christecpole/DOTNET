using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpGet]
        public ActionResult<List<TodoItemDto>> GetAll([FromQuery] bool? completed)
        {
            if (completed.HasValue)
            {
                return Ok(_service.GetByStatus(completed.Value));
            }
            return Ok(_service.GetAll());
        }

        // GET api/todos/5
        [HttpGet("{id}")]
        public ActionResult<TodoItemDto> GetById([FromRoute] int id)
        {
            var item = _service.GetById(id);
            return Ok(item);
        }

        // POST api/todos
        [HttpPost]
        public ActionResult<TodoItemDto> Create([FromBody] TodoItemCreateDto dto)
        {
            var created = _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/todos/5
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] TodoItemUpdateDto dto)
        {
            _service.Update(id, dto);
            return NoContent();
        }

        // PATCH api/todos/5/complete
        [HttpPatch("{id}/complete")]
        public IActionResult MarkAsComplete([FromRoute] int id)
        {
            _service.MarkAsComplete(id);
            return NoContent();
        }

        // DELETE api/todos/5
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
            return NoContent();
        }
    }
}
