using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApi.Models
{
    /// <summary>
    /// Represente une tache dans notre TodoList.
    /// C'est la structure complete stockee en base de donnees.
    /// </summary>
    [Table("todos")]  // Nom de la table dans MySQL
    public class TodoItem
    {
        /// <summary>
        /// Identifiant unique (clé primaire auto-incrémentée)
        /// </summary>
        [Key]  // Clé primaire
        [Column("id")]  // Nom de la colonne
        public int Id { get; set; }

        /// <summary>
        /// Titre de la tâche (obligatoire, max 100 caractères)
        /// </summary>
        [Required]  // NOT NULL en base
        [MaxLength(100)]  // VARCHAR(100)
        [Column("title")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description détaillée (optionnelle)
        /// </summary>
        [MaxLength(500)]  // VARCHAR(500)
        [Column("description")]
        public string? Description { get; set; }

        /// <summary>
        /// La tâche est-elle terminée ?
        /// </summary>
        [Column("is_completed")]
        public bool IsCompleted { get; set; } = false;

        /// <summary>
        /// Priorité de 1 (basse) à 5 (urgente)
        /// </summary>
        [Column("priority")]
        public int Priority { get; set; } = 3;

        /// <summary>
        /// Date limite pour terminer la tâche (optionnelle)
        /// </summary>
        [Column("due_date")]
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Date de création (automatique)
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }

}
