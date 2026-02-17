using System.ComponentModel.DataAnnotations;

namespace TodoListApi.DTOs
{
    /// <summary>
    /// DTO pour creer un nouveau compte.
    /// </summary>
    public class RegisterDto
    {
        [Required(ErrorMessage = "Le nom d'utilisateur est obligatoire.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom d'utilisateur doit faire entre 3 et 50 caracteres.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit faire au moins 6 caracteres.")]
        public string Password { get; set; } = string.Empty;
    }
}
