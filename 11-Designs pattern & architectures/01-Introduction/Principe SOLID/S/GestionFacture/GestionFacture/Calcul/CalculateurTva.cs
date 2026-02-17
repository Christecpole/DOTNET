using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Calcul
{
    internal class CalculateurTva
    {
        public decimal CalculerAvecTva(decimal montant) // Une seule responsabilité : calculer la TVA
        {
            return montant * 1.20m;
        }
    }
}
