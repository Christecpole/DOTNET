using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsDtos_Demo.Dtos;
using ModelsDtos_Demo.Extensions;
using ModelsDtos_Demo.Models;

namespace ModelsDtos_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        // Données en mémoire pour la démo (plus tard : base de données)
        private static readonly List<Categorie> _categories = new()
        {
            new() { Id = 1, Nom = "Informatique" },
            new() { Id = 2, Nom = "Accessoires" }
        };

        private static readonly List<Produit> _produits = new()
        {
            new() { Id = 1, Nom = "Laptop Pro", Prix = 1299.99m, QuantiteStock = 15, DateCreation = DateTime.UtcNow, CategorieId = 1, Categorie = _categories[0] },
            new() { Id = 2, Nom = "Souris Gaming", Prix = 79.99m, QuantiteStock = 0, DateCreation = DateTime.UtcNow, CategorieId = 2, Categorie = _categories[1] }
        };

        [HttpGet]
        public ActionResult<List<ProduitDtoListe>> ObtenirListe()
        {
            var dtos = _produits.Select(produit => produit.VersDtoListe()).ToList();
            return Ok(dtos);
        }

    }
}
