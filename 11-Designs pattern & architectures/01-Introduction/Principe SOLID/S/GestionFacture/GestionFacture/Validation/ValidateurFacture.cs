using GestionFacture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Validation
{
    internal class ValidateurFacture
    {
        public void Valider(Facture facture) // une seule responsabilité : valider
        {
            if (facture.Montant <= 0)
            {
                throw new ArgumentException("Le montant doit être positif.");
            }
        }
    }
}
