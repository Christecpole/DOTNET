namespace ViewModels_en_details.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom {  get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public int CategorieId { get; set; }
        public Categorie? Categorie { get; set; }
    }
}
