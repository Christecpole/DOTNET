using ApiClient.Dtos;
using ApiClient.Models;

namespace ApiClient.Extensions
{
    public static class ExtensionMappingClient
    {
        public static ClientDtoListe VersDtoListe(this Client c)
        {
            return new ClientDtoListe
            {
                Id = c.Id,
                Nom = c.Nom,
                Email = c.Email,
                DateInscription = c.DateInscription
            };
        }

        public static Client VersModele(this ClientDtoCreation dto)
        {
            return new Client
            {
                Nom = dto.Nom,
                Email = dto.Email,
                DateInscription = dto.DateInscription ?? DateTime.UtcNow
            };
        }

        public static ClientDtoDetail VersDtoDetail(this Client c)
        {
            return new ClientDtoDetail
            {
                Id = c.Id,
                Nom = c.Nom,
                Email = c.Email,
                DateInscription = c.DateInscription
            };
        }
    }
}
