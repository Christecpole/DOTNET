using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        public static List<object> _produits = new()
        {
            new {Id=1, Nom="Ordinateur", Prix=1200.50},
            new {Id=2, Nom="Clavier", Prix=79.99},
            new {Id=3, Nom="Souris", Prix=149.49}
        };


        // Le navigateur a envoyé Get /api/produit, l'api a répondu OK 200 + les données JSon. Pas de HTML uniquement des données.
        // Get /api/produit
        [HttpGet] // Cette action répond aux requêtes GET
        public IActionResult ObtenirListe()
        {
            return Ok(_produits); // renvoie un code 200 OK + les données json de la liste produit
        }


        // Si le produit demandé existe on renvoie 200 OK + produit, sinon 404 not found
        // Get /api/produit/1
        [HttpGet("{id}")]
        public IActionResult ObtenirUnProduitParId(int id)
        {
            var produit = _produits.FirstOrDefault(p => ((dynamic)p).Id == id);

            if(produit == null)
            {
                return NotFound(); // 404
            }

            return Ok(produit); // 200
        }


        // Le client envoie des données JSON dans le corps de la requete [FromBody]
        // On créé le produit, on lui donne un Id , on l'ajoute à la liste,
        //puis on renvoie 201 Created + le produit crée
        // POST api/produit
        [HttpPost]
        public IActionResult Creer([FromBody] object nouveauProduit)
        {
            // pour la démo, on fait simple
            var id = _produits.Count + 1;
            var produit = new { Id = id, Nom = "Nouveau Produit", Prix = 99.99 };

            _produits.Add(produit);

            return StatusCode(201, produit); // 201 created
        }

        // On cherche le produit par son Id, s'il n'existe pas on envoie 404 sinon on le remplace puis on envoie 200 OK + le produit modifié.
        // PUT api/produit/1
        [HttpPut("{id:int}")]
        public IActionResult Modifier(int id, [FromBody] object produitModifie)
        {
            var index = _produits.FindIndex(p => ((dynamic)p).Id == id);

            if(index == -1)
            {
                return NotFound(); // 404
            }

            //Remplacer le produit
            _produits[index] = new { Id = id, Nom = "Produit Modifié", Prix = 199.99 };

            return Ok(_produits[index]); //200
        }

        //On cherche le produit, s'il n'existe pas code 404. Sinon on le supprime puis on renvoie code 204 NoCOntent(aucun corps, juste le code)
        // DELETE /api/produit/1
        [HttpDelete("{id}")]
        public IActionResult Supprimer(int id)
        {
            var produit = _produits.FirstOrDefault(p => ((dynamic)p).Id == id);

            if (produit == null)
            {
                return NotFound(); // 404
            }

            _produits.Remove(produit);

            return NoContent(); // 204

        }

        // on a deux paramètres qui sont extraits  par ASP.NEt à partir de l'url
        //categorieId et produitId
        // mappe les paramètres automatiquement. Routing par attribut
        // Get /api/produit/categorie/2/produit/3
        [HttpGet("categorie/{categorieId}/produit/{produitId}")]
        public IActionResult ObtenirProduitDansCategorie(int categorieId, int produitId)
        {
            return Ok(new { CategorieId = categorieId, produitId = produitId });
        }

        // on filtre avec un querystring
        // Get /api/produit/ListeFiltree?nom=ordinateur
        [HttpGet("ListeFiltree")]
        public IActionResult ObtenirListeFiltree([FromQuery] string? nom)
        {
            var resultat = _produits.AsEnumerable();

            //Si un nom est fourni, on filtre
            if (!string.IsNullOrEmpty(nom))
            {
                resultat = resultat.Where(p => ((dynamic)p).Nom.Contains(nom, StringComparison.OrdinalIgnoreCase));

            }

            return Ok(resultat);
        }

        // GET /api/produit/recherche?nom=ordinateur&prixMax=1500
        [HttpGet("recherche")]
        public IActionResult Rechercher([FromQuery] string? nom, [FromQuery] decimal? prixMax)
        {
            var resultat = _produits.AsEnumerable();

            //Si un nom est fourni, on filtre
            if (!string.IsNullOrEmpty(nom))
            {
                resultat = resultat.Where(p => ((dynamic)p).Nom.Contains(nom, StringComparison.OrdinalIgnoreCase));

            }

            if (prixMax.HasValue)
            {
                resultat = resultat.Where(p => ((dynamic)p).Prix <= prixMax);
            }

            return Ok(resultat);
        }



        /*
         **Schéma d'une requête POST :**

            ```
            POST /api/produits HTTP/1.1                    ← Ligne de requête (verbe + URL)
            Host: localhost:5000                           ← Header
            Content-Type: application/json                 ← Header (type du corps)
            Authorization: Bearer xyz123...                ← Header (optionnel, si auth)

            {                                              ← Body (corps, uniquement POST/PUT)
              "nom": "Souris Gaming",
              "prix": 79.99,
              "quantiteStock": 50
            }
            ```
         
         */
    }
}
