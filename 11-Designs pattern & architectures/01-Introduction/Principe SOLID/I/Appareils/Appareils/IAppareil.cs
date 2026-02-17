using System;
using System.Collections.Generic;
using System.Text;

namespace Appareils
{
    internal interface IAppareil
    {
        string Lire(string chemin); //lire un fichier
        void Enregistrer(string chemin, string contenu);// enregistrer un fichier
        void Imprimer(string chemin);
        void EnvoyerFax(string chemin);
    }
}
