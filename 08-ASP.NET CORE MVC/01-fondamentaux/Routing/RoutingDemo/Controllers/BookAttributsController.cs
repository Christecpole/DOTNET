using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    //Routing par attribut
    [Route("BooksAttributs")]
    public class BookAttributsController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return Content("Liste de books dans index.");
        }

        [Route("Details/{id}")]
        public IActionResult Details(int id)
        {
            return Content("Nous sommes dans le details de bookattributs grâce au routing par attributs");
        }

        //URL : BooksAttributs/categorie/fantasy
        [Route("categorie/{categoryName}")]
        public IActionResult Category(string categoryName)
        {
            return Content($"Livres de la catégorie : {categoryName}");
        }


    }
}
