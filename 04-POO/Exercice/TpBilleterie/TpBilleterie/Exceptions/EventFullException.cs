namespace TpBilleterie.Exceptions;

public class EventFullException :Exception
{
    public EventFullException(string message):base(message)
    {
    }
}