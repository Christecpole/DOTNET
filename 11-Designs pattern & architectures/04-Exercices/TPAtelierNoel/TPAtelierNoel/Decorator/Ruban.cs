using System;
using System.Collections.Generic;
using System.Text;
using TPAtelierNoel.Factory;

namespace TPAtelierNoel.Decorator
{
    internal class Ruban : JouetDecorator
    {
        public Ruban(IJouet jouet) : base(jouet)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " et avec un jolie ruban";
        }
    }
}
