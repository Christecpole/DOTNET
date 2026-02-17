using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCompteBancaire.Classes.Compte
{

    //classe Abstraite servant de base pour la creation de nos diffents comptes
    internal abstract class CompteBancaire
    {
        public double Solde {get;set;}
        public Client Client { get;set;}
        public List<Operation> Operations {get;set;}


        //Le constructeur dois etre ajouter memem si la classe abstraite ne seras pas instancié pour pouvoir remplir les valeur des diferentes proprietées presente dans notre classe CompteBanquaire
        public CompteBancaire (double Solde, Client client)
        {
            this.Solde = Solde;
            this.Client = client;
            Operations = new List<Operation>();
        }


        //Les methode abstraite sont des methodes qui on uniquement leurs signature de declarer dans la classe abstraire et  leurs fonctionnement est unique definie lorsque la classe abstraite est herité
        public abstract void Depot(double montant);
        public abstract bool Retrait(double montant);


        //La methode ToString permet de transformer notre objet en une chaine de caractere pour l'affichage dans la console
        public override string ToString()
        {
            return base.GetType().Name + $" | Solde : {Solde}";
        }

    }
}
