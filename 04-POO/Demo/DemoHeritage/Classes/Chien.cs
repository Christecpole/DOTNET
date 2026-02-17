using System;
using System.Collections.Generic;
using System.Text;

namespace Demo03Heritage.Classes
{
    internal class Chien : Animal
    {

        public string Jouet { get; set; }

        public Chien(string nom,int age,string espece, string jouet) : base(nom, age, espece)
        {
            Jouet = jouet;
        }

        public void aboyer()
        {
            Console.WriteLine("Wouf");
        }

        public override string ToString()
        {
            return base.ToString()+$" | Jouet : {Jouet}";
        }
    }
}
