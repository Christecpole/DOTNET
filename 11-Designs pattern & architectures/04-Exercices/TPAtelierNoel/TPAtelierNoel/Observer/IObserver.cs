using System;
using System.Collections.Generic;
using System.Text;

namespace TPAtelierNoel.Observer
{
    internal interface IObserver
    {
        void Notifier(string message);
    }
}
