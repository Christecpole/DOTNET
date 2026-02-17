using System.ComponentModel.DataAnnotations;

namespace TodoListApi.DTOs
{
    /// <summary>
    /// DTO pour CREER une nouvelle tache.
    /// Le client envoie seulement ces champs.
    /// </summary>
    public class TodoItemCreateDto
    {
        /// <summary>
        /// Titre obligatoire, entre 1 et 100 caracteres
        /// </summary>
        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Le titre doit faire entre 1 et 100 caracteres.")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description optionnelle, max 500 caracteres
        /// </summary>
        [StringLength(500, ErrorMessage = "La description ne peut pas depasser 500 caracteres.")]
        public string? Description { get; set; }

        /// <summary>
        /// Priorite entre 1 et 5
        /// </summary>
        [Range(1, 5, ErrorMessage = "La priorite doit etre entre 1 et 5.")]
        public int Priority { get; set; } = 3;

        /// <summary>
        /// Date d'echeance (optionnelle)
        /// </summary>
        public DateTime? DueDate { get; set; }
    }
}
