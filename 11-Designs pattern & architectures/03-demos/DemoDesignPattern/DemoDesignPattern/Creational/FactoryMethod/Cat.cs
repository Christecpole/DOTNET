using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal class Cat : IAnimal
    {
        public void MakeSound()
        {
            Console.WriteLine("Je suis un chat et je miaule");
        }
    }
}
