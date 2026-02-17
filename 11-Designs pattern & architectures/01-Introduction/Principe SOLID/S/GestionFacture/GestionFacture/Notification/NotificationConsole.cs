using GestionFacture.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Notification
{
    internal class NotificationConsole
    {
        public void Notifier(string destinataire, string message) // une seule responsabilité : notifier
        {
            Console.WriteLine($"[Notification pour {destinataire}] {message}");
        }
    }
}
