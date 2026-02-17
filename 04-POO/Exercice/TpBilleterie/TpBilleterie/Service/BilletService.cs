using TpBilleterie.Classes;
using TpBilleterie.Util;

namespace TpBilleterie.Service;

public class BilletService
{
    private EventService _eventService;
    private CustomerService _customerService;

    public BilletService(EventService eventService, CustomerService customerService)
    {
        _eventService = eventService;
        _customerService = customerService;
    }

    public Billet AddBillet(int idCUstomer, int idEvent, PlaceType placeType)
    {
        _eventService.EventStillHavePlace(idEvent);

        Customer customer = _customerService.GetCustomer(idCUstomer);
        Event eventFound = _eventService.GetEvent(idEvent);

        Billet billet = new Billet(eventFound.Billets.Count + 1,customer,eventFound,placeType);
        
        eventFound.AddBillet(billet);
        customer.AddBillet(billet);

        return billet;
    }
    
    public List<Billet> GetCustomerBillet(int idCustomer)
    {
        return _customerService.GetCustomer(idCustomer).Billets;
    }
    
    public List<Billet> GetEventBillet(int idEvent)
    {
        return _eventService.GetEvent(idEvent).Billets;
    }
}