using ReservationService.Data;
using ReservationService.Models;

namespace ReservationService.Repository
{
    public class ReservationRepository : IRepository<Reservation>
    {
        private readonly AppDbContext dbContext;

        public ReservationRepository (AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Reservation Create(Reservation entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public List<Reservation> GetAll()
        {
            return dbContext.Reservations.ToList();
        }

        public Reservation GetById(int id)
        {
            return dbContext.Reservations.Find(id);
        }
    }
}
