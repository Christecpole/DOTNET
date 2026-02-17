using TpBilleterie.Util;

namespace TpBilleterie.Classes;

public class Event
{
    public string EventName { get; set; }
    public Place Place { get; set; }
    public DateTime Date { get; set; }
    public int NumberOfPlace { get; set; }
    public List<Billet> Billets { get; set; }

    public Event(string eventName, Place place, DateTime date, int numberOfPlace)
    {
        EventName = eventName;
        Place = place;
        Date = date;
        NumberOfPlace = numberOfPlace;
        Billets = new List<Billet>();
    }

    public void AddBillet(Billet billet)
    {
        Billets.Add(billet);
    }

    public override string ToString()
    {
       return $"Event : {EventName}, Place: {Place}, Date: {Date}, NumberOfPlace: {NumberOfPlace}";
    }
}