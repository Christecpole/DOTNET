using System.Globalization;
using TpBilleterie.Classes;
using TpBilleterie.Exceptions;
using TpBilleterie.Service;

namespace TpBilleterie.Util;

public class Ihm
{
    private CustomerService _customerService;
    private EventService _eventService;
    private BilletService _billetService;

    public Ihm() {
        _customerService = new CustomerService();
        _eventService = new EventService();
        _billetService = new BilletService(_eventService,_customerService);
    }

    public void Start (){
        init();
        string? entry;
        while (true){
            afficheMenu();
            entry = Console.ReadLine();
            try{
                switch (entry){
                    case "1": addUser();
                        break;
                    case "2":addEvent();
                        break;
                    case "3": addBillet();
                        break;
                    case "4":
                        ShowBilletCustomer();
                        break;
                    case "5":
                        ShowBilletEvent();
                        break;
                    case "6":
                        ShowAll(_eventService.GetAllEvents());
                        break;
                    case "7":
                        ShowAll(_customerService.GetAllCustomers());
                        break;
                    default: 
                        return;
                }
            }catch (Exception ex){
                Console.WriteLine(ex.Message);
            }

        }


    }

    private void init (){

        var address = new Address("200 rue des lillas","lille");
        var place = new Place("rue de l'evenement","lille",800);

        var customer = new Customer("toto","tata",address,30,"01234567899");
        var customer2 = new Customer("titi","tutu",address,30,"01234567899");

        var events = new Event("Event1",place, DateTime.Now,400);

        _customerService.AddCustomer(customer);
        _customerService.AddCustomer(customer2);
        _eventService.AddEvent(events);
    }

        private void afficheMenu (){
        Console.WriteLine("""
                --- Menu  ---
                1/ Crée Customer
                2/ Crée un event
                3/ Création d'un billet
                4/ Afficher les billets d'un client
                5/ Afficher les billets d'un event
                6/ Afficher tout les Events
                7/ Afficher tout les clients
                """);
    }



    private void addBillet (){
        Console.WriteLine("--- ajout d'un billet ---");

        Console.WriteLine("index du client :");
        var indexClient = int.Parse(Console.ReadLine());

        Console.WriteLine("index de l'evenement :");
        var indexEvent = int.Parse(Console.ReadLine());

        Console.WriteLine("Type de la place Standard/ gold / vip");
        var typePlace = Console.ReadLine();
        PlaceType placeTYpe ;
        PlaceType.TryParse(typePlace, out placeTYpe);

        Billet billet = null;
        try{
            billet = _billetService.AddBillet(indexClient,indexEvent,placeTYpe);
        }catch (Exception e) when (e is NotFoundException | e is EventFullException ){
            Console.WriteLine(e.Message);
        }
        Console.WriteLine(billet);



    }

    private void addUser(){
        Console.WriteLine("--- ajout d'un Client ---");

        Console.WriteLine("Nom  :");
        var lastname = Console.ReadLine();

        Console.WriteLine("Prenom :");
        var firstname = Console.ReadLine();
        Console.WriteLine("Rue :");
        var street = Console.ReadLine();

        Console.WriteLine("Ville :");
        var city = Console.ReadLine();

        Console.WriteLine("Age :");
        var age = int.Parse(Console.ReadLine());

        Console.WriteLine("Telephone :");
        var phone = Console.ReadLine();

        _customerService.AddCustomer(firstname,lastname,new Address(street,city),age,phone);
        Console.WriteLine("Utilisateur crée");
    }
//
    private void addEvent()
    {
        Console.WriteLine("--- ajout d'un Evenement ---");

        Console.WriteLine("Nom de l'evenement  :");
        var eventName = Console.ReadLine();

        Console.WriteLine("Rue :");
        var street = Console.ReadLine();

        Console.WriteLine("Ville :");
        var city = Console.ReadLine();

        Console.WriteLine("Capacité max de la salle :");
        var capacity = int.Parse(Console.ReadLine());

        Console.WriteLine("Date et heure de l'evenement (dd-MM-yyyy hh:mm) ");
        var dateTime = Console.ReadLine();


        Console.WriteLine("Nombre de place :");
        var numberOfPlace = int.Parse(Console.ReadLine());

        DateTime date = DateTime.ParseExact(dateTime, "dd-MM-yyyyy HH:mm", CultureInfo.InvariantCulture);

        _eventService.AddEvent(eventName, new Place(street, city, capacity), date, numberOfPlace);
        Console.WriteLine("Event crée");
    }

    private void ShowBilletCustomer()
    {
        Console.WriteLine("Index du customer :");
        var index = int.Parse(Console.ReadLine());

        Console.WriteLine("Affichage des billet :");
        foreach (var billet  in _customerService.GetCustomer(index).Billets)
        {
            Console.WriteLine(billet);
        }
    }
    
    private void ShowBilletEvent()
    {
        Console.WriteLine("Index de l'event :");
        var index = int.Parse(Console.ReadLine());

        Console.WriteLine("Affichage des billet :");
        foreach (var billet  in _eventService.GetEvent(index).Billets)
        {
            Console.WriteLine(billet);
        }
    }

    private void ShowAll<T>(List<T> elements)
    {
        foreach (var element in elements)
        {
            Console.WriteLine(element); 
        }
    }
}