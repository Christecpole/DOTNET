using System;
using System.Collections.Generic;
using System.Text;

namespace Demo03Heritage.Classes
{
    internal class Chat : Animal
    {
        public Chat(string nom, int age, string espece) : base(nom, age, espece)
        {
        }

        public override void Crier()
        {
            base.Crier();
            Console.WriteLine("Miaou");
        }
    }
}
