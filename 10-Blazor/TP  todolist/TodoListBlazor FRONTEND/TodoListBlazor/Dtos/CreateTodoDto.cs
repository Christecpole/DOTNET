using System.ComponentModel.DataAnnotations;

namespace TodoListBlazor.Dtos
{
    // Pour créer une nouvelle tâche
    // Contient uniquement les champs que l'utilisateur peut remplir
    public class CreateTodoDto
    {
        [Required(ErrorMessage ="Le titre est obligatoire")]
        [StringLength(200, MinimumLength = 10, ErrorMessage="Le titre doit contenir entre 10 et 200 caractères.")]
        public string Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères.")]
        public string Description { get; set; } = string.Empty;
        [Range(1, 5, ErrorMessage ="La priorité doit être entre 1 (Basse) et 5 (Urgent).")]
        public int Priority { get; set; } = 2;// Par défault : Normal
        public DateTime? DueDate { get; set; }

    }
}
