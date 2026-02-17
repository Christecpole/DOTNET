using System;
using System.Collections.Generic;
using System.Text;

namespace TPAtelierNoel.Observer
{
    internal class Lutin : IObserver
    {
        private readonly string _nom;

        public Lutin(string nom)
        {
            _nom = nom; 
        }

        public void Notifier(string message)
        {
            Console.WriteLine(_nom+ " a recu le message :  "+message);
        }
    }
}
