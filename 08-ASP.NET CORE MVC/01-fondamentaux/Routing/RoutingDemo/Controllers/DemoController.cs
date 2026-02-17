using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Utiliser des tokens : mots clés remplaçable dynamiquement
    /// </summary>
    [Route("[controller]/[action]")] //URL : Demo/Index
    public class DemoController : Controller
    {
        [Route("test")]
        public IActionResult Index()
        {
            return Content("ça marche ! ");
        }

        //public IActionResult Test()
        //{

        //}
    }
}
