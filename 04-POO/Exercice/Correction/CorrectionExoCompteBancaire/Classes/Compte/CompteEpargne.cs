using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCompteBancaire.Classes.Compte
{
    internal class CompteEpargne : CompteBancaire
    {

        public double TauxEpargne { get; set; }

        //Le mot clé base fait reference au constructeur de la classe CompteBanquaire et permet de lui renvoyer les valeur pour ses diferentes propriétées
        public CompteEpargne(double Solde, Client client, double tauxEpargne) : base(Solde, client)
        {
            TauxEpargne = tauxEpargne;
        }

        //implementation des methode abstraite de CompteBanquaire pour definire leurs fonctionement propre a chaque implementation de la classe CompteBanquaire
        public override void Depot(double montant)
        {
            Solde += montant;
            Operations.Add(new Operation(montant, Statut.Depot));
        }

        public override bool Retrait(double montant)
        {
            if (Solde < montant) return false;
            Solde -= montant;
            Operations.Add(new Operation(montant, Statut.Retrait));
            return true;
        }


        //les classe qui herite du classe abstraite peuvent aussi venir ajouter des methode qui leurs sont propre pour le fonctionement
        public double GetEpargne()
        {
            return Solde * TauxEpargne;
        }
    }
}
