using Articles.Api.Dtos;
using Articles.Api.Models;

namespace Articles.Api.Extensions
{
    public static class AuteurMappingExtension
    {
        public static AuteurDto ToAuteurDto(this Auteur auteur)
        {
            return new AuteurDto
            {
                Id = auteur.Id,
                Nom = auteur.Nom,
                Prenom = auteur.Prenom,
            };
        }

        public static Auteur ToAuteur(this AuteurCreateDto dto)
        {
            return new Auteur
            {
                Nom = dto.Nom,
                Prenom = dto.Prenom,
            };
        }
    }
}
