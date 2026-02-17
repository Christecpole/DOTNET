using System;
using System.Collections.Generic;
using System.Text;

namespace Appareils
{
    internal class ServiceImpression 
    {
        private readonly IImpression _imprimante; // il dépend seulement de iimpression

        public ServiceImpression(IImpression imprimante)
        {
            _imprimante = imprimante;
        }

        public void ImprimerDocument(string chemin)
        {
            _imprimante.Imprimer(chemin);
        }
    }
}
