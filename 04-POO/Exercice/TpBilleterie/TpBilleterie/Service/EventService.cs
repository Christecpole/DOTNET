using TpBilleterie.Classes;
using TpBilleterie.Exceptions;

namespace TpBilleterie.Service;

public class EventService
{
    private List<Event> events;

    public EventService()
    {
        events = new List<Event>();
    }

    public void AddEvent(Event newEvent)
    {
        events.Add(newEvent);
    }

    public void AddEvent(string eventName, Place place, DateTime eventDate, int numberOfPlaces)
    {
        events.Add(new Event(eventName, place, eventDate, numberOfPlaces));
    }

    public List<Event> GetAllEvents()
    {
        return events;
    }

    public bool DeleteEvent(int index)
    {
        try
        {
            events.RemoveAt(index);
            return true;
        }
        catch (IndexOutOfRangeException e)
        {
            throw new NotFoundException("Event not found");
        }
    }

    public Event GetEvent(int index)
    {
        try
        {
            return events[index];
        }
        catch (Exception e)
        {
            throw new NotFoundException("Event not found");
        }
    }

    public Event Update(int index,string eventName, Place place, DateTime eventDate, int numberOfPlaces)
    {
        try
        {
            Event eventFound = events[index];
            eventFound.EventName = eventName;
            eventFound.Place= place;
            eventFound.Date = eventDate;
            eventFound.NumberOfPlace = numberOfPlaces;

            return eventFound;
        }catch(IndexOutOfRangeException e)
        {
            throw new NotFoundException("Event not found");
        }
    }

    public bool EventStillHavePlace(int index)
    {
        Event eventFound = GetEvent(index);
        if (eventFound.NumberOfPlace <= eventFound.Billets.Count)
        {
            throw new EventFullException("Event is full");
        }

        return true;
    }
}