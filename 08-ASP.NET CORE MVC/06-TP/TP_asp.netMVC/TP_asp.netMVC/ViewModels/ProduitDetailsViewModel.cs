namespace TP_asp.netMVC.ViewModels
{
    public class ProduitDetailsViewModel
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Prix { get; set; }

        public int QuantiteStock { get; set; }

        public DateTime DateCreation { get; set; }

        public int CategorieId { get; set; }

        public string NomCategorie { get; set; } = string.Empty;

        public bool EstEnStock => QuantiteStock > 0;

        public string PrixFormate => Prix.ToString("C", new System.Globalization.CultureInfo("fr-FR"));

        public string DisponibiliteMessage
        {
            get
            {
                if (QuantiteStock == 0) return "Rupture de stock";
                if (QuantiteStock < 5) return $"Plus que {QuantiteStock} en stock !";
                return "En stock";
            }
        }

        public string DisponibiliteCssClass
        {
            get
            {
                if (QuantiteStock == 0) return "text-danger";
                if (QuantiteStock < 5) return "text-warning";
                return "text-success";
            }
        }
    }
}
