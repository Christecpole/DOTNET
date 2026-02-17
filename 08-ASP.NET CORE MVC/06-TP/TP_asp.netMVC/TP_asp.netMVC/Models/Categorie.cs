namespace TP_asp.netMVC.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string? Description { get; set; }

        public List<Produit> Produits { get; set; } = new List<Produit>();
    }
}
