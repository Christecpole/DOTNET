using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3
{
    internal class ConsoleLogger : IObserver
    {
        public void onNotify(string eventName)
        {
            Console.WriteLine($"[CONSOLE] Event : {eventName}");
        }
    }
}
