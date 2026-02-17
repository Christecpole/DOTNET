using Articles.Api.Data;
using Articles.Api.Dtos;
using Articles.Api.Models;

namespace Articles.Api.Extensions
{
    public static class ArticleMappingExtension
    {
        public static ArticleDto ToArticleDto(this Article article)
        {

            // on créé ici une nouvelle enveloppe(Dto) et on y copie les donnée
            // Un objet propre prêt à être envoyé au client.
            return new ArticleDto
            {
                Id = article.Id,
                Titre = article.Titre,
                Contenu = article.Contenu,
                NomAuteur = article.Auteur != null ? $"{article.Auteur.Prenom} {article.Auteur.Nom}" : "Auteur Inconnu"
            };


        }

        public static Article ToArticle(this ArticleCreateDto Dto)
        {
            return new Article
            {
                Titre = Dto.Titre,
                Contenu = Dto.Contenu,
                AuteurId = Dto.AuteurId,
            };
        }

    }
}
