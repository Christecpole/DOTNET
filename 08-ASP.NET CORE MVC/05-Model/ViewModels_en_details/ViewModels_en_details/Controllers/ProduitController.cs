using Microsoft.AspNetCore.Mvc;
using ViewModels_en_details.Models;
using ViewModels_en_details.ViewModel;

namespace ViewModels_en_details.Controllers
{
    public class ProduitController : Controller
    {
        private static List<Produit> _produits = new()
        {
            new Produit
            {
                Id=1,
                Nom="Ordi",
                Prix=120.50m,
                Stock=10,
                CategorieId=1,
                Categorie= new Categorie{CategorieId=1, Nom=""}
            }
        };

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Details(int id)
        {
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            if(produit == null)
            {
                return NotFound();
            }

            var viewmodel = new ProduitDetailsViewModel
            {
                Nom = produit.Nom,
                Stock = produit.Stock,
                PrixFormatte = produit.Prix.ToString("C"),
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };

            return View(viewmodel);
        }
    }
}
