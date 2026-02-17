using GestionRendezVous.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionRendezVous.Validation
{
    internal class ValidateurRendezVous
    {
        public void Valider(RendezVous rendezVous)
        {
            if(rendezVous.DateHeure <= DateTime.Now)//si la date est passé ou maintenant
            {
                throw new ArgumentException("La date du rdv doit être dans le futur");
            }

        }
    }
}
