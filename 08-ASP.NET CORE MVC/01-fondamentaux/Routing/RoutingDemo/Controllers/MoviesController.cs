using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /*
     
     Créez un système de gestion de films avec routing par attributs (site MVC classique).

    **Critères de succès :**

    - [ ] `/films` → Liste tous les films
    - [ ] `/films/5` → Détail du film #5 (contrainte `:int`)
    - [ ] `/films/genre/action` → Films du genre (contrainte `:alpha`)
    - [ ] `/films/annee/2024` → Films de l'année (contrainte `:int:range(1900,2100)`)
    - [ ] `/films/abc` → 404 (contrainte `:int` échoue)

    Changer le nom du controller dans l'url : /films
     
    */

    [Route("films")]
    public class MoviesController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return Content("Liste tous les films");
        }

        [Route("{id:int}")]
        public IActionResult Details(int id)
        {
            return Content($"Details du film {id}");
        }

        [Route("genre/{genre:alpha}")]
        public IActionResult Genre(string genre)
        {
            return Content($"Film du genre : {genre}");
        }

        [Route("annee/{year:int:range(1900,2026)}")]
        public IActionResult range(int year)
        {
            return Content($"Films de l'année : {year}");
        }


    }
}
