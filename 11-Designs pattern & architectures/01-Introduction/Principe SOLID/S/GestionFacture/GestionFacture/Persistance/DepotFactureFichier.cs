using GestionFacture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Persistance
{
    internal class DepotFactureFichier
    {
        public void Sauvegarder(Facture facture) // Une seule responsabilité : sauvegarder
        {
            string contenu = $"Facture {facture.Id} - Client: {facture.Client} - Montant: {facture.Montant}";
            File.WriteAllText($"facture_{facture.Id}.txt", contenu);
        }
    }
}
