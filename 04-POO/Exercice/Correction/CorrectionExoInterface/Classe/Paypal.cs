using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoInterface.Classe
{
    internal class Paypal : IPayement
    {
        public string Adresse { get; set; }
        public string Email { get; set; }
        public string MotDePasse { get; set; }
        public double Montant { get; set; }

        public Paypal(string adresse, string email, string motDePasse, double montant)
        {
            Adresse = adresse;
            Email = email;
            MotDePasse = motDePasse;
            Montant = montant;
        }

        public string EffectuerPaiement(double montant)
        {
            if(montant < Montant)
            {
                return "Paiement effectué via paypal ";
            }
            else
            {
                return "Impossible d'effectuer le paiement via paypal";
            }
                ;
        }
    }
}
