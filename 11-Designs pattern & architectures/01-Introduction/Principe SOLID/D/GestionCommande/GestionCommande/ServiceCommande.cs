using GestionCommande.Interfaces;
using GestionCommande.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande
{
    internal class ServiceCommande
    {
        // Problème : le service CRÉE lui-même ses dépendances (new)
        //private readonly DepotCommandeFichier _depot = new DepotCommandeFichier();
        //private readonly JournalConsole _journal = new JournalConsole();
        //private readonly NotificationConsole _notification = new NotificationConsole();

        // Champs : on stocke les interfaces reçues (pas les classes concrètes)
        private readonly IDepotCommande _depot;
        private readonly IServiceNotification _notification;
        private readonly IJournal _journal;

        // Constructeur : on REÇOIT les dépendances. On ne les crée PAS.
        public ServiceCommande(IDepotCommande depot, IServiceNotification notification, IJournal journal)
        {
            _depot = depot;
            _notification = notification;
            _journal = journal;
        }

        public void Traiter(Commande commande)
        {
            _journal.Ecrire("Traitement de la commande " + commande.Id);  // On journalise
            _depot.Sauvegarder(commande);  // On sauvegarde
            _notification.Notifier(commande.Client, "Commande confirmée.");  // On notifie
        }
    }
}
