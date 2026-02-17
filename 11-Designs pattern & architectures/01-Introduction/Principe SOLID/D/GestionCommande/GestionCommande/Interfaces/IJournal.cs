using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande.Interfaces
{
    internal interface IJournal
    {
        void Ecrire(string message);  // Contrat : je sais écrire un message

    }
}
