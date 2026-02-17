using Microsoft.AspNetCore.Mvc;
using ViewExercice.Models;

namespace ViewExercice.Controllers
{
    public class EtudiantController : Controller
    {
        public IActionResult Index()
        {
            var etudiants = new List<Etudiant>
            {

                new Etudiant { Id = 1, Prenom = "Marie", Nom = "Dupont", Note = 15.5m },
                new Etudiant { Id = 2, Prenom = "Jean", Nom = "Martin", Note = 12.0m },
                new Etudiant { Id = 3, Prenom = "Sophie", Nom = "Bernard", Note = 8.5m },
                new Etudiant { Id = 4, Prenom = "Pierre", Nom = "Leroy", Note = 18.0m },
                new Etudiant { Id = 5, Prenom = "Emma", Nom = "Petit", Note = 14.5m }
            };

            return View(etudiants);
        }
    }
}
