using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TP_asp.netMVC.ViewModels
{
    public class ProduitFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Nom du produit")]
        public string Nom { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 999999.99)]
        [Display(Name = "Prix (€)")]
        [DataType(DataType.Currency)]
        public decimal Prix { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Quantité en stock")]
        public int QuantiteStock { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une catégorie")]
        [Display(Name = "Catégorie")]
        public int CategorieId { get; set; }

        public SelectList? CategoriesSelectList { get; set; }

        public bool EstEdition => Id.HasValue;

        public string TitreFormulaire => EstEdition ? "Modifier le produit" : "Nouveau produit";
    }
}
