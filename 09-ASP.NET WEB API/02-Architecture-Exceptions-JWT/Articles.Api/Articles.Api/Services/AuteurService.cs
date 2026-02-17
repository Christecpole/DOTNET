using Articles.Api.Dtos;
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
        public AuteurDto Add(AuteurCreateDto dto)
        {
            var auteur = dto.ToAuteur();

            _repository.Add(auteur);

            return auteur.ToAuteurDto();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AuteurDto> GetAll()
        {
            return _repository.GetAll().Select(a=> a.ToAuteurDto()).ToList();
        }

        public AuteurDto? GetById(int id)
        {
            var auteur = _repository.GetById(id);

            return auteur?.ToAuteurDto();
        }

        public bool Update(int id, AuteurCreateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
