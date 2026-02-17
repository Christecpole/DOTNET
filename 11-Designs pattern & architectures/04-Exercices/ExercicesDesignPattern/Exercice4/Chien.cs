using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice4
{
    internal class Chien : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Wouf!!!");
        }
    }
}
