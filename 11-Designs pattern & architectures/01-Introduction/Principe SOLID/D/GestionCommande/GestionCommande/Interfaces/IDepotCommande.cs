using GestionCommande.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande.Interfaces
{
    internal interface IDepotCommande
    {
        void Sauvegarder(Commande commande);  // Contrat : je sais sauvegarder une commande

    }
}
