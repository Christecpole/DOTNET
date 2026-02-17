using Articles.Api.Data;
using Articles.Api.Models;

namespace Articles.Api.Repositories
{
    public class AuteurRepository : IAuteurRepository
    {
        public void Add(Auteur auteur)
        {
            auteur.Id = DbFake.Auteurs.Any() ? DbFake.Auteurs.Max(a => a.Id) + 1 : 1;
            DbFake.Auteurs.Add(auteur);
        }

        public void Delete(int id)
        {
            var auteur = GetById(id);
            if(auteur != null ) DbFake.Auteurs.Remove(auteur);
        }

        public List<Auteur> GetAll()
        {
            return DbFake.Auteurs.ToList();
        }

        public Auteur? GetById(int id)
        {
            return DbFake.Auteurs.FirstOrDefault(a=>a.Id == id);
        }

        public void Update(Auteur auteur)
        {
            var index = DbFake.Auteurs.FindIndex(a => a.Id == auteur.Id);

            if (index != -1) DbFake.Auteurs[index] = auteur;  
        }
    }
}
