using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3
{
    internal class EventManager
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void AddObserver(IObserver observer) => _observers.Add(observer);
        public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

        public void CreateEvent(string name)
        {
            NotifyObservers(name);
        }

        private void NotifyObservers(string eventName)
        {
            foreach (IObserver observer in _observers)
            {
                observer.onNotify(eventName);
            }
        }
    }
}
