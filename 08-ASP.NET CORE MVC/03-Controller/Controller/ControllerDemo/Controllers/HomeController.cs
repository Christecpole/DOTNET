using System.Diagnostics;
using ControllerDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllerDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

        public IActionResult GetDataJson()
        {
            var data = new { nom = "Produit", prix = 10 };

            //Json() permet de convertir l'objet c# en json 
            //résultat :  { "nom":"Produit", "prix":10 }
            return Json(data);
        }

        public IActionResult GetXML()
        {
            var xml = "<root><message>Hello></message></root>";
            return Content(xml, "application/xml");
        }

        public IActionResult DetailsNotFound(int id)
        {
            //Simule une verification
            if(id <= 0)
            {
                return NotFound(); // 404
            }

            return View();
        }

        //La requete est invalide
        public IActionResult CreateWithBadRequest(string nom)
        {
            if (string.IsNullOrEmpty(nom))
            {
                return BadRequest("Le nom est requis");
            }

            return View();
        }

        //L'utilisateur n'est pas connecté
        public IActionResult CreateUtilisateurNonConnecte()
        {
            //simuler une verification d'authenfication
            bool estConnecte = false;
            if (!estConnecte)
            {
                return Unauthorized(); // 401
            }
            return View();
        }

        //utilisateur connecté mais pas de droit
        public IActionResult SeulementLesAdmin()
        {
            //SImuler une verification
            bool estAdmin = false;
            if (!estAdmin) 
            {
                return Forbid(); // 403
            }

            return View();
        }

        public IActionResult GetTexteContent()
        {
            return Content("contenu texte");
        }

        // Rediririger vers l'action index du même controller
        public IActionResult Create()
        {
            //traitement
            return RedirectToAction("Index");
        }

        //Rediriger vers un autre controller
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        //Rediriger avec des paramètres
        public IActionResult CreateAvecRedirect()
        {
            // gènere /Produit/Details/5
            return RedirectToAction("Details", new { id = 5 });
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



        /*
         
         ## Tableau récapitulatif

            | Méthode | Code HTTP | Usage |
            |---------|-----------|-------|
            | `View()` | 200 | Retourner une page HTML |
            | `Json()` | 200 | Retourner des données JSON |
            | `Content()` | 200 | Retourner du texte brut |
            | `RedirectToAction()` | 302 | Redirection vers une autre action |
            | `BadRequest()` | 400 | Requête invalide |
            | `Unauthorized()` | 401 | Non authentifié |
            | `Forbid()` | 403 | Non autorisé |
            | `NotFound()` | 404 | Ressource inexistante |

---
         
         */
    }
}
