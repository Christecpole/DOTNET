using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal class Dog : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Je suis un chien et j'aboie");
        }
    }
}
