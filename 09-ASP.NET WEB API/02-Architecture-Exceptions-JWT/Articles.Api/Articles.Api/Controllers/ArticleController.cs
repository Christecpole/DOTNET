using Articles.Api.Dtos;
using Articles.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }
        //Tout le monde peut y acceder
        // Meme sans token meme sans compte
        // Pas besoin de l'attribut [Authorize]
        [HttpGet]
        public ActionResult<List<ArticleDto>> GetAll([FromQuery] int? auteurId)
        {
            //On verifie si un parametre auteurId a été passé dans l'url
            // /api/article?auteurId=2
            if (auteurId.HasValue) 
            {
                // Si oui on demande au service de filtrer
                // Resultat : HTTP 200 OK + liste filtrée en json
                return Ok(_service.GetByAuteurId(auteurId.Value));
            }

            // Si pas de auteur ID
            // Retourne tous les articles en base
            // Resultat : HTTP 200 OK + liste complete des articles en JSON.
            return Ok(_service.GetAll());

        }

        [HttpGet("article/{id}")]
        public ActionResult<ArticleDto> GetById([FromRoute] int id)
        {
            var article = _service.GetById(id);
            return Ok(article);
        }

        // Il faut un token jwt valide pour créer
        //Pas donner de role donc n'importe quel role peux acceder
        //Sans token => 401 Unauthorized
        [Authorize] 
        [HttpPost]
        public ActionResult<ArticleDto> Create([FromBody] ArticleCreateDto dto)
        {
            //L'attribut ApiController en haut de la classe fait cette vérification
            // Donc ce n'est plus obligatoire sauf en cas de test unitaire
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var articleCree = _service.Add(dto);

            return CreatedAtAction(nameof(GetById), new { Id = articleCree.Id }, articleCree);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ArticleUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            //On demande au service de faire la mise à jour
            //Il renvoie true si ca a marché et false si l'article à modifier n'existe pas
            _service.Update(id, dto);
            
            // Si ça a marché, on repond HTTP 204 (no content)
            // "C'est bon c'est fait rien de plus à dire"
            return NoContent();
        
        }

        //Token JWT valide + Claim Role = Admin
        //un user connecté mais autorisé => 403 Forbidden
        // Un user qui n'a pas de token => 401 Unauthorized
        [Authorize(Roles ="Admin")] // Admin uniquement
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _service.Delete(id);
                return NoContent();//Succès 204

        }
    }
}
