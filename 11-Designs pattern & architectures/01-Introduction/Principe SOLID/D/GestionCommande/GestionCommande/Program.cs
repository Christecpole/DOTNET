//using GestionCommande;
//using GestionCommande.Models;

//var service = new ServiceCommande();  // Constructeur vide, le service crée tout en interne
//var commande = new Commande { Id = 1, Client = "client@email.com", Montant = 150m };
//service.Traiter(commande);
//Console.WriteLine("Terminé.");

// On crée les implémentations (classes concrètes)
using GestionCommande;
using GestionCommande.Models;

var depot = new DepotCommandeFichier();
var journal = new JournalConsole();
var notification = new NotificationConsole();

// On les passe au service (injection de dépendances)
var service = new ServiceCommande(depot, notification, journal);

var commande = new Commande { Id = 1, Client = "client@email.com", Montant = 150m };
service.Traiter(commande);
Console.WriteLine("Terminé. Vérifiez le fichier commande_1.txt.");