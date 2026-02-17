using System;
using System.Collections.Generic;
using System.Text;

namespace Demo04Abstraction.Classes
{
    internal class Violon : Instrument
    {
        public Violon(string nom, string type) : base(nom, type)
        {
        }

        public override void Jouer()
        {
            Console.WriteLine("Je joue du violon");
        }

        public override void Reparer()
        {
            base.Reparer();
            Console.WriteLine("L'instrument etait un violon");
        }

        public void JouerDeLArchet()
        {
            Console.WriteLine("Archet");
        }
    }
}
