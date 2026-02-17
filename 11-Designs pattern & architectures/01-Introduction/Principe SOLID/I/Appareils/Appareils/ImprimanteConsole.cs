using System;
using System.Collections.Generic;
using System.Text;

namespace Appareils
{
    internal class ImprimanteConsole : IImpression
    {
        public void Imprimer(string chemin)
        {
            string contenu = File.Exists(chemin) ? File.ReadAllText(chemin) : "(Fichier vide)";
            Console.WriteLine($"[IMPRESSION] {contenu}");
        }
    }
}
