using Microsoft.AspNetCore.Mvc;
using ModelDemo.Models;
using ModelDemo.Viewmodel;

namespace ModelDemo.Controllers
{
    public class EtudiantController : Controller
    {
        public static List<Etudiant> _etudiants = new List<Etudiant>
        {
            new Etudiant {Id =1, Nom="Guiren", Prenom="Oussama", DateNaissance=new DateTime(1987,07,21), Age=38},
        };
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Inscription()
        {
            return View(new EtudiantInscriptionViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // protection CSRF Verifie que le formulaire vient bien de notre site
        public IActionResult Inscription(EtudiantInscriptionViewModel etudiantCree)
        {
            //Si toutes les datas annotations ne sont pas satisfaites
            if (!ModelState.IsValid)
            {
                //retourne dans le formulaire avec les données créés
                //les tags helpers afficheront automatiquement les messages d'erreurs
                return View(etudiantCree);
            }

            //Ajouter dans la base de données

            TempData["Success"] = "Inscription réussie ! Bienvenue !";

            //redirige vers une autre action 
            return RedirectToAction("Index");

        }
    }
}
