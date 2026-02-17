
//using CalculPrix.Models;
//using CalculPrix.Services;

//var service = new ServicePrix();
//var commande = new Commande { Montant = 100m, TypeClient = "Standard" };

//Console.WriteLine($"Prix : {service.CalculerPrix(commande)} euros"); // on affiche : 120 euros.

using CalculPrix.Contrats;
using CalculPrix.Models;
using CalculPrix.Services;
using CalculPrix.strategies;

var strategies = new Dictionary<string, IStrategieTarification>
{
    ["Standard"] = new TarificationStandard(),
    ["Vip"] = new TarificationVip(),
    ["Pro"] = new TarificationPro(),
    ["Premium"] = new TarificationPremium()
};

// on créé le service en lui passant le dictionnaire (injection des stratégies)
var service = new ServicePrix(strategies);

//Commande de test
var commande1 = new Commande { Montant = 100m, TypeClient = "Standard" };
var commande2 = new Commande { Montant = 100m, TypeClient = "Vip" };
var commande3 = new Commande { Montant = 100m, TypeClient = "Pro" };
var commande4 = new Commande { Montant = 100m, TypeClient = "Premium" };


//On affiche les résultats
Console.WriteLine($"Standard : {service.CalculerPrix(commande1)} euros");
Console.WriteLine($"Vip : {service.CalculerPrix(commande2)} euros");
Console.WriteLine($"Pro : {service.CalculerPrix(commande3)} euros");
Console.WriteLine($"Premium : {service.CalculerPrix(commande4)} euros");