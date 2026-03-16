using System;
using System.Collections.Generic;
using System.Text;

namespace Exercices
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Villes non trouvé"){ }
    }
}
