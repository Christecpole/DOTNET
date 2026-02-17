using System.ComponentModel.DataAnnotations;

namespace Articles.Api.Dtos
{
    public class ArticleUpdateDto
    {
        [Required]
        public string Titre { get; set; } = string.Empty;
        [Required]
        public string Contenu {  get; set; } = string.Empty;
    }
}
