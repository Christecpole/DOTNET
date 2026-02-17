using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPolymorphisme.Classes
{
    internal class Voiture
    {
        public String Marque { get; set; }
        public String Couleur { get; set; }
        public int NbPorte { get; set; }

        public Voiture(string marque, string couleur, int nbPorte)
        {
            Marque = marque;
            Couleur = couleur;
            NbPorte = nbPorte;
        }


    }
}
