
// Classe gestion de paiement

using CorrectionExoInterface.Classe;
using System.ComponentModel.DataAnnotations;

List<IPayement> MoyenDePaiements = new List<IPayement>();
MoyenDePaiements.Add(new CarteDeCredit("12312381", "Toto", DateTime.Now, "123", 2000));
MoyenDePaiements.Add(new CarteDeCredit("7891561", "titi", DateTime.Now, "356", 50000));
MoyenDePaiements.Add(new Paypal("158 rue des lillas", "email@email.com", "Pa$$word", 200));

foreach(var paiement in MoyenDePaiements)
{
    Console.WriteLine(paiement.EffectuerPaiement(new Random().Next(8000))); ;
}