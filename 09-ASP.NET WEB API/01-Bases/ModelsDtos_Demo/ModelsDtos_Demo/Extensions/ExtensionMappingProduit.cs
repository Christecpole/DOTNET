using ModelsDtos_Demo.Dtos;
using ModelsDtos_Demo.Models;

namespace ModelsDtos_Demo.Extensions
{
    public static class ExtensionMappingProduit
    {
        // Model → DTO liste : on appelle produit.VersDtoListe()
        public static ProduitDtoListe VersDtoListe(this Produit produit)
        {
            return new ProduitDtoListe
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };
        }

        // DTO création → Model 
        public static Produit VersModele(this ProduitDtoCreation dto)
        {
            return new Produit
            {
                Nom = dto.Nom,
                Description = dto.Description,
                Prix = dto.Prix,
                QuantiteStock = dto.QuantiteStock,
                CategorieId = dto.CategorieId
            };
        }
    }
}
