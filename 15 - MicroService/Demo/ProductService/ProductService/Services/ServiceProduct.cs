using ProductService.Dtos;
using ProductService.Models;
using ProductService.Repository;

namespace ProductService.Services
{
    public class ServiceProduct
    {
        private readonly ProductRepository _repository;

        public ServiceProduct (ProductRepository repository)
        {
            _repository = repository;
        }

        public ProductSend Create(ProductReceive receive)
        {
            Product product = DtoToEntity(receive);
            _repository.Create(product);
            return EntityToDto(product);
        }

        public ProductSend GetById (int id)
        {
            Product found = _repository.GetById(id);
            if (found == null)
            {
                return null;
            }
            return EntityToDto(found);
        }

        public List<ProductSend> GetAll()
        {
            List<Product> products = _repository.GetAll();
            List<ProductSend> productSends = new List<ProductSend>();
            foreach (Product product in products)
            {
                productSends.Add(EntityToDto(product));
            }

            return productSends;
        }



        private Product DtoToEntity(ProductReceive receive)
        {
            return new Product() { Price = receive.price, Name = receive.name ,Quantity = receive.quantity};
        }

        private ProductSend EntityToDto(Product product)
        {
            return new ProductSend (product.Id ,product.Price, product.Quantity,  product.Name );
        }
    }
}
