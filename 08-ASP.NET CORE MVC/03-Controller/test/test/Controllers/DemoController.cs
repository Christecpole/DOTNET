using Microsoft.AspNetCore.Mvc;

namespace test.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PageSimple()
        {
            return View();
        }

        public IActionResult TexteBrut()
        {
            return Content("Ceci est du texte brut, pas du HTML !");
        }

        public IActionResult DonneesJson()
        {
            // 📘 new { } = objet anonyme C# (pas besoin de créer une classe)
            var data = new
            {
                nom = "Formation ASP.NET",
                duree = 4,
                // 📘 new[] = tableau C#
                competences = new[] { "MVC", "Razor", "EF Core" }
            };
            return Json(data);
        }

            // 📘 RedirectToAction = redirection HTTP 302 vers une autre action
            public IActionResult Redirection()
            {
                // 📘 Redirige vers /Demo/PageSimple
                return RedirectToAction("PageSimple");
            }

            public IActionResult RedirectionAvecParametre()
            {
                // 📘 new { id = 42 } = paramètre de route
                // 📘 Génère : /Product/Details/42
                return RedirectToAction("Details", "Product", new { id = 42 });
            }


    }
}
