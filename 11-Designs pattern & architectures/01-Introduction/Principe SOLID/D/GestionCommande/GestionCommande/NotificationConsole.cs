using GestionCommande.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande
{
    internal class NotificationConsole : IServiceNotification
    {
        public void Notifier(string destinataire, string message)
        {
            Console.WriteLine($"[Notification pour {destinataire}] {message}");
        }
    }
}
