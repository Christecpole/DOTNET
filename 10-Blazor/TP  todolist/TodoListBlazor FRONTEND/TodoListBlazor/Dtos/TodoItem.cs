namespace TodoListBlazor.Dtos
{
    //Represente une tâche
    //correspond au modèle de l'api
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //date d'échéance
        public DateTime? DueDate { get; set; }
        public int Priority { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; }

        //propriétés calculés

        //Retourner le nom de la priorité
        public string PriorityName => Priority switch
        {
            1 => "Basse",
            2 => "Normale",
            3 => "Haute",
            _ => "Inconnue"
        };

        //Retourne la class css selon la priorité
        public string PriorityBadgeClass => Priority switch
        {
            1 => "badge bg-success",
            2 => "badge bg-warning",
            3 => "badge bg-danger",
            _ => "badge bg-secondary"
        };

        //Verifie si la todo est en retard
        public bool IsOverdue => DueDate.HasValue && DueDate.Value.Date < DateTime.Today && !IsCompleted;

        //Retourne la date formatée
        public string FormattedDueDate => DueDate?.ToString("dd/MM/yyy") ?? "Pas de date";

    }
}
