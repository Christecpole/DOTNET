using System.ComponentModel.DataAnnotations;

namespace TodoListApi.DTOs
{
    /// <summary>
    /// DTO pour MODIFIER une tache existante.
    /// Permet de changer tous les champs modifiables.
    /// </summary>
    public class TodoItemUpdateDto
    {
        [Required(ErrorMessage = "Le titre est obligatoire.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Le titre doit faire entre 1 et 100 caracteres.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La description ne peut pas depasser 500 caracteres.")]
        public string? Description { get; set; }

        /// <summary>
        /// Permet de marquer la tache comme terminee ou non
        /// </summary>
        public bool IsCompleted { get; set; }

        [Range(1, 5, ErrorMessage = "La priorite doit etre entre 1 et 5.")]
        public int Priority { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
