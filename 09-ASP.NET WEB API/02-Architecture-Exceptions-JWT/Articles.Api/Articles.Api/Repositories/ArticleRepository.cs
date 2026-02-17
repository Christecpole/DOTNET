using Articles.Api.Data;
using Articles.Api.Models;

namespace Articles.Api.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public void Add(Article article)
        {
            article.Id = DbFake.Articles.Any() ? DbFake.Articles.Max(a => a.Id) + 1 : 1;

            DbFake.Articles.Add(article);
        }

        public void Delete(int id)
        {
            // on réutilise notre methode getbyid pour trouver l'article
            var article = GetById(id);

            // Si il existe
            if (article != null) {
                //Alors on le supprime
                DbFake.Articles.Remove(article);
            }

        }

        //Recupère tous les articles depuis notre fausse base de données DBFAKe
        public List<Article> GetAll()
        {
            return DbFake.Articles.ToList();
        }

        public List<Article> GetByAuteurId(int auteurId)
        {
            return DbFake.Articles.Where(a => a.AuteurId == auteurId).ToList();
        }

        public Article? GetById(int id)
        {
            return DbFake.Articles.FirstOrDefault(a => a.Id == id);
        }

        public void Update(Article article)
        {
            //on cherche  à quel in dex se positionne l'article à modifier
            // FindIndex : Renvoie -1 si l'article n'est pas trouvé
            var index = DbFake.Articles.FindIndex(a=>a.Id == article.Id);

            //Si on a trouvé l'article
            if (index != -1)
            {
                //l'article à cette position est écrasé par la nouvelle version
                DbFake.Articles[index] = article;
            }
        }
    }
}
