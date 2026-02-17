using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewDemo.Models;

namespace ViewDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var message = 10;
            return View((object)message);
        }

        public IActionResult ifElse()
        {
            return View();
        }

        public IActionResult Foreach()
        {
            return View();
        }

        public IActionResult AvecModelSimple()
        {
            return View();
        }


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
