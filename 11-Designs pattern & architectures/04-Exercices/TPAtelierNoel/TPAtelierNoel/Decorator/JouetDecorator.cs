using System;
using System.Collections.Generic;
using System.Text;
using TPAtelierNoel.Factory;

namespace TPAtelierNoel.Decorator
{
    internal abstract class JouetDecorator : IJouet
    {
        protected readonly IJouet Jouet;

        protected JouetDecorator(IJouet jouet)
        {
            Jouet = jouet;
        }

        public virtual string GetDescription()
        {
            return Jouet.GetDescription();
        }
    }
}
