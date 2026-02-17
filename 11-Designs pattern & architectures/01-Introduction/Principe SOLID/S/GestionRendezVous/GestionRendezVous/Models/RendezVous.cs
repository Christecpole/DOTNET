using System;
using System.Collections.Generic;
using System.Text;

namespace GestionRendezVous.Models
{
    internal class RendezVous
    {
        public int Id { get; set; }
        public string Client { get; set; } = "";
        public DateTime DateHeure { get; set; }
    }
}
