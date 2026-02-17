using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    // Routing conventionnel
    public class ProductController : Controller
    {
       
        // URL : Product/Index - Product/
        public IActionResult Index()
        {
            return Content("Liste de tous les produits");
        }

        // URL : Product/RecupererUnProduit/5
        public IActionResult RecupererUnProduit(int id)
        {
            return Content($"voici le produit avec l'id #{id}");
        }

        // URL : Product/Categorie/id
        public IActionResult Categorie(string id)
        {
            return Content($"Produits de la categorie : {id}");
        }

        // URL : Product/Search?nom=ordinateur
        public IActionResult Search(string nom)
        {
            return Content($"Recherche : {nom}");
        }

        // URL : Product/SearchAvecId/1?prix=1000
        public IActionResult SearchAvecId(int id, decimal? prix) 
        {
            var message = $"Recherche du produit : {id}";

            if (prix.HasValue)
            {
                message += $"(max {prix}euro)";
            }

            return Content(message);
        }
         /*
             Routing basé sur les segments
                Segment : /Product/Search
                Pattern : {controller}/{Action}/{id?}
                Resultat : controller = Product Action = Search id = 1

            Routing basé sur le principe de Model Binding (basé sur les query string)
            Query string = ?prix=1000
            Passe la valeur de prix dans le paramètre de la methode d'action qui a le meme nom prix
         */


        //URL : Product/Details/5?format=json&includeReview=true
        public IActionResult Details(int id, string format, bool includeReview)
        {
            return Content($"Produit {id}, format: {format}, reviews : {includeReview}");
        }


        /*-----Route personnalisée
        
        Route générique celle par defaut
        Route specifique à un besoin avec des contraintes par exemple 

        Route specifique doit toujours se placer avant la route par defaut
        
        ---*/
    }
}
