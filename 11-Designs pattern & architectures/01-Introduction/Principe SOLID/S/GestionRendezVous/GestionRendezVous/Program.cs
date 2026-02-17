using GestionRendezVous.Models;
using GestionRendezVous.Persistance;
using GestionRendezVous.Rappel;
using GestionRendezVous.Services;
using GestionRendezVous.Validation;

var validateur = new ValidateurRendezVous();
var depot = new DepotRendezVousFichier();
var rappel = new RappelConsole();
var service = new ServiceRendezVous(validateur, depot, rappel);

var rdv = new RendezVous { Id = 1, Client = "dupont@email.com", DateHeure = DateTime.Now.AddDays(1) };

service.Enregistrer(rdv);
Console.WriteLine($"Terminé. vérifiez le fichier rendezvous_{rdv.Id}.txt");

