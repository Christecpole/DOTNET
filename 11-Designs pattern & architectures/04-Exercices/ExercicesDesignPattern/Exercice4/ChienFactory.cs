using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice4
{
    internal class ChienFactory : AnimalFactory
    {
        public override IAnimal CreateAnimal()
        {
            return new Chien();
        }
    }
}
