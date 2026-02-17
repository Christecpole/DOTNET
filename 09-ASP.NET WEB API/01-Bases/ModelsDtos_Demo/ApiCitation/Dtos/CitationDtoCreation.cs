using System.ComponentModel.DataAnnotations;

namespace ApiCitation.Dtos
{
    public class CitationDtoCreation
    {
        [Required(ErrorMessage = "L'auteur est obligatoire")]
        [StringLength(200, MinimumLength = 1)]
        public string Auteur { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le texte est obligatoire")]
        [StringLength(200, MinimumLength = 1)]
        public string Texte { get; set; } = string.Empty;
    }
}
