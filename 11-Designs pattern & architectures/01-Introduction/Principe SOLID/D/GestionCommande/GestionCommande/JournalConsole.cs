using GestionCommande.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande
{
    internal class JournalConsole : IJournal
    {
        public void Ecrire(string message) => Console.WriteLine($"[Journal] {message}");

    }
}
