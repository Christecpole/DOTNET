using ServiceVoyage.Data;
using ServiceVoyage.Models;

namespace ServiceVoyage.Repository
{
    public class VoyageRepository : IRepository<Voyage>
    {
        private readonly AppDbContext dbContext;

        public VoyageRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Voyage Create(Voyage entity)
        {
            dbContext.Add(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public List<Voyage> GetAll()
        {
            return dbContext.Voyages.ToList();
        }

        public Voyage GetById(int id)
        {
            return dbContext.Voyages.Find(id);
        }
    }
}
