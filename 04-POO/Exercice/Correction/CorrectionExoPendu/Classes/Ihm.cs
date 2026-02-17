using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoPendu.Classes
{
    internal class Ihm
    {

        private Pendu _pendu;

        public void Start()
        {
            Console.WriteLine("=== Pendu ===");
            Console.WriteLine("Saisir le nombre d'essais a realiser");
            int essais = int.Parse(Console.ReadLine() ?? "10");

            _pendu = new Pendu(essais);

            bool win = false;

            do
            {
                Tour();
                win = _pendu.TestVictoire();
            } while (!win && _pendu.NbEssais != _pendu.NbEssaisMax);

            Console.WriteLine(win ? "Felicitation" : $"Dommage le mot etait {_pendu.Mot}");

        }

        private void Tour()
        {
            Console.WriteLine($"Le mot a trouver : {_pendu.Masque}");
            Console.WriteLine($"Il vous reste {_pendu.NbEssaisMax - _pendu.NbEssais}");

            Console.WriteLine("Saisir votre lettre :");
            char lettre = Convert.ToChar(Console.ReadLine() ?? string.Empty);

            if (_pendu.TestChar(lettre))
            {
                Console.WriteLine($"Le charactere {lettre} est present dans le mot");
            }
            else
            {
                Console.WriteLine("Mauvaise lettre ! ");
            }

        }
    }
}
