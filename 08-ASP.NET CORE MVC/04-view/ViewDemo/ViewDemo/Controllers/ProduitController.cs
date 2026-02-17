using Microsoft.AspNetCore.Mvc;
using ViewDemo.Models;

namespace ViewDemo.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Nos Produits";
            //var produit = new Produit()
            //{
            //    Id = 1,
            //    Nom = "Ordinateur",
            //    Prix = 1299.99m,
            //    Stock = 0
            //};
            var produits = new List<Produit>
            {
                new Produit
                {
                    Id=1,
                    Nom = "Ordinateur",
                    Prix = 500.25m,
                    Stock = 10
                },
                new Produit
                {
                    Id=2,
                    Nom = "Clavier",
                    Prix = 15.25m,
                    Stock = 5
                },
                new Produit
                {
                    Id=3,
                    Nom = "Souris",
                    Prix = 25.25m,
                    Stock = 50
                }
            };

            return View(produits);
        }

        public IActionResult Details() 
        {
            return Content("Page de détails");

        }

        public IActionResult DetailsAvecParametre(int id)
        {
            return Content($"Page de détails du produit {id}");

        }

        public IActionResult Liste(string categorie, string sort)
        {
            return Content($"Page liste produits electroniques");

        }
    }
}
