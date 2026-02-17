using CorrectionExoCompteBancaire.Classes.Compte;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCompteBancaire.Classes
{
    internal class Client
    {
        public string Nom {  get; set; }
        public string Prenom { get; set; }
        public string Identifiant { get; set; }
        public List<CompteBancaire> CompteBancaires { get; set; }
        public string Telephone { get; set; }

        public Client(string nom,string prenom,string identifiant,string telephone) 
        {
            Nom = nom;
            Prenom = prenom;
            Identifiant = identifiant;
            Telephone = telephone;
            CompteBancaires = new List<CompteBancaire>();
        }

        public void AddCompteBancaire (CompteBancaire compteBancaire)
        {
            //lorsque l'on travail avec des liste pour ajouter un element dedans on appel simplement la methode add et on lui passe en parametre l'objet a ajouter
            CompteBancaires.Add(compteBancaire);
        }
    }
}
