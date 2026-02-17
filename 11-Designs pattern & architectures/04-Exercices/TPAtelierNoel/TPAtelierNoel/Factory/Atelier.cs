using System;
using System.Collections.Generic;
using System.Text;
using TPAtelierNoel.Observer;

namespace TPAtelierNoel.Factory
{
    internal class Atelier
    {

        public readonly Dictionary<string, JouetFactory> _factoryMap = new Dictionary<string, JouetFactory>();

        private readonly List<IObserver> _observers = new();

        public void EnregistrerFactory(string type, JouetFactory factory)
        {
            _factoryMap.Add(type, factory);
        }

        public IJouet ProduireJouet(string type)
        {
            if (!_factoryMap.TryGetValue(type, out var factory))
                throw new ArgumentException("Type de jouet inconnu " + type);

            var jouet = factory.CreerJouet();
            NotifierLutins("Un nouveau jouer fabrique : " + jouet.GetDescription());
            return jouet;
            
        }

        public void AjouterLutin(IObserver o)
        {
            _observers.Add(o);
        }
        public void RetirerLutin(IObserver o)
        {
            _observers.Remove(o);
        }

        private void NotifierLutins(string message)
        {
            foreach(var o in _observers)
                o.Notifier(message);
        }
    }
}
