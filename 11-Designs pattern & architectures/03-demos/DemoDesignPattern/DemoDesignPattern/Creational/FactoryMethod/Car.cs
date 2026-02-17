using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Je conduis ma voiture .....");
        }
    }
}
