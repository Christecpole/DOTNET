using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoPendu.Classes
{
    internal class Pendu
    {
        public string Mot {  get; set; }
        public string Masque { get; set; }
        public int NbEssaisMax { get; set; }
        public int NbEssais { get; set; }

        public Pendu(int nombreEssais) 
        {
            NbEssaisMax = nombreEssais;
            Mot = GenerateurMot.GenererMot();
            Masque = new string('*', Mot.Length);
        }

        public bool TestVictoire()
        {
            return Mot == Masque;
        }

        public bool TestChar(char lettre)
        {
            if (!Mot.Contains(lettre))
            {
                NbEssais++;
                return false;
            }

            GenereMasque(lettre);
            return true;
        }

        public void GenereMasque(char letter)
        {
            char[] masqueTab = Masque.ToCharArray();
            char[] motATrouver = Mot.ToCharArray();

            for( int i = 0; i < motATrouver.Length; i++)
            {
                if(letter == motATrouver[i]) masqueTab[i] = letter;
            }

            Masque = new string(masqueTab);
        }
    }
}
