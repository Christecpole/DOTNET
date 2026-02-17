using Articles.Api.Data;
using Articles.Api.Dtos;
using Articles.Api.Models;

namespace Articles.Api.Extensions
{
    public static class ArticleMappingExtension
    {
        public static ArticleDto ToArticleDto(this Article article)
        {
            // ?? signifie si c'est null à gauche on prend la valeur de droite
            // on verifie si la propriété de navigation est déjà remplie (EF avec Include())
            var auteur = article.Auteur ?? DbFake.Auteurs.FirstOrDefault(a => a.Id == article.AuteurId);

            // on créé ici une nouvelle enveloppe(Dto) et on y copie les donnée
            // Un objet propre prêt à être envoyé au client.
            return new ArticleDto
            {
                Id = article.Id,
                Titre = article.Titre,
                Contenu = article.Contenu,
                NomAuteur = auteur != null ? $"{auteur.Prenom} {auteur.Nom}" : "Auteur Inconnu"
            };


        }

        public static Article ToArticle(this ArticleCreateDto Dto)
        {
            return new Article
            {
                Titre = Dto.Titre,
                Contenu = Dto.Contenu,
                AuteurId = Dto.AuteurId,
                Auteur = DbFake.Auteurs.FirstOrDefault(a=>a.Id == Dto.AuteurId),
            };
        }

    }
}
