using GestionRendezVous.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionRendezVous.Rappel
{
    internal class RappelConsole
    {
        public void EnvoyerRappel(RendezVous rendezVous)
        {
            Console.WriteLine($"[Rappel pour {rendezVous.Client}] Rappel : rendez-vous le {rendezVous.DateHeure}");
        }
    }
}
