namespace Articles.Api.Dtos
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Titre { get; set; } = string.Empty;
        public string Contenu {  get; set; } = string.Empty;
        public string NomAuteur {  get; set; }   = string.Empty;
    }
}
