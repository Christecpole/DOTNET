namespace ModelsDtos_Demo.Dtos
{
    public class ProduitDtoListe
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public int QuantiteStock { get; set; }

        public string NomCategorie { get; set; } = string.Empty;
        public bool EstEnStock => QuantiteStock > 0;

        public string PrixFormate => Prix.ToString("C", new System.Globalization.CultureInfo("fr-FR"));
    }
}
