using System;
using System.Collections.Generic;
using System.Text;

namespace CalculPrix.Models
{
    internal class Commande
    {
        public decimal Montant { get; set; } // Montant HT de la commande
        public string TypeClient { get; set; } = string.Empty; // "standard", "VIP", "Pro" 
    }
}
