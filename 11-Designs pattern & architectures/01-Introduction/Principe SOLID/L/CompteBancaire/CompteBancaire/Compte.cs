using System;
using System.Collections.Generic;
using System.Text;

namespace CompteBancaire
{
    internal abstract class Compte // classe abstraite : on ne l'instancie pas directement
    {
        public decimal Solde { get; protected set; } // solde accessible en lecture , modificable par les sous classes
        public abstract void Retirer(decimal montant); //Methode abstraite ; chaque sous classe l'implemente
    }
}
