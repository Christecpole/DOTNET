using System;
using System.Collections.Generic;
using System.Text;

namespace DemoPolymorphisme.Classes
{
    internal class Concessionnaire
    {

        public Voiture[] voitures = new Voiture[10];
        private int cpt = 0;


        public void AddVoiture (Voiture voiture)
        {
            voitures[cpt++] = voiture;
        }

        public void AddVoiture(String marque, string couleur, int nbPorte)
        {
            Voiture voiture = new Voiture(marque, couleur, nbPorte);
            voitures[cpt++] = voiture;
        }

    }
}
