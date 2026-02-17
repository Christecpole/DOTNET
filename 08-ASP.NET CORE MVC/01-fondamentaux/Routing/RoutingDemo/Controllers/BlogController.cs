using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return Content("Liste des articles du blog");
        }

        // Appelé par la route personnalisée
        // URL : `https://localhost:5001/blog/2024/06/mon-article`
        public IActionResult RecupererUnSeulArticleAvecFiltres(int year, int month, string slug)
        {
            return Content($"Article : {slug}, (publié en {month}/{year}");
        }
    }
}
