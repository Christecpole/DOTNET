using TP_asp.netMVC.Models;
using TP_asp.netMVC.ViewModels;

namespace TP_asp.netMVC.Extensions
{
    public static class ProduitMappingExtensions
    {
        public static ProduitFormViewModel ToFormViewModel(this Produit produit)
        {
            return new ProduitFormViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                CategorieId = produit.CategorieId
            };
        }

        public static Produit ToModel(this ProduitFormViewModel viewModel)
        {
            return new Produit
            {
                Id = viewModel.Id ?? 0,
                Nom = viewModel.Nom,
                Description = viewModel.Description,
                Prix = viewModel.Prix,
                QuantiteStock = viewModel.QuantiteStock,
                CategorieId = viewModel.CategorieId
            };
        }

        public static ProduitDetailsViewModel ToDetails(this Produit produit)
        {
            return new ProduitDetailsViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                DateCreation = produit.DateCreation,
                CategorieId = produit.CategorieId,
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };
        }

        public static ProduitListItemViewModel ToListItem(this Produit produit)
        {
            return new ProduitListItemViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };
        }
    }
}
