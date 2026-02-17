using ApiCitation.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCitation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitationsController : ControllerBase
    {
        private static readonly Dictionary<int, (string Auteur, string Texte)> _citations = new()
        {
            { 1, ("Albert Einstein", "La logique vous mènera d'un point A à un point B. L'imagination vous mènera partout.") },
            { 2, ("Steve Jobs", "Innovation distingue un leader d'un suiveur.") },
            { 3, ("Marie Curie", "Rien dans la vie n'est à craindre, tout est à comprendre.") }
        };

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok(new
            {
                status = "ok",
                message = "API Citations en ligne"
            });
        }

        [HttpGet("{id:int}")]
        public IActionResult ObtenirParId(int id)
        {
            if (id <= 0)
            {
                return BadRequest("L'identifiant doit être strictement positif");
            }

            if(!_citations.TryGetValue(id, out var citation))
            {
                return NotFound();
            }

            return Ok(new { id, citation.Auteur, citation.Texte });
        }

        public IActionResult Creer([FromBody] CitationDtoCreation dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _citations.Count == 0 ? 1 : _citations.Keys.Max() + 1;
            _citations[id] = (dto.Auteur, dto.Texte);
            var item = new { id , dto.Auteur, dto.Texte };

            return CreatedAtAction(nameof(ObtenirParId), new { id }, item);
        }

        public IActionResult Supprimer(int id)
        {
            if (id <= 0)
            {
                return BadRequest("L'identifiant doit être strictement positif");
            }

            if (!_citations.ContainsKey(id))
            {
                return NotFound();
            }

            _citations.Remove(id);
            return NoContent();
        }

    }
}
