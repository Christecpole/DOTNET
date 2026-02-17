using System;
using System.Collections.Generic;
using System.Text;

namespace Demo05Interface.Classes
{
    //implementation de l'interface on viens la placer apres la declaration de notre classe apres les :
    internal class AffichageBasique : IAffichage
    {

        //une fois l'interface implementer on viens definir le fonctionement de chacune des methode implementé
        //le fonctionement est propre a la classe ou nous somme actuelement
        public void AfficherLaClasse()
        {
            Console.WriteLine(base.GetType().Name);
        }

        public void AfficherLaDate()
        {
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
        }

        public void AfficherMessageBienvenue()
        {
            Console.WriteLine("Bienvenue");
        }
    }
}
