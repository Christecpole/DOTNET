using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    internal class CompteStandard : Compte
    {
        public CompteStandard(decimal soldeInitial) { Solde = soldeInitial; }
        public override void Retirer(decimal montant)
        {
            if (montant > Solde)
                throw new InvalidOperationException("Solde est insuffisant");
            Solde -= montant; // on retire : Le dolde diminue (respect du contrat)
        }
    }
}
