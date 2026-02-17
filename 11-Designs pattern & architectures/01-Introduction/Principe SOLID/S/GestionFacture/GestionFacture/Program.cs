
//---------Version Mauvaise-----------
//using GestionFacture.Models;
//using GestionFacture.Services;

//var service = new ServiceFacture(); // on créé le service (constructeur vide)
//var facture = new Facture { Id = 1 , Client = "M2i", Montant = 100m}; //facture de test

//service.Enregistrer(facture); // on enregistre (validation + TVA + sauvegarde + notification)
//Console.WriteLine("Terminé");
//------------------------------------

using GestionFacture.Calcul;
using GestionFacture.Models;
using GestionFacture.Notification;
using GestionFacture.Persistance;
using GestionFacture.Services;
using GestionFacture.Validation;

// on créé chaque dépendance
var validateur = new ValidateurFacture(); 
var calculateurTva = new CalculateurTva();
var depot = new DepotFactureFichier();
var notification = new NotificationConsole();

//on les passe au service
var service = new ServiceFacture(validateur, calculateurTva, depot, notification);

var facture = new Facture { Id = 1, Client = "M2i formation", Montant = 250m };

//donner au service cette facture
service.Enregistrer(facture);

Console.WriteLine($"Terminé. Vérifiez le fichier facture_{facture.Id}.txt.");



