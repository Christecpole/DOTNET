using System.ComponentModel.DataAnnotations;

namespace ModelsDtos_Demo.Dtos
{
    //Ici on met les validations : nom est obligatoiren longueur prix correct 
    // Le controller vérifira avec ModelState.IsValid
    public class ProduitDtoCreation
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2)]
        public string Nom { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [Range(0.01, 999999.99)]
        public decimal Prix { get; set; }

        [Range(0, int.MaxValue)]
        public int QuantiteStock { get; set; }

        [Required(ErrorMessage = "La catégorie est obligatoire")]
        public int CategorieId { get; set; }
    }
}
