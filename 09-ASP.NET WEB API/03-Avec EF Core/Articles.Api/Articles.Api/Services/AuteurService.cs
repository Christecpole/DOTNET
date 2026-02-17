using Articles.Api.Dtos;
using Articles.Api.Exceptions;
using Articles.Api.Extensions;
using Articles.Api.Repositories;

namespace Articles.Api.Services
{
    public class AuteurService : IAuteurService
    {
        private readonly IAuteurRepository _repository;

        public AuteurService(IAuteurRepository repository)
        {
            _repository = repository;
        }
        public async Task<AuteurDto> AddAsync(AuteurCreateDto dto)
        {
            var auteur = dto.ToAuteur();

            await _repository.AddAsync(auteur);
            return auteur.ToAuteurDto();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var auteur = await _repository.GetByIdAsync(id);
            if (auteur == null)
            {
                throw new NotFoundException($"Impossible de supprimer : L'auteur {id} est introuvable.");
            }

            await _repository.DeleteAsync(id);
            return true;
        }

        public async Task<List<AuteurDto>> GetAllAsync()
        {
            var auteurs = await _repository.GetAllAsync();
            return auteurs.Select(a => a.ToAuteurDto()).ToList();
        }

        public async Task<AuteurDto?> GetByIdAsync(int id)
        {
            var auteur = await _repository.GetByIdAsync(id);
            return auteur?.ToAuteurDto();
        }

        public async Task<AuteurDto?> UpdateAsync(int id, AuteurCreateDto dto)
        {
            var auteur = await _repository.GetByIdAsync(id);
            if (auteur == null)
            {
                throw new NotFoundException($"Impossible de modifier ! L'auteur {id} n'existe pas"); ;
            }
                

            auteur.Nom = dto.Nom;
            auteur.Prenom = dto.Prenom;

            await _repository.UpdateAsync(auteur);
            return auteur.ToAuteurDto();
        }
    }
}
