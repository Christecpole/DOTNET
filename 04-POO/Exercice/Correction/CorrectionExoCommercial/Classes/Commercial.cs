using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCommercial.Classes
{
    internal class Commercial : Salarie
    {

        public double ChiffreAffaire { get; set; }
        public int Commission { get; set; }
    

        public Commercial(string matricule, string service, string categorie, string nom, double salaire,double chiffreAffaire, int commision) : base(matricule, service, categorie, nom, salaire)
        {
           ChiffreAffaire = chiffreAffaire;
           Commission = commision;
        }

        public override string AfficherSalaire()
        {
            double salaireTotal = Salaire + (ChiffreAffaire * (Commission / 100.0));
            return $" Le salaire de {Nom} est de {salaireTotal} euros ";
        }

        public override string ToString()
        {
            return base.ToString();
        }




    }
}
