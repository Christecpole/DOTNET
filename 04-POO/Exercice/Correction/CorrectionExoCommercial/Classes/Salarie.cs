using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionExoCommercial.Classes
{
    public class Salarie
    {
        private static int _nbSalarie = 0;
        private static double _totalSalaire = 0;

        public string Matricule { get; set; }
        public string Service { get; set; }
        public string Categorie { get; set; }
        public string Nom { get; set; }
        public double Salaire {  get; set; }

        public Salarie() 
        {
            _nbSalarie++;
        }

        public Salarie(string matricule,string service, string categorie,string nom,double salaire):this()
        {
            Matricule = matricule;
            Service = service;
            Categorie = categorie;  
            Nom = nom;
            Salaire = salaire;
            _totalSalaire += salaire;
        }

        public virtual string AfficherSalaire()
        {
            return $"Le salaire de {Nom} est de {Salaire} euros ";
        }

        public static void AffichageTotalSalarie()
        {
            Console.WriteLine($"Le nombre total de salarie dans l'entreprise est de : {_nbSalarie}");
            Console.WriteLine($"Le total des salaire vaut : {_totalSalaire}");
        }

        public static void Reset()
        {
            _nbSalarie = 0;
            _totalSalaire = 0;
        }

        public override string ToString()
        {
            return base.GetType().Name + AfficherSalaire();
        }
    }
}
