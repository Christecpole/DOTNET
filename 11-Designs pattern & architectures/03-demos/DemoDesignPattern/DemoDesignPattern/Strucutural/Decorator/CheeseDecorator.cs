using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Strucutural.Decorator
{
    internal class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza Pizza) : base(Pizza)
        {
        }

        public override string GetDescription()
        {
            return base.GetDescription() + " , avec fromage";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.5;
        }
    }
}
