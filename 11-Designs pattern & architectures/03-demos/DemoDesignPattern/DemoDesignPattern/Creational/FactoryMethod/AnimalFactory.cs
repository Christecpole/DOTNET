using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Creational.FactoryMethod
{
    internal abstract class  AnimalFactory
    {
        public abstract IAnimal CreateAnimal();
    }
}
