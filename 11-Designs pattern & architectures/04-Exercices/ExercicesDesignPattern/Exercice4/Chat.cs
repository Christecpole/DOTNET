using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice4
{
    internal class Chat : IAnimal
    {
        public void Speak()
        {
            Console.WriteLine("Miaou!!!!");
        }
    }
}
