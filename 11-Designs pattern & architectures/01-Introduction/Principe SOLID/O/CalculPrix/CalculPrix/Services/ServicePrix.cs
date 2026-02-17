using CalculPrix.Contrats;
using CalculPrix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CalculPrix.Services
{
    internal class ServicePrix
    {
        private readonly Dictionary<string, IStrategieTarification> _strategie;

        public ServicePrix(Dictionary<string, IStrategieTarification> strategie)
        {
            _strategie = strategie;
        }

        public decimal CalculerPrix(Commande commande)
        {
            //on cherche la stratégie correspondant au type de client dans le dictionnaire
            if(!_strategie.TryGetValue(commande.TypeClient, out var strategie))
            {
                throw new ArgumentException($"Type de client inconnue : {commande.TypeClient}");
            }

            //on délègue le calcule à la stratégie trouvée. le service ne sait pas comment on calcule.
            return strategie.Calculer(commande.Montant);

            // Plus de if type client == standard. Le service utilise uniquement le dictionnaires. Pour ajouter premium on créé TarificationPremium et on l'ajoute au dictionnaire. on ne touche donc jamais à servicePrix.
        }

        //public decimal CalculerPrix(Commande commande)
        //{
        //    //Si le client est standard  : TVA 20%
        //    if (commande.TypeClient == "Standard")
        //        return commande.Montant * 1.20m;

        //    //Si le client est VIP : TVA à 20% puis une reduction 10%
        //    if (commande.TypeClient == "Standard")
        //        return commande.Montant * 1.20m * 0.9m;

        //    //Si le client est Pro : Pas de TVA
        //    if (commande.TypeClient == "Standard")
        //        return commande.Montant;

        //    //Si le type est inconnu : on leve une exception
        //    throw new ArgumentException("Type inconnu");


        //    //Probleme : Pour rajouter un type premium, on doit modifier cette methode (ajouter un nouveau if), on touche donc au code qui marche déjà ==> il y a un risque de régression
        //}

        
    }
}
