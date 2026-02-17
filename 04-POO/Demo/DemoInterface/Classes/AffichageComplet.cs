using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo05Interface.Classes
{
    //implementation de l'interface on viens la placer apres la declaration de notre classe apres les :
    internal class AffichageComplet : IAffichage
    {
        //une fois l'interface implementer on viens definir le fonctionement de chacune des methode implementé
        //le fonctionement est propre a la classe ou nous somme actuelement
        public void AfficherLaClasse()
        {
            Console.WriteLine($"La classe dans la quelle nous somme est : {base.GetType().Name} et a pour namespace : {base.GetType().Namespace}") ;
        }

        public void AfficherLaDate()
        {
            Console.WriteLine("La date est : "+DateTime.Now );
        }

        public void AfficherMessageBienvenue()
        {
            Console.WriteLine("Bienvenue sur notre page d'information !");
        }
    }
}
