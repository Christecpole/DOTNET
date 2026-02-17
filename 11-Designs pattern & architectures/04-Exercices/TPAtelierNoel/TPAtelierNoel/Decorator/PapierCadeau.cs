using System;
using System.Collections.Generic;
using System.Text;
using TPAtelierNoel.Factory;

namespace TPAtelierNoel.Decorator
{
    internal class PapierCadeau : JouetDecorator
    {
        public PapierCadeau(IJouet jouet) : base(jouet)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " dans un jolie papier cadeau";
        }
    }
}
