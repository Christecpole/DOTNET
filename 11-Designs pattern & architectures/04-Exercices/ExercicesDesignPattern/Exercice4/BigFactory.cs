using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice4
{
    internal class BigFactory
    {

        public readonly Dictionary<string,AnimalFactory> _factories = new Dictionary<string,AnimalFactory>();


        public void AjouterFactory(string key , AnimalFactory factory)
        {
                _factories[key] = factory;
        }


        public IAnimal ProduireAnimal(string key)
        {
            if (!_factories.TryGetValue(key, out var factory))
                throw new InvalidOperationException($"Aucune factory pour la clé : {key}");

            return factory.CreateAnimal();
            
            

        }

 

    }
}
