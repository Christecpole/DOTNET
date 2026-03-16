namespace ReservationService.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int VoyageId { get; set; }
        public string NomClient { get; set; }
        public int NombrePlaces { get; set; }
    }
}
