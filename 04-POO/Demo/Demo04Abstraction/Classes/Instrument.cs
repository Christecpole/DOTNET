using System;
using System.Collections.Generic;
using System.Text;

namespace Demo04Abstraction.Classes
{
    internal abstract class Instrument
    {
        public string Nom {  get; set; }
        public string Type { get; set; }

        public Instrument(string nom, string type)
        {
            Nom = nom;
            Type = type;
        }

        public abstract void Jouer();

        public virtual void Reparer () 
        {
            Console.WriteLine($"{Nom} est reparer");
        }
    }
}
