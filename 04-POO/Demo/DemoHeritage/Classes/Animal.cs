using System;
using System.Collections.Generic;
using System.Text;

namespace Demo03Heritage.Classes
{
    internal class Animal
    {
        public string Nom {  get; set; }
        public int Age { get; set; }
        public string Espece {  get; set; }

        public Animal(string nom, int age, string espece)
        {
            Nom = nom;
            Age = age;
            Espece = espece;
        }

        public virtual void Crier()
        {
            Console.WriteLine("Je suis un animal qui cire");
        }

        public void Manger()
        {
            Console.WriteLine("Je mange");
        }

        public override string ToString()
        {
            return base.GetType().Name+ $" | Nom : {Nom} | Age : {Age} | Espece : {Espece}";
        }
    }
}
