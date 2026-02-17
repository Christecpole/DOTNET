namespace ModelDemo.Models
{
    public class Cours
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;

        //propriété de navigation vers les étudiants
        public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();
    }
}
