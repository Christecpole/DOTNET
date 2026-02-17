namespace TodoListApi.Models
{
    /// <summary>
    /// Represente un utilisateur de l'application.
    /// </summary>
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// Nom d'utilisateur unique
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Mot de passe HASHE (jamais en clair !)
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Date de creation du compte
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
