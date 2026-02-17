using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3
{
    internal class MailObserver : IObserver
    {
        public void onNotify(string eventName)
        {
            Console.WriteLine($"[MAIL] Envoie d'un mail pour l'event : {eventName}");
        }
    }
}
