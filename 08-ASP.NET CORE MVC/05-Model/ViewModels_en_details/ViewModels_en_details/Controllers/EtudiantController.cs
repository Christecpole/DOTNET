using Microsoft.AspNetCore.Mvc;
using ViewModels_en_details.Models;
using ViewModels_en_details.ViewModel;

namespace ViewModels_en_details.Controllers
{
    public class EtudiantController : Controller
    {
        private static List<Etudiant> _etudiants = new List<Etudiant>
        {
            new Etudiant
            {
                Id=1,
                Name = "Jean",
                Prenom="Truc",
                Address="123 rue de lille",
                DateDinscription=new DateTime(2020,5,15),
                BirthDate=new DateTime(2000,9,1),
                Email= "jean@mail.com",
                NumberPhone="06020300501",
                Note="Etudiants sérieux, quelques absences justifiées.",
                ClasseId=1,
                Classe = new Classe { ClasseId = 1, ClasseName="L3 Informatique" },


            }
        };
        public IActionResult Index()
        {
            var etudiantsViewmodels = _etudiants.Select(s => new EtudiantListeViewModel
            {
                Id = s.Id,
                NomComplet = $"{s.Name} {s.Prenom}",
                Email = s.Email,
                NomDeLaClasse = s.Classe?.ClasseName ?? "Sans Classe",
                Age = CalculDeLage(s.BirthDate)
            });
            return View(etudiantsViewmodels);
        }





        private int CalculDeLage(DateTime dateNaissance)
        {
            var aujourdhui = DateTime.Now;
            var age = aujourdhui.Year - dateNaissance.Year;
            //vérifie si l'anniversaire n'a pas encore eu lieu cette année.
            if (dateNaissance.Date > aujourdhui.AddYears(-age)) age--;
            return age;

        }
    }
}
