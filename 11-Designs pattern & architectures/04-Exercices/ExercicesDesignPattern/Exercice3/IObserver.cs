using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3
{
    internal interface IObserver
    {
        void onNotify(string eventName);
    }
}
