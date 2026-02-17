using GestionRendezVous.Models;
using GestionRendezVous.Persistance;
using GestionRendezVous.Rappel;
using GestionRendezVous.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionRendezVous.Services
{
    internal class ServiceRendezVous
    {
        private readonly ValidateurRendezVous _validateur;
        private readonly DepotRendezVousFichier _depot;
        private readonly RappelConsole _rappel;
        public ServiceRendezVous(ValidateurRendezVous validateur, DepotRendezVousFichier depot, RappelConsole rappel) 
        {
            _depot = depot;
            _validateur = validateur;
            _rappel = rappel;
        }

        public void Enregistrer(RendezVous rendezVous)
        {
            _validateur.Valider(rendezVous);
            _depot.Sauvegarder(rendezVous);
            _rappel.EnvoyerRappel(rendezVous);
        }
    }
}
