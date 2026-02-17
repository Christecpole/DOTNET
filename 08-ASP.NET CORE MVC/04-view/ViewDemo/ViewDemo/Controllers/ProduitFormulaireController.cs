using Microsoft.AspNetCore.Mvc;
using ViewDemo.Models;

namespace ViewDemo.Controllers
{
    public class ProduitFormulaireController : Controller
    {
        private static List<Produit> _produits = new List<Produit>();

        private static int _nextID = 1;
        public IActionResult Index()
        {
            return View(_produits);
        }

        [HttpGet] //affiche le formulaire vide
        public IActionResult CreerProduit()
        {
            return View(new Produit()); //crée un produit vide pour le formulaire
        }

        [HttpPost]
        public IActionResult CreerProduit(Produit produitCree)
        {
            produitCree.Id = _nextID;
            _nextID++;

            _produits.Add(produitCree);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var produit = _produits.FirstOrDefault(i=>i.Id == id);

            return View(produit);
        }
    }
}
