namespace MonPremierProjet_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        // Règle : métier : Le produit est disponible si le stock > 0
        public bool IsAvailable => Stock > 0;
    }
}
