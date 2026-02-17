using System;
using System.Collections.Generic;
using System.Text;

namespace GestionCommande.Models
{
    internal class Commande
    {
        public int Id { get; set; }
        public string Client { get; set; } = "";
        public decimal Montant { get; set; }
    }
}
