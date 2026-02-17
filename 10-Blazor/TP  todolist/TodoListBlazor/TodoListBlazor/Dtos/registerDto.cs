using System.ComponentModel.DataAnnotations;

namespace TodoListBlazor.Dtos
{
    //Dto pour l'inscription - Envoyé à POST api/auth/register
    public class registerDto
    {
        [Required(ErrorMessage ="Le nom est obligatoire")]
        [MinLength(2,ErrorMessage ="Le nom d'utilisateur doit contenir au moins 2 caractères.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le password est obligatoire")]
        [MinLength(6, ErrorMessage = "Le password doit contenir au moins 6 caractères.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "La confirmation du password est obligatoire")]
        [Compare("Password", ErrorMessage ="Les mots de passes ne correspondent pas.")]
        public string ConfirmPassword { get; set; } =string.Empty;
    }
}
