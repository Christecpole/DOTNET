using TpBilleterie.Util;

namespace TpBilleterie.Classes;

public class Billet
{
    public int PlaceNumber { get; set; }
    public Customer Customer { get; set; } 
    public Event Event { get; set; }
    public PlaceType PlaceType { get; set; }

    public Billet(int placeNumber, Customer customer, Event events, PlaceType placeType)
    {
        PlaceNumber = placeNumber;
        Customer = customer;
        Event = events;
        PlaceType = placeType;
    }

    public override string ToString()
    {
        return $"Billet : {PlaceNumber} {Customer} {Event} {PlaceType}";
    }
}