using Demo07Exception.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo07Exception.Classe
{
    internal class Compte
    {
        public double Solde { get; set; }

        public void Verser (double montant)
        {
            if (montant < 0) throw new MontantNegatifException($" le montant {montant} est negatif ");
            Solde += montant;
        }

        public void Retirer (double montant)
        {
            if (montant < 0) throw new MontantNegatifException($" le montant {montant} est negatif ");
            if (montant > Solde) throw new SoldeInsuffisantExceptiont("Solde insuffisant pour un retrait");
            Solde -= montant;
        }
    }
}
