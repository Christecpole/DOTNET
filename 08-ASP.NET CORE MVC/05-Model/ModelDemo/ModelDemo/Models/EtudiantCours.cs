namespace ModelDemo.Models
{
    //Entité de jointure.
    public class EtudiantCours
    {
        public int Id { get; set; }

        public int EtudiantId { get; set; }
        public Etudiant Etudiant { get; set; } = new Etudiant();

        public int CoursId { get; set; }
        public Cours Cours { get; set; } = new Cours();
    }
}
