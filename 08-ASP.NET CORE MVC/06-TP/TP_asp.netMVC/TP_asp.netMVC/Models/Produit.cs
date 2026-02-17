using System.ComponentModel.DataAnnotations.Schema;

namespace TP_asp.netMVC.Models
{
    public class Produit
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Prix { get; set; }

        public int QuantiteStock { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        public int CategorieId { get; set; }

        public Categorie? Categorie { get; set; }

        [NotMapped]
        public bool EstEnStock => QuantiteStock > 0;
    }
}
