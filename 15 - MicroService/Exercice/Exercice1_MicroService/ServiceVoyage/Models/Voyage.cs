namespace ServiceVoyage.Models
{
    public class Voyage
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public DateOnly DateDepart {  get; set; }
        public double Prix {  get; set; }
    }
}
