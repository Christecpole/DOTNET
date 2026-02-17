namespace Articles.Api.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Contenu { get; set; } = string.Empty;
        public int AuteurId { get; set; }
        public Auteur? Auteur { get; set; }
    }
}
