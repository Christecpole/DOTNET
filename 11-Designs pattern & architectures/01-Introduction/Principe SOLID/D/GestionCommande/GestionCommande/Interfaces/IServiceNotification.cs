using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande.Interfaces
{
    internal interface IServiceNotification
    {
        void Notifier(string destinataire, string message);  // Contrat : je sais notifier

    }
}
