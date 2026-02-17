using Articles.Api.Dtos;
using Articles.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly IAuteurService _service;

        public AuteurController(IAuteurService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuteurDto>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuteurDto>> GetByIdAsync([FromRoute] int id)
        {
            var auteur = await _service.GetByIdAsync(id);

            if (auteur == null) return NotFound();

            return Ok(auteur);
        }

        [HttpPost]
        public async Task<ActionResult<AuteurDto>> CreateAsync([FromBody] AuteurCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var auteurCree = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = auteurCree.Id }, auteurCree);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] AuteurCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }
}
