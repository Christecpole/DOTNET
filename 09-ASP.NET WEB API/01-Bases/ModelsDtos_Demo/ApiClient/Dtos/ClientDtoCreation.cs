using System.ComponentModel.DataAnnotations;

namespace ApiClient.Dtos
{
    public class ClientDtoCreation
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2)]
        public string Nom { get; set; } = string.Empty;

        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; } = string.Empty;

        public DateTime? DateInscription { get; set; }
    }
}
