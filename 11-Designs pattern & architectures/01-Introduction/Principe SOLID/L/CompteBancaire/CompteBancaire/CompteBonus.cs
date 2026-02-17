using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    internal class CompteBonus : Compte
    {
        private const decimal TauxBonus = 0.01m;
        public CompteBonus(decimal soldeInitial) { Solde = soldeInitial; }

        //public override void Retirer(decimal montant)
        //{
        //    Solde += montant; //Viole le LSP : le code retirer(100) s'attend à un solde qui diminue.
        //}

        public override void Retirer(decimal montant)
        {
            if (montant > Solde)
                throw new InvalidOperationException("Solde est insuffisant");
            //retire : le solde diminue
            Solde -= montant;

            //Bonus : on ajoute 1% en retour (comportement additionnel pas une inversion)
            Solde += montant * TauxBonus;
        }

        // Le solde diminue d'abord(retrais est respecté) puis on ajoute le bonus le contrat est respecté car un retrait diminue bien le solde.
    }
}
