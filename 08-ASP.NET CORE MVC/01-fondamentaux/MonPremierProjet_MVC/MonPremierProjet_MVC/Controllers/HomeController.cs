using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MonPremierProjet_MVC.Models;

namespace MonPremierProjet_MVC.Controllers
{

    public class HomeController : Controller
    {
        //Action : Affiche moi la page d'accueil
        // home/index
        public IActionResult Index()
        {
            return View(); // retourne moi la vue correspondante à ce controller
        }

        // home/privacy
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
