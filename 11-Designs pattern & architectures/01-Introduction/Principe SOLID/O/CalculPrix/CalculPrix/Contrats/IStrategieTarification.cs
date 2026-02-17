using System;
using System.Collections.Generic;
using System.Text;

namespace CalculPrix.Contrats
{
    internal interface IStrategieTarification
    {
        decimal Calculer(decimal montant);
    }
}
