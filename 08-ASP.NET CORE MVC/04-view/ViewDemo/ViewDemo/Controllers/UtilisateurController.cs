using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ViewDemo.Models;

namespace ViewDemo.Controllers
{
    public class UtilisateurController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Affiche le formulaire vide avec la liste des pays
        [HttpGet]
        public IActionResult CreerUnUtilisateur()
        {

            ViewBag.pays = new List<SelectListItem>()
            {
                new SelectListItem{ Value = "FR", Text = "France" },
                new SelectListItem{ Value = "BE", Text = "Belgique" },
                new SelectListItem{ Value = "CA", Text = "Canada" },

            };

            return View(new Utilisateur());
        }
    }
}
