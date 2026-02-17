using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoPendu.Classes
{
    internal class GenerateurMot
    {
        private static readonly String[] _mots = {
            "pieu",
            "enclume",
            "panique",
            "banane",
            "corail"
        };

        public static string GenererMot()
        {
            return _mots[new Random().Next(_mots.Length)];
        }
    }
}
