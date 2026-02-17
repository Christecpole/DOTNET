using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal class Truck : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Je conduis mon camion....");
        }
    }
}
