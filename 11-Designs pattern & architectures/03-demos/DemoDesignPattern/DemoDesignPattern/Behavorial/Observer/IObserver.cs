using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDesignPattern.Behavorial.Observer
{
    internal interface IObserver
    {
        void Update(string message);
    }
}
