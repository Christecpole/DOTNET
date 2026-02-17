using System;
using System.Collections.Generic;
using System.Text;

namespace Appareils
{
    internal class LecteurFichier : ILecture, IEcriture
    {
        public void Enregistrer(string chemin, string contenu)
        {
            File.WriteAllText(chemin, contenu);
        }

        public string Lire(string chemin)
        {
            return File.ReadAllText(chemin);
        }

        //    public string Lire(string chemin) // Sait faire, sait lire
        //    {
        //        return File.ReadAllText(chemin); 
        //    }
        //    public void Enregistrer(string chemin, string contenu)
        //    {
        //        File.WriteAllText(chemin, contenu); // Il sait faire
        //    }

        //    // Il ne sait pas envoyer un fax donc on est obligé ici de lancer une exception
        //    public void EnvoyerFax(string chemin)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    // Il ne sait pas imprimer donc on est obligé ici de lancer une exception
        //    public void Imprimer(string chemin)
        //    {
        //        throw new NotImplementedException();
        //    }
        //// Le lecteur doit implémenter obligatoirement des méthodes qu'il ne peut pas faire . On lance des exceptions => violation du principe I => segregation des interfaces

    }
}
