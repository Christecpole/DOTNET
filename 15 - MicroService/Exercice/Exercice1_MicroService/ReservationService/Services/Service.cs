using ReservationService.Client;
using ReservationService.Dto;
using ReservationService.Dtos;
using ReservationService.Models;
using ReservationService.Repository;

namespace ReservationService.Services
{
    public class Service : IService<ReservationSend, ReservationReceive>
    {
        private readonly RestClient<VoyageSend> restClient;
        private readonly IRepository<Reservation> repository;
        public Service(IRepository<Reservation> repository)
        {
            this.repository = repository;
            restClient = new RestClient<VoyageSend>("http://localhost:8081/api/Voyage");
        }

        public async Task<ReservationSend> Create(ReservationReceive receive)
        {
            var found = restClient.GetRequest("" + receive.VoyageId);
            if(found is null) throw new Exception("Voyage not found");

            return await EntityToDto(repository.Create(DtoToEntity(receive)));

        }

        public async  Task<List<ReservationSend>> GetAll()
        {
            List<Reservation> reservations = repository.GetAll();
            List<ReservationSend> reservationSends = new List<ReservationSend>();
            foreach (var reservation in reservations) 
            {
                reservationSends.Add(await EntityToDto(reservation));
            }

            return reservationSends;
        }

        public async Task<ReservationSend> GetById(int id)
        {
            return await EntityToDto(repository.GetById(id));
        }

        private Reservation DtoToEntity (ReservationReceive receive)
        {
            return new Reservation() { NombrePlaces = receive.NombrePlaces,VoyageId = receive.VoyageId,NomClient = receive.NomClient};
        }

        private async Task<ReservationSend> EntityToDto (Reservation reservation)
        {
            ReservationSend send = new ReservationSend() {Id=reservation.Id, NombrePlaces = reservation.NombrePlaces,NomClient=reservation.NomClient};

            send.Voyage = await restClient.GetRequest("" + reservation.VoyageId);
            return send;
        }
    }
}
