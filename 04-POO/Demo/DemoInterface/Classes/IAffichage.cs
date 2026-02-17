using System;
using System.Collections.Generic;
using System.Text;

namespace Demo05Interface.Classes
{
    //definition d'un interface pour specifier un fonctionionement d'affichage
    internal interface IAffichage
    {

        //on viens definir les differente signature de methode qui devront etre implementé par les classe qui utiliseron notre interface
        void AfficherLaDate();
        void AfficherLaClasse();
        void AfficherMessageBienvenue();
    }
}
