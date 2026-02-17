using CalculPrix.Contrats;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculPrix.strategies
{
    internal class TarificationStandard : IStrategieTarification
    {
        public decimal Calculer(decimal montant)
        {
            return montant * 1.20m;
        }
    }
}
