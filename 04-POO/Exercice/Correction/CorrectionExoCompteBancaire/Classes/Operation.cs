using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCompteBancaire.Classes
{
    internal class Operation
    {
        // cptOperation sert a compter le nombre d'operation realiser c'est une variable static qui est donc liée a la classe Operation et pas a une instance donc elle est global a toute les operation et permet de garder le compte du nombre d'operation crée
        private static int _cptOperation = 0;

        public int Numero { get; set; }
        public double Montant { get; set; }

        //ajout d'un enum pour limiter le nombre de valeur que peu prendre notre variable statut
        public Statut Statut { get; set; }

        public Operation(double montant,Statut statut) 
        {
            //lorsque l'on crée une operation on incremente le nombre d'operation crée
            Numero = ++_cptOperation;
            Montant = montant;
            Statut = statut;
        }

        public override string ToString()
        {
            return $"Montant : {Montant} | Statut : {Statut}";
        }
    }
}
