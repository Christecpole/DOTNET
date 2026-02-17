using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Strucutural.Decorator
{
    internal class OliveDecorator : PizzaDecorator
    {
        public OliveDecorator(IPizza Pizza) : base(Pizza)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " , avec Olives";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.0;
        }
    }
}
