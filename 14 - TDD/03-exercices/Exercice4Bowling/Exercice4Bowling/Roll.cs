using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice4Bowling
{
    public class Roll
    {
        private int pins;

        public Roll(int p)
        {
            Pins = p;
        }

        public int Pins { get => pins; set => pins = value; }
    }
}
