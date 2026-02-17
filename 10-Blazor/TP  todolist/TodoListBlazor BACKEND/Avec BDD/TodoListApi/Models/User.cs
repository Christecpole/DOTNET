using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApi.Models
{
    /// <summary>
    /// Représente un utilisateur de l'application.
    /// </summary>
    [Table("users")]  // Nom de la table dans MySQL
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        /// <summary>
        /// Nom d'utilisateur unique
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column("username")]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Mot de passe HASHÉ (jamais en clair !)
        /// </summary>
        [Required]
        [MaxLength(255)]  // Les hash BCrypt font ~60 caractères, on prend de la marge
        [Column("password_hash")]
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Date de création du compte
        /// </summary>
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<TodoItem> TodoItems { get; set; } = new();
    }
}
