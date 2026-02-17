using System;
using System.Collections.Generic;
using System.Text;

namespace GestionFacture.Models
{
    internal class Facture
    {
        public int Id { get; set; }
        public string Client { get; set; } = string.Empty; //Email ou un nom client
        public decimal Montant { get; set; }
    }
}
