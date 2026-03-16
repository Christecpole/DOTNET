using ServiceVoyage.Dto;
using ServiceVoyage.Models;
using ServiceVoyage.Repository;

namespace ServiceVoyage.Service
{
    public class Service : IService<VoyageSend, VoyageReceive>
    {
        private readonly IRepository<Voyage> repository;

        public Service (IRepository<Voyage> repository)
        {
            this.repository = repository;
        }

        public VoyageSend Create(VoyageReceive entity)
        {
            return EntityToDto(repository.Create(DtoToEntity(entity)));
        }

        public List<VoyageSend> GetAll()
        {
            List<Voyage> voyages = repository.GetAll();
            List<VoyageSend> sends = new List<VoyageSend>();
            foreach (var voyage in voyages)
            {
                sends.Add(EntityToDto(voyage));
            }
            return sends;
        }

        public VoyageSend GetById(int id)
        {
            var voyage = repository.GetById(id);
            if (voyage is null) {
                return null;
            }
            return EntityToDto(voyage);
        }

        private Voyage DtoToEntity (VoyageReceive voyageReceive)
        {
            return new Voyage() { Destination = voyageReceive.Destination, Prix =  voyageReceive.Prix , DateDepart = DateOnly.Parse(voyageReceive.DateDepartStr) };
        }

        private VoyageSend EntityToDto(Voyage voyage)
        {
            return new VoyageSend() {Id = voyage.Id ,Destination = voyage.Destination, Prix = voyage.Prix, DateDepart = voyage.DateDepart };
        }

    }
}
