using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCompteBancaire.Classes.Compte
{
    internal class ComptePayant : CompteBancaire
    {
        public double CoutOperation { get; set; }

        //Le mot clé base fait reference au constructeur de la classe CompteBanquaire et permet de lui renvoyer les valeur pour ses diferentes propriétées
        public ComptePayant(double Solde, Client client, double coutOperation) : base(Solde, client)
        {
            CoutOperation = coutOperation;
        }


        //implementation des methode abstraite de CompteBanquaire pour definire leurs fonctionement propre a chaque implementation de la classe CompteBanquaire
        public override void Depot(double montant)
        {
            if ((Solde + montant) < CoutOperation) return;
            Solde += montant - CoutOperation;
            Operations.Add(new Operation(montant - CoutOperation, Statut.Depot));
        }

        public override bool Retrait(double montant)
        {
            if (Solde < (montant + CoutOperation)) return false;
            Solde -= montant + CoutOperation;
            Operations.Add(new Operation(montant + CoutOperation, Statut.Retrait));
            return true;
        }
    }
}
