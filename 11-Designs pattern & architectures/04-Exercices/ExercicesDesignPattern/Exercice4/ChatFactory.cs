using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice4
{
    internal class ChatFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Chat();
        }
    }
}
