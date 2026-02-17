using System;
using System.Collections.Generic;
using System.Text;

namespace Demo04Abstraction.Classes
{
    internal class Piano : Instrument
    {
        public Piano(string nom, string type) : base(nom, type)
        {
        }

        public override void Jouer()
        {
            Console.WriteLine("Je joue du piano debout");
        }
    }
}
