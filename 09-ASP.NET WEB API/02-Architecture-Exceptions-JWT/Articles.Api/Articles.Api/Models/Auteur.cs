namespace Articles.Api.Models
{
    public class Auteur
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;

        public List<Article> Articles { get; set; } = new();
    }
}
