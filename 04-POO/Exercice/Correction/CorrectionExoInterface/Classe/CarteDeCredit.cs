using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoInterface.Classe
{
    internal class CarteDeCredit : IPayement
    {

        public string NumeroCarte { get; set; }
        public string Titulaire { get; set; }
        public DateTime DateExpiration { get; set; }
        public string CodeCVV { get; set; }
        public double Montant { get; set; }

        public CarteDeCredit(string numeroCarte, string titulaire, DateTime dateExpiration, string codeCVV, double montant)
        {
            NumeroCarte = numeroCarte;
            Titulaire = titulaire;
            DateExpiration = dateExpiration;
            CodeCVV = codeCVV;
            Montant = montant;
        }

        public string EffectuerPaiement(double montant)
        {
            if (Montant > montant)
            {
                return "Paiement effectuer par carte";
            }
            else
            {
                return "Impossible d'effectuer le payement par carte";
            }
        }
    }
}
