namespace TodoListApi.DTOs
{
    /// <summary>
    /// DTO pour AFFICHER une tache au client.
    /// Contient toutes les infos qu'on veut montrer.
    /// </summary>
    public class TodoItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public int Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Propriete calculee : la tache est-elle en retard ?
        /// </summary>
        public bool IsOverdue => DueDate.HasValue && DueDate.Value < DateTime.Now && !IsCompleted;
    }
}
