using GestionRendezVous.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionRendezVous.Persistance
{
    internal class DepotRendezVousFichier
    {
        public void Sauvegarder(RendezVous rendezVous)
        {
            string contenu = $"RDV {rendezVous.Id} - Client: {rendezVous.Client} - Date: {rendezVous.DateHeure}";
            File.WriteAllText($"rendezvous_{rendezVous.Id}.txt", contenu);
        }
    }
}
