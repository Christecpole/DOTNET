using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {message = "Hello API!", date =  DateTime.Now});
        }

        private static readonly Dictionary<int, string> _data = new()
        {
            {1, "Premier" },
            {2, "Deuxième" },
            {3, "Troisième" }
        };

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            if(id <= 0)
            {
                return BadRequest("L'identifiant doit être strictement positif");// renvoie 400 : Le client sait que sa requête est incorrect (mauvais paramètre). ce n'est pas que la ressource n'existe pas.
            }
            // Si l'id existe on récupère la valeur dans value

            if(!_data.TryGetValue(id, out var value))
            {
                return NotFound(); // La ressource n'existe pas. Le client comprend "pas trouvé"
            }

            return Ok(new { id, value }); // renvoie 200 OK + un petit objet json
        }

        public class CreateItemDto
        {
            public string Value { get; set; } = string.Empty;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateItemDto dto)
        {
            if (string.IsNullOrEmpty(dto.Value))
            {
                return BadRequest("Value est obligatoire");
            }

            var id = _data.Count > 0 ? _data.Keys.Max() + 1 : 1;
            _data[id] = dto.Value.Trim();

            var created = new { id, value = _data[id] };

            //201 : On indique où trouver la ressource et on envoie les données.
            return CreatedAtAction(nameof(GetById), new {id}, created);
            //CreatedAtAction : Renvoie 201 et le corps de la requete (created)
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if(id <= 0)
            {
                // 400
                return BadRequest("L'identifiant doit être strictement positif.");
            }

            if (!_data.ContainsKey(id))
            {
                return NotFound(); // 404
            }

            _data.Remove(id);

            return NoContent(); //Renvoie un code 204 = succès mais on ne renvoie aucun contenu

        }

        /*
         Ce qu'on a vu :

             OK => 200 avec le corps
            NotFound => 404
            BadRequest => 400 avec message
            CreatedAtAction => 201 Création bien passé
            NoContent => 204

        ce qu'on n'a pas encore vu :

            Unauthorized => 401 => pas de token/ login invalde
            Forbid => 403 => connecté mais pas les droits
            Conflit => 409 => par exemple : créer un produit qui existe déjà
            Erreur Serveur => StatusCode(500) ou des exception 500 => bugs base de données indisponible


         */



    }
}
