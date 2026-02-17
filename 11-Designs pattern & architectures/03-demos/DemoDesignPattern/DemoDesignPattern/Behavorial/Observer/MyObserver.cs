using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Behavorial.Observer
{
    internal class MyObserver : IObserver
    {
        private readonly string _name;

        public MyObserver(string name)
        {
            _name = name;
        }

        public void Update(string message)
        {
            Console.WriteLine($"{_name} received : {message}");
        }
    }
}
