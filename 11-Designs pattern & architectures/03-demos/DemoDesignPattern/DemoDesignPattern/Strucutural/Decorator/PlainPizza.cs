using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Strucutural.Decorator
{
    internal class PlainPizza : IPizza
    {
        public string GetDescription() => "Plain Pizza";
        public double GetCost() => 5.0;
    }
}
