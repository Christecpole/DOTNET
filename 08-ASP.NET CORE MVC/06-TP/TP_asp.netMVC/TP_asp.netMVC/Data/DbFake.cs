using TP_asp.netMVC.Models;

namespace TP_asp.netMVC.Data
{
    public static class DbFake
    {
        private static readonly List<Categorie> _categories = new()
        {
            new() { Id = 1, Nom = "Informatique" },
            new() { Id = 2, Nom = "Accessoires" },
            new() { Id = 3, Nom = "Périphériques" }
        };

        private static readonly List<Produit> _produits = new()
        {
            new()
            {
                Id = 1,
                Nom = "Laptop Pro",
                Description = "Ordinateur portable haute performance avec processeur Intel i7 et 16 Go de RAM",
                Prix = 1299.99m,
                QuantiteStock = 15,
                DateCreation = DateTime.UtcNow.AddDays(-30),
                CategorieId = 1,
                Categorie = _categories[0]
            },
            new()
            {
                Id = 2,
                Nom = "Souris Gaming",
                Description = "Souris optique avec capteur haute précision, 7 boutons programmables",
                Prix = 79.99m,
                QuantiteStock = 50,
                DateCreation = DateTime.UtcNow.AddDays(-15),
                CategorieId = 2,
                Categorie = _categories[1]
            },
            new()
            {
                Id = 3,
                Nom = "Clavier Mécanique",
                Description = "Clavier mécanique avec switches Cherry MX Blue, rétroéclairage RGB",
                Prix = 149.99m,
                QuantiteStock = 0,
                DateCreation = DateTime.UtcNow.AddDays(-60),
                CategorieId = 2,
                Categorie = _categories[1]
            },
            new()
            {
                Id = 4,
                Nom = "Écran 27\"",
                Description = "Écran 4K Ultra HD, 144 Hz, HDR10, temps de réponse 1ms",
                Prix = 399.99m,
                QuantiteStock = 3,
                DateCreation = DateTime.UtcNow.AddDays(-7),
                CategorieId = 3,
                Categorie = _categories[2]
            }
        };

        public static IReadOnlyList<Categorie> Categories => _categories.AsReadOnly();

        public static List<Produit> Produits => _produits;
    }
}
