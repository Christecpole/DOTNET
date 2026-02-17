using GestionCommande.Interfaces;
using GestionCommande.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande
{
    internal class DepotCommandeFichier : IDepotCommande
    {
        public void Sauvegarder(Commande commande)
        {
            string contenu = $"Commande {commande.Id} - Client: {commande.Client} - Montant: {commande.Montant} €";
            File.WriteAllText($"commande_{commande.Id}.txt", contenu);
        }
    }
}
