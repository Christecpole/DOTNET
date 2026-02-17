using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Créer plusieurs Urls pour une seule action
    /// </summary>
    [Route("shop")]
    public class ShopController : Controller
    {
        [Route("")]
        [Route("produits")]
        [Route("catalogue")]
        public IActionResult Index()
        {
            return Content("Bienvenue dans la boutique !");
        }

        [Route("product/{id}")]
        [Route("item/{id}")]
        public IActionResult Details(int id)
        {

            return Content($"Produit {id}");
        }
    }
}
