namespace TodoListApi.Models
{
    /// <summary>
    /// Represente une tache dans notre TodoList.
    /// C'est la structure complete stockee en base de donnees.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Identifiant unique de la tache (genere automatiquement)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Titre de la tache (ex: "Faire les courses")
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Description detaillee (optionnelle)
        /// Ex: "Acheter du lait, du pain et des oeufs"
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// La tache est-elle terminee ?
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        /// <summary>
        /// Priorite de 1 (basse) a 5 (urgente)
        /// Par defaut : 3 (normale)
        /// </summary>
        public int Priority { get; set; } = 3;

        /// <summary>
        /// Date limite pour terminer la tache (optionnelle)
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Date de creation de la tache (automatique)
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
