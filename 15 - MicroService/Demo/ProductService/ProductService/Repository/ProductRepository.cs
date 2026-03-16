using ProductService.Data;
using ProductService.Models;

namespace ProductService.Repository
{
    public class ProductRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductRepository (ApplicationDbContext db)
        {
            _db = db;
        }

        public bool Create (Product product)
        {
            _db.Add(product);
            _db.SaveChanges();
            return true;
        }

        public List<Product> GetAll()
        {
            return _db.products.ToList();
        }

        public Product GetById(int id)
        {
            return _db.products.Find(id);
        }
    }
}
