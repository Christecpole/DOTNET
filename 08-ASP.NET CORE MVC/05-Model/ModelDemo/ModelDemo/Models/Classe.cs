namespace ModelDemo.Models
{
    public class Classe
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        //propriété de navigation : liste d'étudiants de cette classe
        public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();


    }
}
