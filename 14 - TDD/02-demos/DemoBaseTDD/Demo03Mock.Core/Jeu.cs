using System;
using System.Collections.Generic;
using System.Text;

namespace Demo03Mock.Core
{
    public class Jeu
    {

        private IDe _de;

        public Jeu(IDe de)
        {
            _de = de;
        }

        public bool Jouer() // méthode pour jouer au jeu => retourn true si on gagne
        {
            //throw new NotImplementedException();
            // le joueur gagne si le de renvoie 20
            return _de.Lancer() == 20;
        }

        public bool JouerAvecBonus(int bonus)
        {
            return _de.LancerAvecBonus(bonus) >= 20;
        }
    }
}
