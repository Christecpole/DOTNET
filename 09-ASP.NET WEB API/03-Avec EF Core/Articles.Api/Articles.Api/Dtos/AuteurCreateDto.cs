using System.ComponentModel.DataAnnotations;

namespace Articles.Api.Dtos
{
    public class AuteurCreateDto
    {
        [Required]
        public string Nom { get; set; } = string.Empty;
        [Required]
        public string Prenom {  get; set; } = string.Empty;
    }
}
