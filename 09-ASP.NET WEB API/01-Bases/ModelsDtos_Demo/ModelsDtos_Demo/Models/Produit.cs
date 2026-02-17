namespace ModelsDtos_Demo.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        // 📘 Id de la catégorie du produit
        public int CategorieId { get; set; }
        // 📘 Référence vers la catégorie (pour afficher son nom)
        public Categorie? Categorie { get; set; }
        // 📘 Calculé : true si stock > 0 (pas stocké en base)
        public bool EstEnStock => QuantiteStock > 0;
    }
}
