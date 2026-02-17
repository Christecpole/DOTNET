using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3
{
    internal class FileLogger : IObserver
    {
        public void onNotify(string eventName)
        {
            Console.WriteLine($"[FICHIER] Ecriture de l'event : {eventName}");
        }
    }
}
